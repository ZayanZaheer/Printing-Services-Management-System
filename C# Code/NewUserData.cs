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
    public partial class NewUserData : Form
    {
        // SqlConnection object for database connection
        private SqlConnection conn;

        public NewUserData(SqlConnection connection)
        {
            InitializeComponent();
            conn = connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newUsername = New_Username.Text;
            string newPassword = New_Password.Text;
            string newRole = New_Role.Text;

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO U5er (Username, Password, Role) VALUES (@UserName, @PassWord, @Role)", conn);

                cmd.Parameters.AddWithValue("@UserName", newUsername);
                cmd.Parameters.AddWithValue("@PassWord", newPassword);
                cmd.Parameters.AddWithValue("@Role", newRole);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("New user added successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add a new user.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
                // Log detailed error information for troubleshooting, if applicable
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                // Log detailed error information for troubleshooting, if applicable
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



