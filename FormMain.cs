using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageApproximater
{
    public partial class FormMain : Form
    {
        Random _rnd = new Random();
        Bitmap _bmpOriginal = new Bitmap(1, 1);
        Bitmap _bmpDisplayed = new Bitmap(1, 1);
        bool _breakLoop = false;
        int _updateEvery = 100;
        bool _approxImageStale = false;
        long _iterations = 100000;
        int _pixelSkip = 1;
        Rectangle _modifiedRect = new Rectangle(0, 0, 0, 0);

        enum ShapeType
        {
            Pixel,
            Triangle,
            Rectangle,
            Square,
            Ellipse
        }

        public FormMain()
        {
            InitializeComponent();
        }

        unsafe bool IsNewBmpBetter(BitmapData origImageData, Bitmap oldApprox, Bitmap newApprox)
        {
            long oldScore = 0;
            long newScore = 0;

            if (_modifiedRect.Width == 0 || _modifiedRect.Height == 0) return false;

            BitmapData oldApproxImageData = oldApprox.LockBits(new Rectangle(0, 0, oldApprox.Width, oldApprox.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData newApproxImageData = newApprox.LockBits(new Rectangle(0, 0, newApprox.Width, newApprox.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int bytesPerPixel = 3;
            byte* scan0Orig = (byte*)origImageData.Scan0.ToPointer();
            byte* scan0OldApprox = (byte*)oldApproxImageData.Scan0.ToPointer();
            byte* scan0NewApprox = (byte*)newApproxImageData.Scan0.ToPointer();
            int stride = origImageData.Stride;

            // https://www.codeproject.com/Articles/617613/Fast-Pixel-Operations-in-NET-With-and-Without-unsa
            for (int y = _modifiedRect.Y; y < _modifiedRect.Y + _modifiedRect.Height; y += _pixelSkip)
            {
                byte* rowOrig = scan0Orig + (y * stride);
                byte* rowOldApprox = scan0OldApprox + (y * stride);
                byte* rowNewApprox = scan0NewApprox + (y * stride);

                for (int x = _modifiedRect.X; x < _modifiedRect.X + _modifiedRect.Width; x += _pixelSkip)
                {
                    // Watch out for actual order (BGR)!
                    int bIndex = x * bytesPerPixel;
                    int gIndex = bIndex + 1;
                    int rIndex = bIndex + 2;

                    oldScore += Math.Abs(rowOrig[rIndex] - rowOldApprox[rIndex]);
                    oldScore += Math.Abs(rowOrig[gIndex] - rowOldApprox[gIndex]);
                    oldScore += Math.Abs(rowOrig[bIndex] - rowOldApprox[bIndex]);
                    newScore += Math.Abs(rowOrig[rIndex] - rowNewApprox[rIndex]);
                    newScore += Math.Abs(rowOrig[gIndex] - rowNewApprox[gIndex]);
                    newScore += Math.Abs(rowOrig[bIndex] - rowNewApprox[bIndex]);
                }
            }

            oldApprox.UnlockBits(oldApproxImageData);
            newApprox.UnlockBits(newApproxImageData);

            return newScore < oldScore;

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // NOTE: Threads are not used, instead the Application.DoEvents() is used to keep the GUI
            // responsive.  I know, I know, ick.

            if (buttonStart.Text == "Stop") { _breakLoop = true; return; }

            try
            {
                _breakLoop = false;
                _iterations = Convert.ToInt64(textBoxIterations.Text);
                _pixelSkip = Convert.ToInt32(textBoxPixelSkip.Text);
                buttonStart.Text = "Stop";
                buttonLoad.Enabled = false;

                Bitmap bmpApprox = new Bitmap(_bmpOriginal.Width, _bmpOriginal.Height);
                using (Graphics g = Graphics.FromImage(bmpApprox))
                {
                    g.FillRectangle(Brushes.Black, new Rectangle(0, 0, _bmpOriginal.Width, _bmpOriginal.Height));
                }
                pictureBoxSource.Image = _bmpOriginal;
                pictureBoxApproximation.Image = bmpApprox;
                Application.DoEvents();

                if (rbUpdateRate100.Checked) _updateEvery = 100;
                if (rbUpdateRate50.Checked) _updateEvery = 50;
                if (rbUpdateRate25.Checked) _updateEvery = 25;

                // Original img data is locked once, at the start
                BitmapData origImageData = _bmpOriginal.LockBits(new Rectangle(0, 0, _bmpOriginal.Width, _bmpOriginal.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                _modifiedRect = new Rectangle(0, 0, origImageData.Width, origImageData.Height);

                DateTime start = DateTime.Now;
                DateTime lastUpdate = start;
                for (int i = 0; i < _iterations; i++)
                {
                    if (_breakLoop) break;
                    Bitmap bmpApproxNew = new Bitmap(bmpApprox);
                    using (Graphics g = Graphics.FromImage(bmpApproxNew))
                    {
                        DrawShape(g, bmpApproxNew.Width, bmpApproxNew.Height);

                        // NOTE: Automatic garbage collection is nice and all but a bit slow when we are creating images 
                        // by the boatload.  Memory limits will be quickly reached when processing large images, so
                        // specifically dispose images as we no longer need them.
                    }

                    if (IsNewBmpBetter(origImageData, bmpApprox, bmpApproxNew))
                    {
                        _approxImageStale = true;
                        bmpApprox.Dispose();
                        bmpApprox = bmpApproxNew;
                    }
                    else
                    {
                        bmpApproxNew.Dispose();
                    }

                    if ((DateTime.Now - lastUpdate).TotalMilliseconds > _updateEvery)
                    {
                        if (_approxImageStale)
                        {
                            Image old = pictureBoxApproximation.Image;
                            pictureBoxApproximation.Image = (Image)bmpApprox.Clone();
                            old.Dispose();
                            _approxImageStale = false;
                        }

                        labelStatus.Text = i.ToString() + " iterations, elapsed: " + (DateTime.Now - start).ToString();
                        Application.DoEvents();
                        lastUpdate = DateTime.Now;
                    }
                }

                labelStatus.Text = _iterations.ToString() + " iterations, elapsed: " + (DateTime.Now - start).ToString();

                _bmpOriginal.UnlockBits(origImageData);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            buttonStart.Text = "Start";
            buttonLoad.Enabled = true;
        }

        private void DrawShape(Graphics g, int w, int h)
        {
            // Obtain a random color
            int A = _rnd.Next(0, 256);
            int R = _rnd.Next(0, 256);
            int G = _rnd.Next(0, 256);
            int B = _rnd.Next(0, 256);
            Brush b = new SolidBrush(Color.FromArgb(A, R, G, B));

            // Calculate feature size limits
            int maxW = w;
            int maxH = h;
            if (rb50.Checked) { maxW /= 2; maxH /= 2; }
            if (rb25.Checked) { maxW /= 4; maxH /= 4; }
            if (rb12.Checked) { maxW /= 8; maxH /= 8; }

            // Determine shape
            ShapeType shapeType = ShapeType.Pixel;
            if (rbShapePixel.Checked) shapeType = ShapeType.Pixel;
            if (rbShapeRect.Checked) shapeType = ShapeType.Rectangle;
            if (rbShapeTriangle.Checked) shapeType = ShapeType.Triangle;
            if (rbShapeEllipse.Checked) shapeType = ShapeType.Ellipse;
            if (rbShapeSquare.Checked) shapeType = ShapeType.Square;
            if (rbShapeRandom.Checked)
            {
                Array values = Enum.GetValues(typeof(ShapeType));
                shapeType = (ShapeType)values.GetValue(_rnd.Next(values.Length));
            }

            // Draw the shape
            switch (shapeType)
            {
                case ShapeType.Pixel:

                    {
                        Rectangle rect = new Rectangle(_rnd.Next(0, w), _rnd.Next(0, h), 1, 1);
                        g.FillRectangle(b, rect);
                        _modifiedRect = rect;
                        break;
                    }
                case ShapeType.Triangle:
                    {

                        Point[] points = { new Point(_rnd.Next(0, w), _rnd.Next(0, h)),
                            new Point(_rnd.Next(0, w), _rnd.Next(0, h)),
                            new Point(_rnd.Next(0, w), _rnd.Next(0, h))};
                        g.FillPolygon(b, points);

                        int maxX = Math.Max(points[0].X, Math.Max(points[1].X, points[2].X));
                        int maxY = Math.Max(points[0].Y, Math.Max(points[1].Y, points[2].Y));
                        int minX = Math.Min(points[0].X, Math.Min(points[1].X, points[2].X));
                        int minY = Math.Min(points[0].Y, Math.Min(points[1].Y, points[2].Y));

                        _modifiedRect.X = minX;
                        _modifiedRect.Y = minY;
                        _modifiedRect.Width = maxX - minX;
                        _modifiedRect.Height = maxY - minY;

                        break;
                    }
                case ShapeType.Rectangle:
                    {
                        Rectangle rect = new Rectangle(
                            _rnd.Next(0, w),
                            _rnd.Next(0, h),
                            _rnd.Next(0, maxW),
                            _rnd.Next(0, maxH));
                        g.FillRectangle(b, rect);
                        _modifiedRect = rect;
                        break;
                    }
                case ShapeType.Square:
                    {
                        int size = _rnd.Next(0, Math.Min(maxW, maxH));
                        Rectangle rect = new Rectangle(
                            _rnd.Next(0, w),
                            _rnd.Next(0, h),
                            size,
                            size);
                        g.FillRectangle(b, rect);
                        _modifiedRect = rect;
                        break;
                    }
                case ShapeType.Ellipse:
                    {
                        Rectangle rect = new Rectangle(
                            _rnd.Next(0, w),
                            _rnd.Next(0, h),
                            _rnd.Next(0, maxW),
                            _rnd.Next(0, maxH));
                        g.FillEllipse(b, rect);
                        _modifiedRect = rect;
                        break;
                    }
            }

            // Feature may extend past edges of bitmap, correct the rect here
            if (_modifiedRect.X + _modifiedRect.Width > _bmpOriginal.Width)
                _modifiedRect.Width = _bmpOriginal.Width - _modifiedRect.X;
            if (_modifiedRect.Y + _modifiedRect.Height > _bmpOriginal.Height)
                _modifiedRect.Height = _bmpOriginal.Height - _modifiedRect.Y;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _breakLoop = true;
        }

        private void buttonSelectImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _bmpOriginal = new Bitmap(Image.FromFile(dlg.FileName));

                // Limit image to 250k pixels (FUTURE: Make this customizeable?)
                const int MAX_PIXELS = 250000;
                if (_bmpOriginal.Width * _bmpOriginal.Height > MAX_PIXELS)
                {
                    double newY = Math.Sqrt(MAX_PIXELS / (((double)_bmpOriginal.Width) / _bmpOriginal.Height));
                    double newX = MAX_PIXELS / newY;
                    _bmpOriginal = ResizeImage(_bmpOriginal, (int)newX, (int)newY);
                }

                pictureBoxSource.Image = _bmpOriginal;
                pictureBoxApproximation.Left = pictureBoxSource.Right + pictureBoxSource.Left;

                int margin = pictureBoxSource.Left;
                int totalWidth = pictureBoxSource.Width * 2 + margin * 3;
                int totalHeight = pictureBoxSource.Top + pictureBoxSource.Height + margin;

                if (totalWidth < Screen.FromControl(this).Bounds.Width * 0.8)
                {
                    if (totalWidth < textBoxIterations.Right)
                        this.ClientSize = new Size(textBoxIterations.Right + margin, this.ClientSize.Height);
                    else
                        this.ClientSize = new Size(totalWidth, this.ClientSize.Height);
                }

                if (totalHeight < Screen.FromControl(this).Bounds.Height * 0.8)
                {
                    this.ClientSize = new Size(this.ClientSize.Width, totalHeight);
                }

                Application.DoEvents();
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            _breakLoop = true;
        }

        private void rbShapeTriangle_CheckedChanged(object sender, EventArgs e)
        {
            // Disable feature size options when selecting triangle as these options to not affect triangles
            groupBoxFeatureSize.Enabled = !rbShapeTriangle.Checked;
        }

        // https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp
        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}