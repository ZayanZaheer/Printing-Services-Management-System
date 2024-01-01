using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Assignment.Update;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Assignment
{
    public partial class Customer : Form
    {
        // Arrays to store services and their corresponding prices
        private readonly string[] services = { "Black White Print", "Colour Print", "Comb Binding", "Thick Cover Binding", "Poster printing", "Banner" };
        private readonly decimal[] prices = { 0.8m, 2.5m, 5.0m, 15.0m, 3.0m, 10.0m };

        // Database connection and customer name fields
        private SqlConnection conn;
        private string customerName;

        // Constructor to initialize the form
        public Customer(SqlConnection connection, string username)
        {
            InitializeComponent();

            // Initialize database connection and populate serviceComboBox
            conn = connection;
            serviceComboBox.Items.AddRange(services);
            serviceComboBox.SelectedIndexChanged += serviceComboBox_SelectedIndexChanged;
            numericUpDownQuantity.ValueChanged += numericUpDownQuantity_ValueChanged;

            // Set the customer name label and load existing orders
            customerName = username;
            label2.Text = customerName;
            LoadOrders();
        }

        // Event handler for service selection change
        private void serviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        // Event handler for quantity change
        private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        // Update the total cost based on selected service and quantity
        private void UpdateTotal()
        {
            // Check if both service and quantity are selected/entered
            if (serviceComboBox.SelectedIndex != -1)
            {
                // Calculate total cost including urgency fee if selected
                int selectedServiceIndex = serviceComboBox.SelectedIndex;
                decimal price = prices[selectedServiceIndex];
                decimal quantity = numericUpDownQuantity.Value;
                decimal total = price * quantity;

                if (Urgent.Checked)
                {
                    // Add 30% to the total for urgent service
                    total += 0.3m * total;
                }

                // Update the total label with the calculated total cost
                totalLabel.Text = total.ToString();
            }
            else
            {
                // Clear the total label if service or quantity is not selected/entered
                totalLabel.Text = "";
            }
        }

        // Process order confirmation and payment
        private void ConfirmNPay_Click(object sender, EventArgs e)
        {
            if (serviceComboBox.SelectedIndex != -1)
            {
                // Calculate total cost including urgency fee if selected
                int selectedServiceIndex = serviceComboBox.SelectedIndex;
                decimal price = prices[selectedServiceIndex];
                decimal quantity = numericUpDownQuantity.Value;
                decimal total = price * quantity;// Check if quantity is valid (1 or greater)
                
                if (quantity < 1)
                {
                    MessageBox.Show("Please select a quantity of 1 or greater.");
                    return; // Exit method if quantity is invalid
                }

                // Calculate total cost including urgency fee if selected
                total = price * quantity;


                if (Urgent.Checked)
                {
                    // Add 30% to the total for urgent service
                    total += 0.3m * total;
                }

                try
                {
                    // Open connection and insert order data into the Orders table
                    using (conn)
                    {
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }

                        string insertQuery = "INSERT INTO Orders (UserName, Service, DOR, Month, [OrderYear], Fee, PaymentStatus, Numofpage, Status, Urgency) " +
                                                 "VALUES (@UserName, @Service, @DOR, @Month, @OrderYear, @Fee, @PaymentStatus, @Numofpage, @Status, @Urgency)";

                        // Create SQL command with parameters
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserName", customerName);
                            cmd.Parameters.AddWithValue("@Service", services[selectedServiceIndex]);
                            cmd.Parameters.AddWithValue("@DOR", DateTime.Now);
                            cmd.Parameters.AddWithValue("@Month", DateTime.Now.ToString("MMMM"));
                            cmd.Parameters.AddWithValue("@OrderYear", DateTime.Now.Year);
                            cmd.Parameters.AddWithValue("@Fee", price);
                            cmd.Parameters.AddWithValue("@PaymentStatus", 0);
                            cmd.Parameters.AddWithValue("@Numofpage", quantity);
                            cmd.Parameters.AddWithValue("@Status", "New");
                            cmd.Parameters.AddWithValue("@Urgency", Urgent.Checked);

                            // Execute command and show appropriate message based on success or failure
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Order confirmed and added to the database.");
                                LoadOrders();
                            }
                            else
                            {
                                MessageBox.Show("Failed to add order to the database. Please try again.");
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
                    // Close the connection after processing
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                // Prompt user to select a service if none is selected
                MessageBox.Show("Please select a service.");
            }
        }

        // Load orders associated with the current customer
        private void LoadOrders()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string selectQuery = "SELECT * FROM Orders WHERE UserName = @UserName";

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", customerName);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        // Log out of the application
        private void LogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            LogIn form1 = new LogIn();
            form1.ShowDialog();
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-698MC9EG;Initial Catalog=UserData;Integrated Security=true"))
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    // Assuming you have information about the currently logged-in user
                    string currentUsername = customerName;

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
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-698MC9EG;Initial Catalog=UserData;Integrated Security=true"))
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    // Fetch paid orders for the current customer
                    string selectQuery = "SELECT Service, Total FROM Orders WHERE UserName = @UserName AND PaymentStatus = 1";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", customerName);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            StringBuilder receiptContent = new StringBuilder();
                            receiptContent.AppendLine("Receipt Details:");
                            receiptContent.AppendLine("");
                            receiptContent.AppendLine($"Customer Name: {customerName}");
                            receiptContent.AppendLine("");
                            receiptContent.AppendLine("Services:");
                            receiptContent.AppendLine("");

                            decimal totalPrice = 0;

                            while (reader.Read())
                            {
                                string service = reader["Service"].ToString();
                                decimal Total = Convert.ToDecimal(reader["Total"]);
                                totalPrice += Total;

                                receiptContent.AppendLine($"- {service}: ${Total}");
                            }
                            receiptContent.AppendLine("");
                            receiptContent.AppendLine("");
                            receiptContent.AppendLine($"Total Price: ${totalPrice}");

                            MessageBox.Show(receiptContent.ToString(), "Generated Receipt");
                        }
                        else
                        {
                            MessageBox.Show("No paid orders found for receipt generation.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating receipt: " + ex.Message);
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


}
