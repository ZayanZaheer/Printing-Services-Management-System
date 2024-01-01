namespace Assignment
{
    partial class Worker
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
            this.btnWrkLogOut = new System.Windows.Forms.Button();
            this.btnWrkUpdt = new System.Windows.Forms.Button();
            this.rbtnCompltd = new System.Windows.Forms.RadioButton();
            this.rbtnWrkPrg = new System.Windows.Forms.RadioButton();
            this.lblWorkerName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.wrk1AssigndTsk = new System.Windows.Forms.DataGridView();
            this.ChangePassword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.wrk1AssigndTsk)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWrkLogOut
            // 
            this.btnWrkLogOut.BackColor = System.Drawing.Color.Teal;
            this.btnWrkLogOut.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWrkLogOut.ForeColor = System.Drawing.Color.White;
            this.btnWrkLogOut.Location = new System.Drawing.Point(781, 460);
            this.btnWrkLogOut.Name = "btnWrkLogOut";
            this.btnWrkLogOut.Size = new System.Drawing.Size(159, 52);
            this.btnWrkLogOut.TabIndex = 25;
            this.btnWrkLogOut.Text = "Log Out";
            this.btnWrkLogOut.UseVisualStyleBackColor = false;
            this.btnWrkLogOut.Click += new System.EventHandler(this.btnWrkLogOut_Click);
            // 
            // btnWrkUpdt
            // 
            this.btnWrkUpdt.BackColor = System.Drawing.Color.Teal;
            this.btnWrkUpdt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWrkUpdt.ForeColor = System.Drawing.Color.White;
            this.btnWrkUpdt.Location = new System.Drawing.Point(588, 460);
            this.btnWrkUpdt.Name = "btnWrkUpdt";
            this.btnWrkUpdt.Size = new System.Drawing.Size(159, 52);
            this.btnWrkUpdt.TabIndex = 24;
            this.btnWrkUpdt.Text = "Update";
            this.btnWrkUpdt.UseVisualStyleBackColor = false;
            this.btnWrkUpdt.Click += new System.EventHandler(this.btnWrkUpdt_Click);
            // 
            // rbtnCompltd
            // 
            this.rbtnCompltd.AutoSize = true;
            this.rbtnCompltd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCompltd.Location = new System.Drawing.Point(290, 376);
            this.rbtnCompltd.Name = "rbtnCompltd";
            this.rbtnCompltd.Size = new System.Drawing.Size(112, 27);
            this.rbtnCompltd.TabIndex = 23;
            this.rbtnCompltd.TabStop = true;
            this.rbtnCompltd.Text = "Complete";
            this.rbtnCompltd.UseVisualStyleBackColor = true;
            // 
            // rbtnWrkPrg
            // 
            this.rbtnWrkPrg.AutoSize = true;
            this.rbtnWrkPrg.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnWrkPrg.Location = new System.Drawing.Point(75, 376);
            this.rbtnWrkPrg.Name = "rbtnWrkPrg";
            this.rbtnWrkPrg.Size = new System.Drawing.Size(179, 27);
            this.rbtnWrkPrg.TabIndex = 22;
            this.rbtnWrkPrg.TabStop = true;
            this.rbtnWrkPrg.Text = "Work In Progress";
            this.rbtnWrkPrg.UseVisualStyleBackColor = true;
            // 
            // lblWorkerName
            // 
            this.lblWorkerName.AutoSize = true;
            this.lblWorkerName.Location = new System.Drawing.Point(213, 138);
            this.lblWorkerName.Name = "lblWorkerName";
            this.lblWorkerName.Size = new System.Drawing.Size(0, 16);
            this.lblWorkerName.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(71, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 23);
            this.label6.TabIndex = 20;
            this.label6.Text = "Worker Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(446, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(357, 35);
            this.label3.TabIndex = 19;
            this.label3.Text = "Welcome to Worker\'s  Page";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Tasks Assigned to Worker:\r\n";
            // 
            // wrk1AssigndTsk
            // 
            this.wrk1AssigndTsk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wrk1AssigndTsk.Location = new System.Drawing.Point(75, 224);
            this.wrk1AssigndTsk.Name = "wrk1AssigndTsk";
            this.wrk1AssigndTsk.RowHeadersWidth = 51;
            this.wrk1AssigndTsk.RowTemplate.Height = 24;
            this.wrk1AssigndTsk.Size = new System.Drawing.Size(1160, 127);
            this.wrk1AssigndTsk.TabIndex = 17;
            // 
            // ChangePassword
            // 
            this.ChangePassword.BackColor = System.Drawing.Color.Teal;
            this.ChangePassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePassword.ForeColor = System.Drawing.Color.White;
            this.ChangePassword.Location = new System.Drawing.Point(327, 460);
            this.ChangePassword.Name = "ChangePassword";
            this.ChangePassword.Size = new System.Drawing.Size(233, 52);
            this.ChangePassword.TabIndex = 26;
            this.ChangePassword.Text = "Change Password";
            this.ChangePassword.UseVisualStyleBackColor = false;
            this.ChangePassword.Click += new System.EventHandler(this.ChangePassword_Click);
            // 
            // Worker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 551);
            this.Controls.Add(this.ChangePassword);
            this.Controls.Add(this.btnWrkLogOut);
            this.Controls.Add(this.btnWrkUpdt);
            this.Controls.Add(this.rbtnCompltd);
            this.Controls.Add(this.rbtnWrkPrg);
            this.Controls.Add(this.lblWorkerName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wrk1AssigndTsk);
            this.Name = "Worker";
            this.Text = "Worker";
            ((System.ComponentModel.ISupportInitialize)(this.wrk1AssigndTsk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWrkLogOut;
        private System.Windows.Forms.Button btnWrkUpdt;
        private System.Windows.Forms.RadioButton rbtnCompltd;
        private System.Windows.Forms.RadioButton rbtnWrkPrg;
        private System.Windows.Forms.Label lblWorkerName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView wrk1AssigndTsk;
        private System.Windows.Forms.Button ChangePassword;
    }
}