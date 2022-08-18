namespace NewtonFractal {
    partial class NewtonFractalForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.complexPlaneCoordinatesLabel = new System.Windows.Forms.Label();
            this.mouseCoordinatesLabel = new System.Windows.Forms.Label();
            this.colouringMethodComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.displayNewtonFractalButton = new System.Windows.Forms.Button();
            this.newtonFractalPictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.polynomialTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DecreaseComplexPlaneRadiusButton = new System.Windows.Forms.Button();
            this.IncreaseComplexPlaneRadiusButton = new System.Windows.Forms.Button();
            this.complexPlaneRadiusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.newtonFractalPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // complexPlaneCoordinatesLabel
            // 
            this.complexPlaneCoordinatesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.complexPlaneCoordinatesLabel.Location = new System.Drawing.Point(811, 766);
            this.complexPlaneCoordinatesLabel.Name = "complexPlaneCoordinatesLabel";
            this.complexPlaneCoordinatesLabel.Size = new System.Drawing.Size(200, 17);
            this.complexPlaneCoordinatesLabel.TabIndex = 15;
            this.complexPlaneCoordinatesLabel.Text = "(x, y)";
            this.complexPlaneCoordinatesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mouseCoordinatesLabel
            // 
            this.mouseCoordinatesLabel.AutoEllipsis = true;
            this.mouseCoordinatesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mouseCoordinatesLabel.Location = new System.Drawing.Point(811, 719);
            this.mouseCoordinatesLabel.Name = "mouseCoordinatesLabel";
            this.mouseCoordinatesLabel.Size = new System.Drawing.Size(200, 17);
            this.mouseCoordinatesLabel.TabIndex = 14;
            this.mouseCoordinatesLabel.Text = "(x, y)";
            this.mouseCoordinatesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colouringMethodComboBox
            // 
            this.colouringMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colouringMethodComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colouringMethodComboBox.FormattingEnabled = true;
            this.colouringMethodComboBox.Items.AddRange(new object[] {
            "Wavelength Partitioning",
            "Hue Partitioning",
            "Iteration Count"});
            this.colouringMethodComboBox.Location = new System.Drawing.Point(827, 163);
            this.colouringMethodComboBox.Name = "colouringMethodComboBox";
            this.colouringMethodComboBox.Size = new System.Drawing.Size(172, 24);
            this.colouringMethodComboBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(859, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Colouring Method";
            // 
            // displayNewtonFractalButton
            // 
            this.displayNewtonFractalButton.Location = new System.Drawing.Point(821, 72);
            this.displayNewtonFractalButton.Name = "displayNewtonFractalButton";
            this.displayNewtonFractalButton.Size = new System.Drawing.Size(187, 45);
            this.displayNewtonFractalButton.TabIndex = 9;
            this.displayNewtonFractalButton.Text = "Display Newton Fractal";
            this.displayNewtonFractalButton.UseVisualStyleBackColor = true;
            this.displayNewtonFractalButton.Click += new System.EventHandler(this.displayNewtonFractalButton_Click);
            // 
            // newtonFractalPictureBox
            // 
            this.newtonFractalPictureBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.newtonFractalPictureBox.Location = new System.Drawing.Point(0, 0);
            this.newtonFractalPictureBox.Name = "newtonFractalPictureBox";
            this.newtonFractalPictureBox.Size = new System.Drawing.Size(800, 800);
            this.newtonFractalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.newtonFractalPictureBox.TabIndex = 8;
            this.newtonFractalPictureBox.TabStop = false;
            this.newtonFractalPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.newtonFractalPictureBox_Paint);
            this.newtonFractalPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.newtonFractalPictureBox_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(845, 702);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Mouse Co-ordinates";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(818, 749);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Complex Plane Co-ordinates";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // polynomialTextbox
            // 
            this.polynomialTextbox.Location = new System.Drawing.Point(829, 33);
            this.polynomialTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.polynomialTextbox.Name = "polynomialTextbox";
            this.polynomialTextbox.Size = new System.Drawing.Size(172, 20);
            this.polynomialTextbox.TabIndex = 18;
            this.polynomialTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(877, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Polynomial";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(839, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Complex Plane Radius";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DecreaseComplexPlaneRadiusButton
            // 
            this.DecreaseComplexPlaneRadiusButton.Location = new System.Drawing.Point(839, 232);
            this.DecreaseComplexPlaneRadiusButton.Name = "DecreaseComplexPlaneRadiusButton";
            this.DecreaseComplexPlaneRadiusButton.Size = new System.Drawing.Size(17, 23);
            this.DecreaseComplexPlaneRadiusButton.TabIndex = 22;
            this.DecreaseComplexPlaneRadiusButton.Text = "-";
            this.DecreaseComplexPlaneRadiusButton.UseVisualStyleBackColor = true;
            this.DecreaseComplexPlaneRadiusButton.Click += new System.EventHandler(this.DecreaseComplexPlaneRadiusButton_Click);
            // 
            // IncreaseComplexPlaneRadiusButton
            // 
            this.IncreaseComplexPlaneRadiusButton.Location = new System.Drawing.Point(966, 232);
            this.IncreaseComplexPlaneRadiusButton.Name = "IncreaseComplexPlaneRadiusButton";
            this.IncreaseComplexPlaneRadiusButton.Size = new System.Drawing.Size(19, 23);
            this.IncreaseComplexPlaneRadiusButton.TabIndex = 23;
            this.IncreaseComplexPlaneRadiusButton.Text = "+";
            this.IncreaseComplexPlaneRadiusButton.UseVisualStyleBackColor = true;
            this.IncreaseComplexPlaneRadiusButton.Click += new System.EventHandler(this.IncreaseComplexPlaneRadiusButton_Click);
            // 
            // complexPlaneRadiusLabel
            // 
            this.complexPlaneRadiusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.complexPlaneRadiusLabel.Location = new System.Drawing.Point(862, 232);
            this.complexPlaneRadiusLabel.Name = "complexPlaneRadiusLabel";
            this.complexPlaneRadiusLabel.Size = new System.Drawing.Size(99, 23);
            this.complexPlaneRadiusLabel.TabIndex = 24;
            this.complexPlaneRadiusLabel.Text = "[Radius]";
            this.complexPlaneRadiusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NewtonFractalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 798);
            this.Controls.Add(this.complexPlaneRadiusLabel);
            this.Controls.Add(this.IncreaseComplexPlaneRadiusButton);
            this.Controls.Add(this.DecreaseComplexPlaneRadiusButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.polynomialTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.complexPlaneCoordinatesLabel);
            this.Controls.Add(this.mouseCoordinatesLabel);
            this.Controls.Add(this.colouringMethodComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.displayNewtonFractalButton);
            this.Controls.Add(this.newtonFractalPictureBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NewtonFractalForm";
            this.Text = "Newton Fractal";
            ((System.ComponentModel.ISupportInitialize)(this.newtonFractalPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label complexPlaneCoordinatesLabel;
        private System.Windows.Forms.Label mouseCoordinatesLabel;
        private System.Windows.Forms.ComboBox colouringMethodComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button displayNewtonFractalButton;
        private System.Windows.Forms.PictureBox newtonFractalPictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox polynomialTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button DecreaseComplexPlaneRadiusButton;
        private System.Windows.Forms.Button IncreaseComplexPlaneRadiusButton;
        private System.Windows.Forms.Label complexPlaneRadiusLabel;
    }
}

