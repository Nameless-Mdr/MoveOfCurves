using System.Windows.Forms;

namespace GumerovLab3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            this.Points = new System.Windows.Forms.Button();
            this.ParamsBut = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Moves = new System.Windows.Forms.Button();
            this.Painted = new System.Windows.Forms.Button();
            this.Beziers = new System.Windows.Forms.Button();
            this.Curve = new System.Windows.Forms.Button();
            this.Polyline = new System.Windows.Forms.Button();
            this.TextCursore = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Points
            // 
            this.Points.BackColor = System.Drawing.Color.Red;
            this.Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Points.Location = new System.Drawing.Point(12, 12);
            this.Points.Name = "Points";
            this.Points.Size = new System.Drawing.Size(85, 40);
            this.Points.TabIndex = 0;
            this.Points.Text = "Точки";
            this.Points.UseVisualStyleBackColor = false;
            this.Points.Click += new System.EventHandler(this.Points_Click);
            // 
            // ParamsBut
            // 
            this.ParamsBut.BackColor = System.Drawing.Color.Red;
            this.ParamsBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParamsBut.Location = new System.Drawing.Point(12, 68);
            this.ParamsBut.Name = "ParamsBut";
            this.ParamsBut.Size = new System.Drawing.Size(85, 40);
            this.ParamsBut.TabIndex = 1;
            this.ParamsBut.Text = "Параметры";
            this.ParamsBut.UseVisualStyleBackColor = false;
            this.ParamsBut.Click += new System.EventHandler(this.Params_Click);
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.Red;
            this.Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Clear.Location = new System.Drawing.Point(12, 403);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(85, 40);
            this.Clear.TabIndex = 3;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Moves
            // 
            this.Moves.BackColor = System.Drawing.Color.Red;
            this.Moves.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Moves.Location = new System.Drawing.Point(12, 347);
            this.Moves.Name = "Moves";
            this.Moves.Size = new System.Drawing.Size(85, 40);
            this.Moves.TabIndex = 2;
            this.Moves.Text = "Движение";
            this.Moves.UseVisualStyleBackColor = false;
            this.Moves.Click += new System.EventHandler(this.Moves_Click);
            // 
            // Painted
            // 
            this.Painted.BackColor = System.Drawing.Color.Red;
            this.Painted.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Painted.Location = new System.Drawing.Point(12, 290);
            this.Painted.Name = "Painted";
            this.Painted.Size = new System.Drawing.Size(85, 40);
            this.Painted.TabIndex = 7;
            this.Painted.Text = "Закрашенная";
            this.Painted.UseVisualStyleBackColor = false;
            this.Painted.Click += new System.EventHandler(this.Painted_Click);
            // 
            // Beziers
            // 
            this.Beziers.BackColor = System.Drawing.Color.Red;
            this.Beziers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Beziers.Location = new System.Drawing.Point(12, 235);
            this.Beziers.Name = "Beziers";
            this.Beziers.Size = new System.Drawing.Size(85, 40);
            this.Beziers.TabIndex = 6;
            this.Beziers.Text = "Безье";
            this.Beziers.UseVisualStyleBackColor = false;
            this.Beziers.Click += new System.EventHandler(this.Beziers_Click);
            // 
            // Curve
            // 
            this.Curve.BackColor = System.Drawing.Color.Red;
            this.Curve.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Curve.Location = new System.Drawing.Point(12, 180);
            this.Curve.Name = "Curve";
            this.Curve.Size = new System.Drawing.Size(85, 40);
            this.Curve.TabIndex = 5;
            this.Curve.Text = "Кривая";
            this.Curve.UseVisualStyleBackColor = false;
            this.Curve.Click += new System.EventHandler(this.Curve_Click);
            // 
            // Polyline
            // 
            this.Polyline.BackColor = System.Drawing.Color.Red;
            this.Polyline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Polyline.Location = new System.Drawing.Point(12, 124);
            this.Polyline.Name = "Polyline";
            this.Polyline.Size = new System.Drawing.Size(85, 40);
            this.Polyline.TabIndex = 4;
            this.Polyline.Text = "Ломанная";
            this.Polyline.UseVisualStyleBackColor = false;
            this.Polyline.Click += new System.EventHandler(this.Polyline_Click);
            // 
            // TextCursore
            // 
            this.TextCursore.Location = new System.Drawing.Point(12, 463);
            this.TextCursore.Name = "TextCursore";
            this.TextCursore.Size = new System.Drawing.Size(85, 20);
            this.TextCursore.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1049, 627);
            this.Controls.Add(this.TextCursore);
            this.Controls.Add(this.Painted);
            this.Controls.Add(this.Beziers);
            this.Controls.Add(this.Curve);
            this.Controls.Add(this.Polyline);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Moves);
            this.Controls.Add(this.ParamsBut);
            this.Controls.Add(this.Points);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox TextCursore;

        private System.Windows.Forms.Button Painted;
        private System.Windows.Forms.Button Points;
        private System.Windows.Forms.Button ParamsBut;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Moves;
        private System.Windows.Forms.Button Beziers;
        private System.Windows.Forms.Button Curve;
        private System.Windows.Forms.Button Polyline;

        #endregion
    }
}