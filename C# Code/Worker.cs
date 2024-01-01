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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Assignment
{
    public partial class Worker : Form
    {
        // Fields to hold worker name, connection string, and data table
        private string workerName;
        private const string ConnectionString = @"Data Source=LAPTOP-698MC9EG;Initial Catalog=UserData;Integrated Security=true";
        private DataTable dataTable;
        private SqlConnection conn;

        // Constructor to initialize the form with connection and worker's username
        public Worker(SqlConnection connection, string username)
        {
            InitializeComponent();
            conn = connection;

            // Initialize workerName and load data associated with the worker
            workerName = username;
            LoadData();

            // Display the worker's name in a label
            lblWorkerName.Text = workerName;
        }

        // Method to load data for the specific worker
        private void LoadData()
        {
            // Load data for the specific worker using the workerName
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT ServiceID, UserName, Service, PaymentStatus, AssignTo, Status, Urgency, Total FROM Orders WHERE AssignTo = @WorkerName";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@WorkerName", workerName);
                        dataTable = new DataTable();
                        adapter.Fill(dataTable);
                    }
                }

                wrk1AssigndTsk.DataSource = dataTable;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Event handler for data updates (e.g., triggered by an external update)
        private void HandleDataUpdated(object sender, EventArgs e)
        {
            // Refresh the DataGridView in response to the event
            LoadData();
        }

        // Event handler for clicking cells in the DataGridView (currently empty)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // You can handle cell clicks if needed
        }

        // Event handler for updating task status based on user interaction
        private void btnWrkUpdt_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure that a row is selected in the DataGridView
                if (wrk1AssigndTsk.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = wrk1AssigndTsk.SelectedRows[0];

                    // Get the ServiceID from the selected row
                    int serviceId = (int)selectedRow.Cells["ServiceID"].Value;

                    // Determine the status based on the selected radio button
                    string status;
                    if (rbtnWrkPrg.Checked)
                    {
                        status = "Work In Progress";
                    }
                    else if (rbtnCompltd.Checked)
                    {
                        status = "Complete";
                    }
                    else
                    {
                        // No radio button selected
                        MessageBox.Show("Please select a status.");
                        return;
                    }

                    // Update the SQL database with the new status
                    UpdateStatus(serviceId, status);

                    // Reload data to refresh the DataGridView
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Please select a task to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
        }

        // Method to update the status of a specific task in the database
        private void UpdateStatus(int serviceId, string status)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE Orders SET Status = @Status WHERE ServiceID = @ServiceID";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@ServiceID", serviceId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message);
            }
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Assuming you have information about the currently logged-in user
                    string currentUsername = workerName; // Assuming 'Name' is meant to be 'workerName'

                    // Retrieve username and role from the SQL Server based on the logged-in username
                    string query = "SELECT UserName, Role FROM U5er WHERE UserName = @UserName";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add the parameter to the SqlCommand
                        cmd.Parameters.AddWithValue("@UserName", currentUsername);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve the values from the SQL Server
                                string usernameFromDB = reader["UserName"].ToString();
                                string roleFromDB = reader["Role"].ToString();

                                MessageBox.Show($"Retrieved from DB - Username: {usernameFromDB}, Role: {roleFromDB}");

                                // Create a User object with retrieved user information
                                User currentUser = new User
                                {
                                    UserName = usernameFromDB,
                                    Role = roleFromDB
                                };

                                // Open the Update form with the retrieved user information
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnWrkLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            LogIn form1 = new LogIn();
            form1.ShowDialog();
        }
    }

}
