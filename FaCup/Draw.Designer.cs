
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
            this.lblTeam1 = new System.Windows.Forms.Label();
            this.btnDrawTeams = new System.Windows.Forms.Button();
            this.lblTeam2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.btnShuffle.Text = "LOAD TEAMS";
            this.btnShuffle.UseVisualStyleBackColor = false;
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
            // 
            // lblTeam1
            // 
            this.lblTeam1.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTeam1.Location = new System.Drawing.Point(714, 243);
            this.lblTeam1.Name = "lblTeam1";
            this.lblTeam1.Size = new System.Drawing.Size(332, 41);
            this.lblTeam1.TabIndex = 5;
            this.lblTeam1.Tag = "LabelTeams";
            this.lblTeam1.Text = "WOLVERHAMPTON WONDERERS";
            this.lblTeam1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDrawTeams
            // 
            this.btnDrawTeams.Location = new System.Drawing.Point(1039, 843);
            this.btnDrawTeams.Name = "btnDrawTeams";
            this.btnDrawTeams.Size = new System.Drawing.Size(75, 23);
            this.btnDrawTeams.TabIndex = 6;
            this.btnDrawTeams.Text = "Draw Teams";
            this.btnDrawTeams.UseVisualStyleBackColor = true;
            this.btnDrawTeams.Click += new System.EventHandler(this.btnDrawTeams_Click);
            // 
            // lblTeam2
            // 
            this.lblTeam2.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTeam2.Location = new System.Drawing.Point(1090, 243);
            this.lblTeam2.Name = "lblTeam2";
            this.lblTeam2.Size = new System.Drawing.Size(332, 41);
            this.lblTeam2.TabIndex = 7;
            this.lblTeam2.Tag = "LabelTeams";
            this.lblTeam2.Text = "MANCHESTER UNITED";
            this.lblTeam2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Font = new System.Drawing.Font("Open Sans", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1043, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 41);
            this.label1.TabIndex = 8;
            this.label1.Text = "V";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Draw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 1011);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTeam2);
            this.Controls.Add(this.btnDrawTeams);
            this.Controls.Add(this.lblTeam1);
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
        private System.Windows.Forms.Label lblTeam1;
        private System.Windows.Forms.Button btnDrawTeams;
        private System.Windows.Forms.Label lblTeam2;
        private System.Windows.Forms.Label label1;
    }
}