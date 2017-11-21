namespace Chess
{
    partial class Form1
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
            this.pnlMatrica = new System.Windows.Forms.Panel();
            this.pbx3 = new System.Windows.Forms.PictureBox();
            this.pbx2 = new System.Windows.Forms.PictureBox();
            this.pbx1 = new System.Windows.Forms.PictureBox();
            this.btnPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbx3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMatrica
            // 
            this.pnlMatrica.AllowDrop = true;
            this.pnlMatrica.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlMatrica.Location = new System.Drawing.Point(224, 70);
            this.pnlMatrica.MaximumSize = new System.Drawing.Size(400, 400);
            this.pnlMatrica.MinimumSize = new System.Drawing.Size(400, 400);
            this.pnlMatrica.Name = "pnlMatrica";
            this.pnlMatrica.Size = new System.Drawing.Size(400, 400);
            this.pnlMatrica.TabIndex = 0;
            // 
            // pbx3
            // 
            this.pbx3.Image = global::Chess.Properties.Resources.crown_1;
            this.pbx3.Location = new System.Drawing.Point(81, 213);
            this.pbx3.Name = "pbx3";
            this.pbx3.Size = new System.Drawing.Size(40, 40);
            this.pbx3.TabIndex = 3;
            this.pbx3.TabStop = false;
            this.pbx3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbx3_MouseDown);
            // 
            // pbx2
            // 
            this.pbx2.Image = global::Chess.Properties.Resources.rook;
            this.pbx2.Location = new System.Drawing.Point(81, 152);
            this.pbx2.Name = "pbx2";
            this.pbx2.Size = new System.Drawing.Size(40, 40);
            this.pbx2.TabIndex = 2;
            this.pbx2.TabStop = false;
            this.pbx2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbx2_MouseDown);
            // 
            // pbx1
            // 
            this.pbx1.Image = global::Chess.Properties.Resources.crown_2;
            this.pbx1.Location = new System.Drawing.Point(81, 91);
            this.pbx1.Name = "pbx1";
            this.pbx1.Size = new System.Drawing.Size(40, 40);
            this.pbx1.TabIndex = 1;
            this.pbx1.TabStop = false;
            this.pbx1.Tag = "Kralj";
            this.pbx1.DragEnter += new System.Windows.Forms.DragEventHandler(this.btn_DragEnter);
            this.pbx1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbx1_MouseDown);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(61, 335);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 484);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.pbx3);
            this.Controls.Add(this.pbx2);
            this.Controls.Add(this.pbx1);
            this.Controls.Add(this.pnlMatrica);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbx3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMatrica;
        private System.Windows.Forms.PictureBox pbx1;
        private System.Windows.Forms.PictureBox pbx2;
        private System.Windows.Forms.PictureBox pbx3;
        private System.Windows.Forms.Button btnPlay;
    }
}

