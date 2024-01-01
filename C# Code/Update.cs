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

namespace Assignment
{
    public partial class Update : Form
    {
        // SqlConnection object for database connection
        private SqlConnection conn;
        private User currentUser;

        public class User
        {
            public string UserName { get; set; }
            public string Role { get; set; }
        }

        public Update(SqlConnection connection, User user)
        {
            InitializeComponent();
            conn = connection;
            currentUser = user;

            // Set labels with user information
            roleLabel.Text = "Role: " + currentUser.Role;
            usernameLabel.Text = "Username: " + currentUser.UserName;
        }

        private void updatePasswordButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // Get the new password from the textbox
                string newPassword = newPasswordTextBox.Text;

                // Check if the new password textbox is empty
                if (string.IsNullOrEmpty(newPassword))
                {
                    MessageBox.Show("Please enter a new password.");
                    return; // Exit the method if the password is empty
                }

                // Close any existing DataReader if open
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                // Re-open the connection before executing the update command
                conn.Open();

                // Create and execute the SQL command
                string updateQuery = "UPDATE U5er SET Password = @NewPassword WHERE UserName = @UserName";
                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    // Add the New Password to the Database
                    cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                    cmd.Parameters.AddWithValue("@UserName", currentUser.UserName);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password updated successfully.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Password update failed. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }





    }






}
