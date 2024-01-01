using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Assignment.Update;

namespace Assignment
{
    public partial class Manager : Form
    {
        
        // Connection string to the database
        private const string ConnectionString = @"Data Source=LAPTOP-698MC9EG;Initial Catalog=UserData;Integrated Security=true";
        private DataTable dataTable; // DataTable to store retrieved data
        private SqlConnection conn; // SQL connection object

        // Constructor for Manager form
        public Manager(SqlConnection connection, string username)
        {
            InitializeComponent();
            LoadData(); // Load initial data on form load
            btnUpdate.Click += btnUpdate_Click; // Event handler for update button
            conn = connection; // Assign passed SQL connection
            LoadUsernamesIntoComboBox(); // Load usernames into ComboBox
        }

        // Method to load data from Orders table into DataGridView
        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT ServiceID, UserName, Service, DOR, PaymentStatus, AssignTo, Status, Urgency, Total FROM Orders";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        dataTable = new DataTable();
                        adapter.Fill(dataTable);
                    }
                }
                orderStatus.DataSource = dataTable; // Bind data to DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // Method to load usernames from 'U5er' table into ComboBox
        private void LoadUsernamesIntoComboBox()
        {
            try
            {
                cbxAssignWkr.Items.Clear(); // Clear previous items if any

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT Username FROM U5er WHERE Role = 'Worker'"; // Retrieve usernames from 'U5er' table

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            string username = reader["Username"].ToString();
                            cbxAssignWkr.Items.Add(username);
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading usernames: " + ex.Message);
            }
        }

        // Event handler for update button click
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in orderStatus.SelectedRows)
                {
                    int serviceId = (int)row.Cells["ServiceID"].Value;

                    if (cbxAssignWkr.SelectedIndex != -1)
                    {
                        string assignedWorker = cbxAssignWkr.SelectedItem.ToString();

                        // Update assigned worker for the selected service
                        UpdateSql(serviceId, assignedWorker);

                        // Check payment status and update
                        bool isPaid = rbtnPaid.Checked;
                        UpdatePaymentStatus(serviceId, isPaid);

                        if (isPaid)
                        {
                            // Generate receipt for paid services
                            GenerateReceipt(serviceId);
                        }

                        LoadData(); // Reload data after updates
                    }
                    else
                    {
                        MessageBox.Show("Please select a worker.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
        }

        // Method to generate a receipt for a service
        private void GenerateReceipt(int serviceId)
        {
            try
            {
                string customerName = "";
                string serviceName = "";
                decimal totalPrice = 0;

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT UserName, Service, Total FROM Orders WHERE ServiceID = @ServiceID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ServiceID", serviceId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                customerName = reader["UserName"].ToString();
                                serviceName = reader["Service"].ToString();
                                totalPrice = Convert.ToDecimal(reader["Total"]);

                                string receiptContent = $"Customer Name: {customerName}\n \n Service: {serviceName}\n \n \n Total Price: {totalPrice:C}";

                                MessageBox.Show("Receipt Generated For Customer:\n \n" + receiptContent);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating receipt: " + ex.Message);
            }
        }

        // Method to update assigned worker in the database
        private void UpdateSql(int serviceId, string assignedWorker)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE Orders SET AssignTo = @AssignTo WHERE ServiceID = @ServiceID";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@AssignTo", assignedWorker);
                        cmd.Parameters.AddWithValue("@ServiceID", serviceId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating assignment: " + ex.Message);
            }
        }

        // Method to update payment status in the database
        private void UpdatePaymentStatus(int serviceId, bool isPaid)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE Orders SET PaymentStatus = @PaymentStatus WHERE ServiceID = @ServiceID";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@PaymentStatus", isPaid);
                        cmd.Parameters.AddWithValue("@ServiceID", serviceId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating payment status: " + ex.Message);
            }
        }

        // Event handler for log out button click
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            LogIn form1 = new LogIn();
            form1.ShowDialog();
        }

        // Event handler for password change button click
        private void PasswordChange_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string currentUsername = Name;
                string query = "SELECT UserName, Role FROM U5er WHERE UserName = @UserName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", currentUsername);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string usernameFromDB = reader["UserName"].ToString();
                            string roleFromDB = reader["Role"].ToString();

                            MessageBox.Show($"Retrieved from DB - Username: {usernameFromDB}, Role: {roleFromDB}");

                            User currentUser = new User
                            {
                                UserName = usernameFromDB,
                                Role = roleFromDB
                            };

                            Update form8 = new Update(conn, currentUser);
                            form8.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("User not found in the database.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }


}
