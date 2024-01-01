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
    public partial class LogIn : Form
    {
        // SqlConnection object for database connection
        private SqlConnection conn;
        private string connectionString = @"Data Source=LAPTOP-698MC9EG;Initial Catalog=UserData;Integrated Security=true";

        public LogIn()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
        }

        private void Signin_btn_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string[] allowedRoles = new string[] { "Admin", "Manager", "Customer", "Worker" };

            string userRole = CheckCredentials(username, password, allowedRoles);

            if (userRole != null)
            {
                OpenAppropriateForm(userRole, username);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private void OpenAppropriateForm(string userRole, string username)
        {
            switch (userRole)
            {
                case "Admin":
                    Admin form2 = new Admin(conn, username);
                    form2.Show();
                    break;
                case "Manager":
                    Manager form3 = new Manager(conn, username);
                    form3.Show();
                    break;
                case "Customer":
                    Customer form4 = new Customer(conn, username);
                    form4.Show();
                    break;
                case "Worker":
                    Worker form5 = new Worker(conn, username);
                    form5.Show();
                    break;
            }
        }

        private string CheckCredentials(string username, string password, string[] allowedRoles)
        {
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Role FROM U5er WHERE Username = @UserName AND Password = @PassWord", conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.Parameters.AddWithValue("@PassWord", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string role = reader["Role"].ToString();
                            if (Array.Exists(allowedRoles, r => r == role))
                                return role;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

    }
}
