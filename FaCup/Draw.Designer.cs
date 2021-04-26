
namespace FaCup
{
    partial class Draw
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
            this.lblFaCup = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtTeamList = new System.Windows.Forms.TextBox();
            this.btnShuffle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFaCup
            // 
            this.lblFaCup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFaCup.AutoSize = true;
            this.lblFaCup.BackColor = System.Drawing.Color.Transparent;
            this.lblFaCup.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFaCup.Font = new System.Drawing.Font("Open Sans SemiBold", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaCup.ForeColor = System.Drawing.SystemColors.Control;
            this.lblFaCup.Location = new System.Drawing.Point(890, 9);
            this.lblFaCup.Name = "lblFaCup";
            this.lblFaCup.Size = new System.Drawing.Size(385, 131);
            this.lblFaCup.TabIndex = 1;
            this.lblFaCup.Text = "FA CUP";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(136, 116);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 702);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // txtTeamList
            // 
            this.txtTeamList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTeamList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTeamList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeamList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTeamList.Location = new System.Drawing.Point(144, 123);
            this.txtTeamList.Multiline = true;
            this.txtTeamList.Name = "txtTeamList";
            this.txtTeamList.ReadOnly = true;
            this.txtTeamList.Size = new System.Drawing.Size(248, 688);
            this.txtTeamList.TabIndex = 3;
            // 
            // btnShuffle
            // 
            this.btnShuffle.BackColor = System.Drawing.Color.White;
            this.btnShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShuffle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShuffle.ForeColor = System.Drawing.Color.DimGray;
            this.btnShuffle.Location = new System.Drawing.Point(195, 829);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(153, 43);
            this.btnShuffle.TabIndex = 4;
            this.btnShuffle.Text = "SHUFFLE";
            this.btnShuffle.UseVisualStyleBackColor = false;
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
            // 
            // Draw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 1011);
            this.Controls.Add(this.btnShuffle);
            this.Controls.Add(this.txtTeamList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblFaCup);
            this.Name = "Draw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fourth Round Draw";
            this.Load += new System.EventHandler(this.Draw_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFaCup;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTeamList;
        private System.Windows.Forms.Button btnShuffle;
    }
}