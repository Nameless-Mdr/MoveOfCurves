using System.ComponentModel;

namespace GumerovLab3
{
    partial class Params
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Params));
            this.CancelP = new System.Windows.Forms.Button();
            this.OkP = new System.Windows.Forms.Button();
            this.ImageP = new System.Windows.Forms.PictureBox();
            this.ImageS = new System.Windows.Forms.PictureBox();
            this.textP = new System.Windows.Forms.TextBox();
            this.textS = new System.Windows.Forms.TextBox();
            this.OkS = new System.Windows.Forms.Button();
            this.CancelS = new System.Windows.Forms.Button();
            this.ResetColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImageP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageS)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelP
            // 
            this.CancelP.Location = new System.Drawing.Point(48, 301);
            this.CancelP.Name = "CancelP";
            this.CancelP.Size = new System.Drawing.Size(120, 25);
            this.CancelP.TabIndex = 0;
            this.CancelP.Text = "Отмена";
            this.CancelP.UseVisualStyleBackColor = true;
            this.CancelP.Click += new System.EventHandler(this.CancelP_Click);
            // 
            // OkP
            // 
            this.OkP.Location = new System.Drawing.Point(48, 270);
            this.OkP.Name = "OkP";
            this.OkP.Size = new System.Drawing.Size(120, 25);
            this.OkP.TabIndex = 1;
            this.OkP.Text = "Ок";
            this.OkP.UseVisualStyleBackColor = true;
            this.OkP.Click += new System.EventHandler(this.OkP_Click);
            // 
            // ImageP
            // 
            this.ImageP.Image = ((System.Drawing.Image)(resources.GetObject("ImageP.Image")));
            this.ImageP.Location = new System.Drawing.Point(8, 40);
            this.ImageP.Name = "ImageP";
            this.ImageP.Size = new System.Drawing.Size(200, 200);
            this.ImageP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageP.TabIndex = 2;
            this.ImageP.TabStop = false;
            // 
            // ImageS
            // 
            this.ImageS.Image = ((System.Drawing.Image)(resources.GetObject("ImageS.Image")));
            this.ImageS.Location = new System.Drawing.Point(332, 40);
            this.ImageS.Name = "ImageS";
            this.ImageS.Size = new System.Drawing.Size(200, 200);
            this.ImageS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageS.TabIndex = 3;
            this.ImageS.TabStop = false;
            // 
            // textP
            // 
            this.textP.BackColor = System.Drawing.SystemColors.Control;
            this.textP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textP.Location = new System.Drawing.Point(48, 11);
            this.textP.Name = "textP";
            this.textP.Size = new System.Drawing.Size(141, 24);
            this.textP.TabIndex = 4;
            this.textP.Text = "Цвет точки";
            // 
            // textS
            // 
            this.textS.BackColor = System.Drawing.SystemColors.Control;
            this.textS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textS.Location = new System.Drawing.Point(366, 11);
            this.textS.Name = "textS";
            this.textS.Size = new System.Drawing.Size(141, 24);
            this.textS.TabIndex = 5;
            this.textS.Text = "Цвет линии";
            // 
            // OkS
            // 
            this.OkS.Location = new System.Drawing.Point(366, 270);
            this.OkS.Name = "OkS";
            this.OkS.Size = new System.Drawing.Size(120, 25);
            this.OkS.TabIndex = 8;
            this.OkS.Text = "Ок";
            this.OkS.UseVisualStyleBackColor = true;
            this.OkS.Click += new System.EventHandler(this.OkS_Click);
            // 
            // CancelS
            // 
            this.CancelS.Location = new System.Drawing.Point(366, 301);
            this.CancelS.Name = "CancelS";
            this.CancelS.Size = new System.Drawing.Size(120, 25);
            this.CancelS.TabIndex = 7;
            this.CancelS.Text = "Отмена";
            this.CancelS.UseVisualStyleBackColor = true;
            this.CancelS.Click += new System.EventHandler(this.CancelS_Click);
            // 
            // ResetColor
            // 
            this.ResetColor.Location = new System.Drawing.Point(206, 301);
            this.ResetColor.Name = "ResetColor";
            this.ResetColor.Size = new System.Drawing.Size(120, 25);
            this.ResetColor.TabIndex = 9;
            this.ResetColor.Text = "По умолчанию";
            this.ResetColor.UseVisualStyleBackColor = true;
            this.ResetColor.Click += new System.EventHandler(this.ResetColor_Click);
            // 
            // Params
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 340);
            this.ControlBox = false;
            this.Controls.Add(this.ResetColor);
            this.Controls.Add(this.OkS);
            this.Controls.Add(this.CancelS);
            this.Controls.Add(this.textS);
            this.Controls.Add(this.textP);
            this.Controls.Add(this.ImageS);
            this.Controls.Add(this.ImageP);
            this.Controls.Add(this.OkP);
            this.Controls.Add(this.CancelP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Params";
            this.Text = "Параметры";
            ((System.ComponentModel.ISupportInitialize)(this.ImageP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button ResetColor;

        private System.Windows.Forms.Button OkS;
        private System.Windows.Forms.Button CancelS;

        private System.Windows.Forms.TextBox textS;

        private System.Windows.Forms.TextBox textP;

        private System.Windows.Forms.PictureBox ImageS;

        private System.Windows.Forms.PictureBox ImageP;

        private System.Windows.Forms.Button OkP;

        private System.Windows.Forms.Button CancelP;

        #endregion
    }
}