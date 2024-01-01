namespace Assignment
{
    partial class RequestReport
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
            this.urgentDataGridView = new System.Windows.Forms.DataGridView();
            this.nonUrgentDataGridView = new System.Windows.Forms.DataGridView();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.userDataDataSet1 = new Assignment.UserDataDataSet1();
            this.ordersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ordersTableAdapter = new Assignment.UserDataDataSet1TableAdapters.OrdersTableAdapter();
            this.ordersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.urgentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nonUrgentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // urgentDataGridView
            // 
            this.urgentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.urgentDataGridView.Location = new System.Drawing.Point(34, 111);
            this.urgentDataGridView.Name = "urgentDataGridView";
            this.urgentDataGridView.RowHeadersWidth = 51;
            this.urgentDataGridView.RowTemplate.Height = 24;
            this.urgentDataGridView.Size = new System.Drawing.Size(754, 180);
            this.urgentDataGridView.TabIndex = 0;
            // 
            // nonUrgentDataGridView
            // 
            this.nonUrgentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nonUrgentDataGridView.Location = new System.Drawing.Point(34, 330);
            this.nonUrgentDataGridView.Name = "nonUrgentDataGridView";
            this.nonUrgentDataGridView.RowHeadersWidth = 51;
            this.nonUrgentDataGridView.RowTemplate.Height = 24;
            this.nonUrgentDataGridView.Size = new System.Drawing.Size(754, 180);
            this.nonUrgentDataGridView.TabIndex = 0;
            // 
            // monthComboBox
            // 
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Location = new System.Drawing.Point(820, 111);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(121, 24);
            this.monthComboBox.TabIndex = 1;
            // 
            // userDataDataSet1
            // 
            this.userDataDataSet1.DataSetName = "UserDataDataSet1";
            this.userDataDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ordersBindingSource
            // 
            this.ordersBindingSource.DataMember = "Orders";
            this.ordersBindingSource.DataSource = this.userDataDataSet1;
            // 
            // ordersTableAdapter
            // 
            this.ordersTableAdapter.ClearBeforeFill = true;
            // 
            // ordersBindingSource1
            // 
            this.ordersBindingSource1.DataMember = "Orders";
            this.ordersBindingSource1.DataSource = this.userDataDataSet1;
            // 
            // yearComboBox
            // 
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Location = new System.Drawing.Point(820, 227);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(121, 24);
            this.yearComboBox.TabIndex = 1;
            // 
            // generateButton
            // 
            this.generateButton.BackColor = System.Drawing.Color.Teal;
            this.generateButton.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateButton.ForeColor = System.Drawing.Color.White;
            this.generateButton.Location = new System.Drawing.Point(809, 309);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(155, 35);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Generate Report";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click_1);
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.Teal;
            this.Close.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.ForeColor = System.Drawing.Color.White;
            this.Close.Location = new System.Drawing.Point(820, 385);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(127, 32);
            this.Close.TabIndex = 3;
            this.Close.Text = "Close Report";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(331, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 35);
            this.label1.TabIndex = 4;
            this.label1.Text = "REQUEST REPORT ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(817, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "MONTH :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(817, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "YEAR :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(325, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "MONTHS URGENT REQUESTS REPORT:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(368, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "MONTHS NON-URGENT REQUESTS REPORT:";
            // 
            // RequestReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 543);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.yearComboBox);
            this.Controls.Add(this.monthComboBox);
            this.Controls.Add(this.nonUrgentDataGridView);
            this.Controls.Add(this.urgentDataGridView);
            this.Name = "RequestReport";
            this.Text = "RequestReport";
            ((System.ComponentModel.ISupportInitialize)(this.urgentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nonUrgentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userDataDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView urgentDataGridView;
        private System.Windows.Forms.DataGridView nonUrgentDataGridView;
        private System.Windows.Forms.ComboBox monthComboBox;
        private UserDataDataSet1 userDataDataSet1;
        private System.Windows.Forms.BindingSource ordersBindingSource;
        private UserDataDataSet1TableAdapters.OrdersTableAdapter ordersTableAdapter;
        private System.Windows.Forms.BindingSource ordersBindingSource1;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}