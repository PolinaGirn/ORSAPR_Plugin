
namespace PipeHolder
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.HeightLimitsTextBox = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.ExternalDiameterTextBox = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.PipeDiameterTextBox = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.HolderDiameterTextBox = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.HoleDiameterTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BuildModelButton = new System.Windows.Forms.Button();
            this.SetDefaultButton = new System.Windows.Forms.Button();
            this.HoleDiameterLimitsTextBox = new System.Windows.Forms.TextBox();
            this.HolderDiameterLimitsTextBox = new System.Windows.Forms.TextBox();
            this.PipeDiameterLimitsTextBox = new System.Windows.Forms.TextBox();
            this.ExternalDiameterLimitsTextBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.HeightTextBox.Location = new System.Drawing.Point(148, 12);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.HeightTextBox.TabIndex = 1;
            this.HeightTextBox.Text = "25";
            this.toolTip1.SetToolTip(this.HeightTextBox, "Здачение должно быть от 15 до 40 мм");
            this.HeightTextBox.TextChanged += new System.EventHandler(this.TextBox_ChangeValue);
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(12, 15);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 13);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "Высота H:";
            // 
            // HeightLimitsTextBox
            // 
            this.HeightLimitsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.HeightLimitsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HeightLimitsTextBox.ForeColor = System.Drawing.Color.Gray;
            this.HeightLimitsTextBox.Location = new System.Drawing.Point(12, 38);
            this.HeightLimitsTextBox.Name = "HeightLimitsTextBox";
            this.HeightLimitsTextBox.ReadOnly = true;
            this.HeightLimitsTextBox.Size = new System.Drawing.Size(100, 13);
            this.HeightLimitsTextBox.TabIndex = 4;
            this.HeightLimitsTextBox.Text = "(15-40 мм)";
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(12, 67);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(120, 13);
            this.textBox5.TabIndex = 6;
            this.textBox5.Text = "Внешний диаметр D:";
            // 
            // ExternalDiameterTextBox
            // 
            this.ExternalDiameterTextBox.Location = new System.Drawing.Point(148, 64);
            this.ExternalDiameterTextBox.Name = "ExternalDiameterTextBox";
            this.ExternalDiameterTextBox.Size = new System.Drawing.Size(100, 20);
            this.ExternalDiameterTextBox.TabIndex = 5;
            this.ExternalDiameterTextBox.Text = "30";
            this.ExternalDiameterTextBox.TextChanged += new System.EventHandler(this.TextBox_ChangeValue);
            // 
            // textBox8
            // 
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Location = new System.Drawing.Point(12, 118);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(100, 13);
            this.textBox8.TabIndex = 9;
            this.textBox8.Text = "Диаметр трубы D1:";
            // 
            // PipeDiameterTextBox
            // 
            this.PipeDiameterTextBox.Location = new System.Drawing.Point(148, 115);
            this.PipeDiameterTextBox.Name = "PipeDiameterTextBox";
            this.PipeDiameterTextBox.Size = new System.Drawing.Size(100, 20);
            this.PipeDiameterTextBox.TabIndex = 8;
            this.PipeDiameterTextBox.Text = "20";
            this.PipeDiameterTextBox.TextChanged += new System.EventHandler(this.TextBox_ChangeValue);
            // 
            // textBox11
            // 
            this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox11.Location = new System.Drawing.Point(12, 170);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(130, 13);
            this.textBox11.TabIndex = 12;
            this.textBox11.Text = "Диаметр держателя D2:";
            // 
            // HolderDiameterTextBox
            // 
            this.HolderDiameterTextBox.Location = new System.Drawing.Point(148, 167);
            this.HolderDiameterTextBox.Name = "HolderDiameterTextBox";
            this.HolderDiameterTextBox.Size = new System.Drawing.Size(100, 20);
            this.HolderDiameterTextBox.TabIndex = 11;
            this.HolderDiameterTextBox.Text = "60";
            this.HolderDiameterTextBox.TextChanged += new System.EventHandler(this.TextBox_ChangeValue);
            // 
            // textBox14
            // 
            this.textBox14.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox14.Location = new System.Drawing.Point(12, 222);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(130, 13);
            this.textBox14.TabIndex = 15;
            this.textBox14.Text = "Диаметр отверстия D3:";
            // 
            // HoleDiameterTextBox
            // 
            this.HoleDiameterTextBox.Location = new System.Drawing.Point(148, 219);
            this.HoleDiameterTextBox.Name = "HoleDiameterTextBox";
            this.HoleDiameterTextBox.Size = new System.Drawing.Size(100, 20);
            this.HoleDiameterTextBox.TabIndex = 14;
            this.HoleDiameterTextBox.Text = "6";
            this.HoleDiameterTextBox.TextChanged += new System.EventHandler(this.TextBox_ChangeValue);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(266, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(473, 425);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // BuildModelButton
            // 
            this.BuildModelButton.Location = new System.Drawing.Point(12, 283);
            this.BuildModelButton.Name = "BuildModelButton";
            this.BuildModelButton.Size = new System.Drawing.Size(100, 38);
            this.BuildModelButton.TabIndex = 18;
            this.BuildModelButton.Text = "Построить";
            this.BuildModelButton.UseVisualStyleBackColor = true;
            this.BuildModelButton.Click += new System.EventHandler(this.BuildModelButton_Click);
            // 
            // SetDefaultButton
            // 
            this.SetDefaultButton.Location = new System.Drawing.Point(123, 283);
            this.SetDefaultButton.Name = "SetDefaultButton";
            this.SetDefaultButton.Size = new System.Drawing.Size(125, 38);
            this.SetDefaultButton.TabIndex = 19;
            this.SetDefaultButton.Text = "Установить значения по умолчанию";
            this.toolTip1.SetToolTip(this.SetDefaultButton, "Здачение должно быть от 15 до 40 мм");
            this.SetDefaultButton.UseVisualStyleBackColor = true;
            this.SetDefaultButton.Click += new System.EventHandler(this.SetDefaultButton_Click);
            // 
            // HoleDiameterLimitsTextBox
            // 
            this.HoleDiameterLimitsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.HoleDiameterLimitsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HoleDiameterLimitsTextBox.ForeColor = System.Drawing.Color.Gray;
            this.HoleDiameterLimitsTextBox.Location = new System.Drawing.Point(12, 241);
            this.HoleDiameterLimitsTextBox.Name = "HoleDiameterLimitsTextBox";
            this.HoleDiameterLimitsTextBox.ReadOnly = true;
            this.HoleDiameterLimitsTextBox.Size = new System.Drawing.Size(100, 13);
            this.HoleDiameterLimitsTextBox.TabIndex = 20;
            this.HoleDiameterLimitsTextBox.Text = "(4-7,5 мм)";
            // 
            // HolderDiameterLimitsTextBox
            // 
            this.HolderDiameterLimitsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.HolderDiameterLimitsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HolderDiameterLimitsTextBox.ForeColor = System.Drawing.Color.Gray;
            this.HolderDiameterLimitsTextBox.Location = new System.Drawing.Point(12, 189);
            this.HolderDiameterLimitsTextBox.Name = "HolderDiameterLimitsTextBox";
            this.HolderDiameterLimitsTextBox.ReadOnly = true;
            this.HolderDiameterLimitsTextBox.Size = new System.Drawing.Size(100, 13);
            this.HolderDiameterLimitsTextBox.TabIndex = 21;
            this.HolderDiameterLimitsTextBox.Text = "(45-90 мм)";
            // 
            // PipeDiameterLimitsTextBox
            // 
            this.PipeDiameterLimitsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.PipeDiameterLimitsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PipeDiameterLimitsTextBox.ForeColor = System.Drawing.Color.Gray;
            this.PipeDiameterLimitsTextBox.Location = new System.Drawing.Point(12, 137);
            this.PipeDiameterLimitsTextBox.Name = "PipeDiameterLimitsTextBox";
            this.PipeDiameterLimitsTextBox.ReadOnly = true;
            this.PipeDiameterLimitsTextBox.Size = new System.Drawing.Size(100, 13);
            this.PipeDiameterLimitsTextBox.TabIndex = 22;
            this.PipeDiameterLimitsTextBox.Text = "(10-27,5 мм)";
            // 
            // ExternalDiameterLimitsTextBox
            // 
            this.ExternalDiameterLimitsTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.ExternalDiameterLimitsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ExternalDiameterLimitsTextBox.ForeColor = System.Drawing.Color.Gray;
            this.ExternalDiameterLimitsTextBox.Location = new System.Drawing.Point(12, 86);
            this.ExternalDiameterLimitsTextBox.Name = "ExternalDiameterLimitsTextBox";
            this.ExternalDiameterLimitsTextBox.ReadOnly = true;
            this.ExternalDiameterLimitsTextBox.Size = new System.Drawing.Size(100, 13);
            this.ExternalDiameterLimitsTextBox.TabIndex = 23;
            this.ExternalDiameterLimitsTextBox.Text = "(20-30 мм)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 450);
            this.Controls.Add(this.ExternalDiameterLimitsTextBox);
            this.Controls.Add(this.PipeDiameterLimitsTextBox);
            this.Controls.Add(this.HolderDiameterLimitsTextBox);
            this.Controls.Add(this.HoleDiameterLimitsTextBox);
            this.Controls.Add(this.SetDefaultButton);
            this.Controls.Add(this.BuildModelButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.HoleDiameterTextBox);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.HolderDiameterTextBox);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.PipeDiameterTextBox);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.ExternalDiameterTextBox);
            this.Controls.Add(this.HeightLimitsTextBox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.HeightTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(767, 489);
            this.MinimumSize = new System.Drawing.Size(767, 489);
            this.Name = "MainForm";
            this.Text = "Pipe Holder";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox HeightLimitsTextBox;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox ExternalDiameterTextBox;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox PipeDiameterTextBox;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox HolderDiameterTextBox;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox HoleDiameterTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BuildModelButton;
        private System.Windows.Forms.Button SetDefaultButton;
        private System.Windows.Forms.TextBox HoleDiameterLimitsTextBox;
        private System.Windows.Forms.TextBox HolderDiameterLimitsTextBox;
        private System.Windows.Forms.TextBox PipeDiameterLimitsTextBox;
        private System.Windows.Forms.TextBox ExternalDiameterLimitsTextBox;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

