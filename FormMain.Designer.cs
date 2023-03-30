namespace ImageApproximater
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            pictureBoxSource = new PictureBox();
            pictureBoxApproximation = new PictureBox();
            buttonStart = new Button();
            labelStatus = new Label();
            groupBox1 = new GroupBox();
            rbShapeSquare = new RadioButton();
            rbShapeRandom = new RadioButton();
            rbShapeEllipse = new RadioButton();
            rbShapeRect = new RadioButton();
            rbShapeTriangle = new RadioButton();
            rbShapePixel = new RadioButton();
            groupBoxFeatureSize = new GroupBox();
            rb12 = new RadioButton();
            rb25 = new RadioButton();
            rb50 = new RadioButton();
            rb100 = new RadioButton();
            groupBox3 = new GroupBox();
            rbUpdateRate25 = new RadioButton();
            rbUpdateRate50 = new RadioButton();
            rbUpdateRate100 = new RadioButton();
            buttonLoad = new Button();
            textBoxIterations = new TextBox();
            label1 = new Label();
            textBoxPixelSkip = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxApproximation).BeginInit();
            groupBox1.SuspendLayout();
            groupBoxFeatureSize.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxSource
            // 
            pictureBoxSource.Location = new Point(9, 163);
            pictureBoxSource.Name = "pictureBoxSource";
            pictureBoxSource.Size = new Size(250, 250);
            pictureBoxSource.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxSource.TabIndex = 0;
            pictureBoxSource.TabStop = false;
            // 
            // pictureBoxApproximation
            // 
            pictureBoxApproximation.Location = new Point(265, 163);
            pictureBoxApproximation.Name = "pictureBoxApproximation";
            pictureBoxApproximation.Size = new Size(250, 250);
            pictureBoxApproximation.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxApproximation.TabIndex = 1;
            pictureBoxApproximation.TabStop = false;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(90, 134);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(171, 138);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(39, 15);
            labelStatus.TabIndex = 3;
            labelStatus.Text = "Ready";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbShapeSquare);
            groupBox1.Controls.Add(rbShapeRandom);
            groupBox1.Controls.Add(rbShapeEllipse);
            groupBox1.Controls.Add(rbShapeRect);
            groupBox1.Controls.Add(rbShapeTriangle);
            groupBox1.Controls.Add(rbShapePixel);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(174, 116);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Shape";
            // 
            // rbShapeSquare
            // 
            rbShapeSquare.AutoSize = true;
            rbShapeSquare.Location = new Point(82, 47);
            rbShapeSquare.Name = "rbShapeSquare";
            rbShapeSquare.Size = new Size(61, 19);
            rbShapeSquare.TabIndex = 5;
            rbShapeSquare.Text = "Square";
            rbShapeSquare.UseVisualStyleBackColor = true;
            // 
            // rbShapeRandom
            // 
            rbShapeRandom.AutoSize = true;
            rbShapeRandom.Checked = true;
            rbShapeRandom.Location = new Point(6, 22);
            rbShapeRandom.Name = "rbShapeRandom";
            rbShapeRandom.Size = new Size(70, 19);
            rbShapeRandom.TabIndex = 4;
            rbShapeRandom.TabStop = true;
            rbShapeRandom.Text = "Random";
            rbShapeRandom.UseVisualStyleBackColor = true;
            // 
            // rbShapeEllipse
            // 
            rbShapeEllipse.AutoSize = true;
            rbShapeEllipse.Location = new Point(82, 71);
            rbShapeEllipse.Name = "rbShapeEllipse";
            rbShapeEllipse.Size = new Size(58, 19);
            rbShapeEllipse.TabIndex = 3;
            rbShapeEllipse.Text = "Ellipse";
            rbShapeEllipse.UseVisualStyleBackColor = true;
            // 
            // rbShapeRect
            // 
            rbShapeRect.AutoSize = true;
            rbShapeRect.Location = new Point(82, 22);
            rbShapeRect.Name = "rbShapeRect";
            rbShapeRect.Size = new Size(77, 19);
            rbShapeRect.TabIndex = 2;
            rbShapeRect.Text = "Rectangle";
            rbShapeRect.UseVisualStyleBackColor = true;
            // 
            // rbShapeTriangle
            // 
            rbShapeTriangle.AutoSize = true;
            rbShapeTriangle.Location = new Point(6, 72);
            rbShapeTriangle.Name = "rbShapeTriangle";
            rbShapeTriangle.Size = new Size(66, 19);
            rbShapeTriangle.TabIndex = 1;
            rbShapeTriangle.Text = "Triangle";
            rbShapeTriangle.UseVisualStyleBackColor = true;
            rbShapeTriangle.CheckedChanged += rbShapeTriangle_CheckedChanged;
            // 
            // rbShapePixel
            // 
            rbShapePixel.AutoSize = true;
            rbShapePixel.Location = new Point(6, 47);
            rbShapePixel.Name = "rbShapePixel";
            rbShapePixel.Size = new Size(50, 19);
            rbShapePixel.TabIndex = 0;
            rbShapePixel.Text = "Pixel";
            rbShapePixel.UseVisualStyleBackColor = true;
            // 
            // groupBoxFeatureSize
            // 
            groupBoxFeatureSize.Controls.Add(rb12);
            groupBoxFeatureSize.Controls.Add(rb25);
            groupBoxFeatureSize.Controls.Add(rb50);
            groupBoxFeatureSize.Controls.Add(rb100);
            groupBoxFeatureSize.Location = new Point(192, 3);
            groupBoxFeatureSize.Name = "groupBoxFeatureSize";
            groupBoxFeatureSize.Size = new Size(117, 125);
            groupBoxFeatureSize.TabIndex = 6;
            groupBoxFeatureSize.TabStop = false;
            groupBoxFeatureSize.Text = "Max feature size";
            // 
            // rb12
            // 
            rb12.AutoSize = true;
            rb12.Checked = true;
            rb12.Location = new Point(6, 97);
            rb12.Name = "rb12";
            rb12.Size = new Size(56, 19);
            rb12.TabIndex = 4;
            rb12.TabStop = true;
            rb12.Text = "12.5%";
            rb12.UseVisualStyleBackColor = true;
            // 
            // rb25
            // 
            rb25.AutoSize = true;
            rb25.Location = new Point(6, 72);
            rb25.Name = "rb25";
            rb25.Size = new Size(47, 19);
            rb25.TabIndex = 3;
            rb25.Text = "25%";
            rb25.UseVisualStyleBackColor = true;
            // 
            // rb50
            // 
            rb50.AutoSize = true;
            rb50.Location = new Point(6, 47);
            rb50.Name = "rb50";
            rb50.Size = new Size(47, 19);
            rb50.TabIndex = 2;
            rb50.Text = "50%";
            rb50.UseVisualStyleBackColor = true;
            // 
            // rb100
            // 
            rb100.AutoSize = true;
            rb100.Location = new Point(6, 22);
            rb100.Name = "rb100";
            rb100.Size = new Size(53, 19);
            rb100.TabIndex = 0;
            rb100.Text = "100%";
            rb100.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rbUpdateRate25);
            groupBox3.Controls.Add(rbUpdateRate50);
            groupBox3.Controls.Add(rbUpdateRate100);
            groupBox3.Location = new Point(315, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(98, 125);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Update every";
            // 
            // rbUpdateRate25
            // 
            rbUpdateRate25.AutoSize = true;
            rbUpdateRate25.Location = new Point(6, 72);
            rbUpdateRate25.Name = "rbUpdateRate25";
            rbUpdateRate25.Size = new Size(56, 19);
            rbUpdateRate25.TabIndex = 3;
            rbUpdateRate25.Text = "25 ms";
            rbUpdateRate25.UseVisualStyleBackColor = true;
            // 
            // rbUpdateRate50
            // 
            rbUpdateRate50.AutoSize = true;
            rbUpdateRate50.Location = new Point(6, 47);
            rbUpdateRate50.Name = "rbUpdateRate50";
            rbUpdateRate50.Size = new Size(56, 19);
            rbUpdateRate50.TabIndex = 2;
            rbUpdateRate50.Text = "50 ms";
            rbUpdateRate50.UseVisualStyleBackColor = true;
            // 
            // rbUpdateRate100
            // 
            rbUpdateRate100.AutoSize = true;
            rbUpdateRate100.Checked = true;
            rbUpdateRate100.Location = new Point(6, 22);
            rbUpdateRate100.Name = "rbUpdateRate100";
            rbUpdateRate100.Size = new Size(62, 19);
            rbUpdateRate100.TabIndex = 0;
            rbUpdateRate100.TabStop = true;
            rbUpdateRate100.Text = "100 ms";
            rbUpdateRate100.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(9, 134);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 23);
            buttonLoad.TabIndex = 8;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonSelectImg_Click;
            // 
            // textBoxIterations
            // 
            textBoxIterations.Location = new Point(419, 30);
            textBoxIterations.Name = "textBoxIterations";
            textBoxIterations.Size = new Size(100, 23);
            textBoxIterations.TabIndex = 9;
            textBoxIterations.Text = "100000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(419, 12);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 10;
            label1.Text = "# of iterations";
            // 
            // textBoxPixelSkip
            // 
            textBoxPixelSkip.Location = new Point(419, 83);
            textBoxPixelSkip.Name = "textBoxPixelSkip";
            textBoxPixelSkip.Size = new Size(100, 23);
            textBoxPixelSkip.TabIndex = 11;
            textBoxPixelSkip.Text = "1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(419, 66);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 12;
            label2.Text = "Pixel Skip";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 423);
            Controls.Add(label2);
            Controls.Add(textBoxPixelSkip);
            Controls.Add(label1);
            Controls.Add(textBoxIterations);
            Controls.Add(buttonLoad);
            Controls.Add(groupBox3);
            Controls.Add(groupBoxFeatureSize);
            Controls.Add(groupBox1);
            Controls.Add(labelStatus);
            Controls.Add(buttonStart);
            Controls.Add(pictureBoxApproximation);
            Controls.Add(pictureBoxSource);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "ImageApproximater";
            FormClosing += FormMain_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBoxSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxApproximation).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxFeatureSize.ResumeLayout(false);
            groupBoxFeatureSize.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxSource;
        private PictureBox pictureBoxApproximation;
        private Button buttonStart;
        private Label labelStatus;
        private GroupBox groupBox1;
        private RadioButton rbShapeEllipse;
        private RadioButton rbShapeRect;
        private RadioButton rbShapeTriangle;
        private RadioButton rbShapePixel;
        private GroupBox groupBoxFeatureSize;
        private RadioButton rb25;
        private RadioButton rb50;
        private RadioButton rb100;
        private RadioButton rb12;
        private GroupBox groupBox3;
        private RadioButton rbUpdateRate25;
        private RadioButton rbUpdateRate50;
        private RadioButton rbUpdateRate100;
        private Button buttonLoad;
        private RadioButton rbShapeRandom;
        private TextBox textBoxIterations;
        private Label label1;
        private TextBox textBoxPixelSkip;
        private Label label2;
        private RadioButton rbShapeSquare;
    }
}