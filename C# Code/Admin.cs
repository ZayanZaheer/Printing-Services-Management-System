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
    public partial class Admin : Form
    {
        // SqlConnection object for database connection
        private SqlConnection conn;
        private string Name;

        // Constructor to initialize the form with a database connection and load initial data
        public Admin(SqlConnection connection, string username)
        {
            InitializeComponent();
            conn = connection;
            Name = username;
            RefreshDataGridView();
        }

        // Method called when the Admin form is loaded
        private void Admin_Load(object sender, EventArgs e)
        {
            // You can include actions or settings when the form loads
        }

        // Method to refresh the DataGridView with user data
        private void RefreshDataGridView()
        {
            try
            {
                // Open connection and retrieve user data
                conn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Username, Password, Role FROM U5er", conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
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

        // Event handler for button1 (New User Data)
        private void button1_Click(object sender, EventArgs e)
        {
            // Open the form to add new user data and refresh DataGridView after form is closed
            NewUserData form3 = new NewUserData(conn);
            form3.ShowDialog();
            RefreshDataGridView();
        }

        // Event handler for button2 (Request Report)
        private void button2_Click(object sender, EventArgs e)
        {
            // Open the form for requesting reports
            RequestReport Form10 = new RequestReport(conn);
            Form10.ShowDialog();
        }

        // Event handler for button3 (Monthly Earning Report)
        private void button3_Click(object sender, EventArgs e)
        {
            // Open the form for monthly earning report
            MonthlyEarningReport form5 = new MonthlyEarningReport(conn);
            form5.Show();
        }

        // Event handler for button4 (Update User)
        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                // Assuming you have information about the currently logged-in user
                string currentUsername = Name;

                // Retrieve username and role from the SQL Server based on the logged-in username
                string query = "SELECT UserName, Role FROM U5er WHERE UserName = @UserName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Event handler for the log out button
        private void LogOut_Click(object sender, EventArgs e)
        {
            // Close the Admin form
            this.Close();
            LogIn form1 = new LogIn();
            form1.ShowDialog();
        }
    }


}
