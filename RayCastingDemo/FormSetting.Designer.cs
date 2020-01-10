namespace RayCastingDemo
{
    partial class FormSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_NumberOfRays = new System.Windows.Forms.Label();
            this.numericUpDown_NumberOfRays = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_RayBrightness = new System.Windows.Forms.NumericUpDown();
            this.label_RayBrightness = new System.Windows.Forms.Label();
            this.numericUpDown_RayThickness = new System.Windows.Forms.NumericUpDown();
            this.label_RayThickness = new System.Windows.Forms.Label();
            this.label_RayColor = new System.Windows.Forms.Label();
            this.button_RayColor = new System.Windows.Forms.Button();
            this.button_BackgroundColor = new System.Windows.Forms.Button();
            this.label_BackgroundColor = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_NumberOfRays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RayBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RayThickness)).BeginInit();
            this.SuspendLayout();
            // 
            // label_NumberOfRays
            // 
            this.label_NumberOfRays.AutoSize = true;
            this.label_NumberOfRays.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NumberOfRays.Location = new System.Drawing.Point(33, 140);
            this.label_NumberOfRays.Name = "label_NumberOfRays";
            this.label_NumberOfRays.Size = new System.Drawing.Size(160, 23);
            this.label_NumberOfRays.TabIndex = 0;
            this.label_NumberOfRays.Text = "Number of rays";
            // 
            // numericUpDown_NumberOfRays
            // 
            this.numericUpDown_NumberOfRays.Font = new System.Drawing.Font("Bookman Old Style", 12F);
            this.numericUpDown_NumberOfRays.Location = new System.Drawing.Point(235, 140);
            this.numericUpDown_NumberOfRays.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown_NumberOfRays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_NumberOfRays.Name = "numericUpDown_NumberOfRays";
            this.numericUpDown_NumberOfRays.Size = new System.Drawing.Size(249, 31);
            this.numericUpDown_NumberOfRays.TabIndex = 1;
            this.numericUpDown_NumberOfRays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_RayBrightness
            // 
            this.numericUpDown_RayBrightness.Font = new System.Drawing.Font("Bookman Old Style", 12F);
            this.numericUpDown_RayBrightness.Location = new System.Drawing.Point(235, 200);
            this.numericUpDown_RayBrightness.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_RayBrightness.Name = "numericUpDown_RayBrightness";
            this.numericUpDown_RayBrightness.Size = new System.Drawing.Size(249, 31);
            this.numericUpDown_RayBrightness.TabIndex = 3;
            // 
            // label_RayBrightness
            // 
            this.label_RayBrightness.AutoSize = true;
            this.label_RayBrightness.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RayBrightness.Location = new System.Drawing.Point(33, 200);
            this.label_RayBrightness.Name = "label_RayBrightness";
            this.label_RayBrightness.Size = new System.Drawing.Size(156, 23);
            this.label_RayBrightness.TabIndex = 2;
            this.label_RayBrightness.Text = "Ray brightness";
            // 
            // numericUpDown_RayThickness
            // 
            this.numericUpDown_RayThickness.Font = new System.Drawing.Font("Bookman Old Style", 12F);
            this.numericUpDown_RayThickness.Location = new System.Drawing.Point(235, 260);
            this.numericUpDown_RayThickness.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_RayThickness.Name = "numericUpDown_RayThickness";
            this.numericUpDown_RayThickness.Size = new System.Drawing.Size(249, 31);
            this.numericUpDown_RayThickness.TabIndex = 5;
            // 
            // label_RayThickness
            // 
            this.label_RayThickness.AutoSize = true;
            this.label_RayThickness.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RayThickness.Location = new System.Drawing.Point(33, 260);
            this.label_RayThickness.Name = "label_RayThickness";
            this.label_RayThickness.Size = new System.Drawing.Size(146, 23);
            this.label_RayThickness.TabIndex = 4;
            this.label_RayThickness.Text = "Ray thickness";
            // 
            // label_RayColor
            // 
            this.label_RayColor.AutoSize = true;
            this.label_RayColor.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RayColor.Location = new System.Drawing.Point(33, 320);
            this.label_RayColor.Name = "label_RayColor";
            this.label_RayColor.Size = new System.Drawing.Size(100, 23);
            this.label_RayColor.TabIndex = 6;
            this.label_RayColor.Text = "Ray color";
            // 
            // button_RayColor
            // 
            this.button_RayColor.Font = new System.Drawing.Font("Bookman Old Style", 12F);
            this.button_RayColor.Location = new System.Drawing.Point(235, 320);
            this.button_RayColor.Name = "button_RayColor";
            this.button_RayColor.Size = new System.Drawing.Size(249, 31);
            this.button_RayColor.TabIndex = 7;
            this.button_RayColor.Text = "Change...";
            this.button_RayColor.UseVisualStyleBackColor = true;
            this.button_RayColor.Click += new System.EventHandler(this.button_RayColor_Click);
            // 
            // button_BackgroundColor
            // 
            this.button_BackgroundColor.Font = new System.Drawing.Font("Bookman Old Style", 12F);
            this.button_BackgroundColor.Location = new System.Drawing.Point(235, 400);
            this.button_BackgroundColor.Name = "button_BackgroundColor";
            this.button_BackgroundColor.Size = new System.Drawing.Size(249, 31);
            this.button_BackgroundColor.TabIndex = 9;
            this.button_BackgroundColor.Text = "Change...";
            this.button_BackgroundColor.UseVisualStyleBackColor = true;
            this.button_BackgroundColor.Click += new System.EventHandler(this.button_BackgroundColor_Click);
            // 
            // label_BackgroundColor
            // 
            this.label_BackgroundColor.AutoSize = true;
            this.label_BackgroundColor.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_BackgroundColor.Location = new System.Drawing.Point(33, 400);
            this.label_BackgroundColor.Name = "label_BackgroundColor";
            this.label_BackgroundColor.Size = new System.Drawing.Size(182, 23);
            this.label_BackgroundColor.TabIndex = 8;
            this.label_BackgroundColor.Text = "Background color";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Font = new System.Drawing.Font("Bookman Old Style", 12F);
            this.buttonOK.Location = new System.Drawing.Point(364, 520);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(120, 30);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Bookman Old Style", 12F);
            this.buttonCancel.Location = new System.Drawing.Point(235, 520);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 30);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 562);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.button_BackgroundColor);
            this.Controls.Add(this.label_BackgroundColor);
            this.Controls.Add(this.button_RayColor);
            this.Controls.Add(this.label_RayColor);
            this.Controls.Add(this.numericUpDown_RayThickness);
            this.Controls.Add(this.label_RayThickness);
            this.Controls.Add(this.numericUpDown_RayBrightness);
            this.Controls.Add(this.label_RayBrightness);
            this.Controls.Add(this.numericUpDown_NumberOfRays);
            this.Controls.Add(this.label_NumberOfRays);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetting";
            this.Text = "Setting";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_NumberOfRays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RayBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RayThickness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_NumberOfRays;
        private System.Windows.Forms.NumericUpDown numericUpDown_NumberOfRays;
        private System.Windows.Forms.NumericUpDown numericUpDown_RayBrightness;
        private System.Windows.Forms.Label label_RayBrightness;
        private System.Windows.Forms.NumericUpDown numericUpDown_RayThickness;
        private System.Windows.Forms.Label label_RayThickness;
        private System.Windows.Forms.Label label_RayColor;
        private System.Windows.Forms.Button button_RayColor;
        private System.Windows.Forms.Button button_BackgroundColor;
        private System.Windows.Forms.Label label_BackgroundColor;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}