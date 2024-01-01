namespace Assignment
{
    partial class Manager
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
            this.lblMngrName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.rbtnNotPaid = new System.Windows.Forms.RadioButton();
            this.rbtnPaid = new System.Windows.Forms.RadioButton();
            this.cbxAssignWkr = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.orderStatus = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordChange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.orderStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMngrName
            // 
            this.lblMngrName.AutoSize = true;
            this.lblMngrName.Location = new System.Drawing.Point(128, 111);
            this.lblMngrName.Name = "lblMngrName";
            this.lblMngrName.Size = new System.Drawing.Size(0, 16);
            this.lblMngrName.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Manager Name:";
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Teal;
            this.btnLogOut.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Location = new System.Drawing.Point(749, 521);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(161, 50);
            this.btnLogOut.TabIndex = 19;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Teal;
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(540, 521);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(161, 50);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // rbtnNotPaid
            // 
            this.rbtnNotPaid.AutoSize = true;
            this.rbtnNotPaid.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnNotPaid.Location = new System.Drawing.Point(757, 457);
            this.rbtnNotPaid.Name = "rbtnNotPaid";
            this.rbtnNotPaid.Size = new System.Drawing.Size(104, 27);
            this.rbtnNotPaid.TabIndex = 17;
            this.rbtnNotPaid.TabStop = true;
            this.rbtnNotPaid.Text = "Not Paid";
            this.rbtnNotPaid.UseVisualStyleBackColor = true;
            // 
            // rbtnPaid
            // 
            this.rbtnPaid.AutoSize = true;
            this.rbtnPaid.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPaid.Location = new System.Drawing.Point(589, 457);
            this.rbtnPaid.Name = "rbtnPaid";
            this.rbtnPaid.Size = new System.Drawing.Size(68, 27);
            this.rbtnPaid.TabIndex = 16;
            this.rbtnPaid.TabStop = true;
            this.rbtnPaid.Text = "Paid";
            this.rbtnPaid.UseVisualStyleBackColor = true;
            // 
            // cbxAssignWkr
            // 
            this.cbxAssignWkr.FormattingEnabled = true;
            this.cbxAssignWkr.Items.AddRange(new object[] {
            "worker1 ",
            "worker2",
            "worker3 "});
            this.cbxAssignWkr.Location = new System.Drawing.Point(327, 454);
            this.cbxAssignWkr.Name = "cbxAssignWkr";
            this.cbxAssignWkr.Size = new System.Drawing.Size(147, 24);
            this.cbxAssignWkr.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(186, 455);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Assign Worker";
            // 
            // orderStatus
            // 
            this.orderStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderStatus.Location = new System.Drawing.Point(21, 165);
            this.orderStatus.Name = "orderStatus";
            this.orderStatus.RowHeadersWidth = 51;
            this.orderStatus.RowTemplate.Height = 24;
            this.orderStatus.Size = new System.Drawing.Size(1256, 249);
            this.orderStatus.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Orders:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(429, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 35);
            this.label1.TabIndex = 11;
            this.label1.Text = "Welcome to Manager\'s  Page";
            // 
            // PasswordChange
            // 
            this.PasswordChange.BackColor = System.Drawing.Color.Teal;
            this.PasswordChange.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordChange.ForeColor = System.Drawing.Color.White;
            this.PasswordChange.Location = new System.Drawing.Point(307, 523);
            this.PasswordChange.Name = "PasswordChange";
            this.PasswordChange.Size = new System.Drawing.Size(176, 50);
            this.PasswordChange.TabIndex = 22;
            this.PasswordChange.Text = "Change Password";
            this.PasswordChange.UseVisualStyleBackColor = false;
            this.PasswordChange.Click += new System.EventHandler(this.PasswordChange_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 629);
            this.Controls.Add(this.PasswordChange);
            this.Controls.Add(this.lblMngrName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.rbtnNotPaid);
            this.Controls.Add(this.rbtnPaid);
            this.Controls.Add(this.cbxAssignWkr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.orderStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Manager";
            this.Text = "Manager";
            ((System.ComponentModel.ISupportInitialize)(this.orderStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMngrName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.RadioButton rbtnNotPaid;
        private System.Windows.Forms.RadioButton rbtnPaid;
        private System.Windows.Forms.ComboBox cbxAssignWkr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView orderStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PasswordChange;
    }
}