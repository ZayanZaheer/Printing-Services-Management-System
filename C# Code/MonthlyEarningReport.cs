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
    // This class represents a form for generating a monthly earning report.
    public partial class MonthlyEarningReport : Form
    {
        private SqlConnection conn; // SqlConnection object for database connection

        // Constructor for the MonthlyEarningReport form that initializes components and sets up the connection
        public MonthlyEarningReport(SqlConnection connection)
        {
            InitializeComponent();
            conn = connection; // Assign the passed SqlConnection object to the private conn variable

            // Populate the month and year combo boxes with distinct values from the Orders table
            PopulateMonthComboBox();
            PopulateYearComboBox();
        }

        // Populates the month combo box with distinct months from the Orders table
        private void PopulateMonthComboBox()
        {
            try
            {
                conn.Open(); // Open the database connection
                             // SQL command to select distinct months from Orders
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Month FROM Orders", conn);
                SqlDataReader reader = cmd.ExecuteReader(); // Execute the SQL command

                // Read and add distinct months to the monthComboBox
                while (reader.Read())
                {
                    string month = reader["Month"].ToString();
                    monthComboBox.Items.Add(month);
                }
                reader.Close(); // Close the data reader
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Display an error message if an exception occurs
            }
            finally
            {
                conn.Close(); // Close the database connection in the finally block
            }
        }

        // Populates the year combo box with distinct years from the Orders table
        private void PopulateYearComboBox()
        {
            try
            {
                conn.Open(); // Open the database connection
                             // SQL command to select distinct years from Orders
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT [OrderYear] FROM Orders", conn);
                SqlDataReader reader = cmd.ExecuteReader(); // Execute the SQL command

                // Read and add distinct years to the yearComboBox
                while (reader.Read())
                {
                    string year = reader["OrderYear"].ToString();
                    yearComboBox.Items.Add(year);
                }
                reader.Close(); // Close the data reader
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Display an error message if an exception occurs
            }
            finally
            {
                conn.Close(); // Close the database connection in the finally block
            }
        }

        // Event handler for the generateButton click event
        private void generateButton_Click_1(object sender, EventArgs e)
        {
            // Get the selected month and year from combo boxes
            string selectedMonth = monthComboBox.SelectedItem?.ToString();
            string selectedYear = yearComboBox.SelectedItem?.ToString();

            // If both month and year are selected, refresh the data grid view with the report
            if (!string.IsNullOrEmpty(selectedMonth) && !string.IsNullOrEmpty(selectedYear))
            {
                RefreshDataGridView(selectedMonth, selectedYear);
            }
            else
            {
                MessageBox.Show("Please select both month and year before generating the report."); // Prompt user to select both month and year
            }
        }

        // Refreshes the data grid view with earnings data for the selected month and year
        private void RefreshDataGridView(string selectedMonth, string selectedYear)
        {
            try
            {
                conn.Open(); // Open the database connection

                // SQL query to calculate earnings based on specific criteria
                string query = @"SELECT Service, SUM((Fee + CASE WHEN Urgency = 1 THEN 0.3 * Fee ELSE 0 END) * Numofpage) AS Earnings, COUNT(ServiceID) AS TotalOrders FROM Orders WHERE Month = @Month AND [OrderYear] = @Year AND Status = 'complete' AND PaymentStatus = 1 GROUP BY Service";

                SqlCommand cmd = new SqlCommand(query, conn); // Create SQL command
                cmd.Parameters.AddWithValue("@Month", selectedMonth); // Add parameters for month and year
                cmd.Parameters.AddWithValue("@Year", selectedYear);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd); // Create data adapter
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable); // Fill data table with results from the SQL command
                dataGridView1.DataSource = dataTable; // Set data grid view's data source to the filled data table
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Display an error message if an exception occurs
            }
            finally
            {
                conn.Close(); // Close the database connection in the finally block
            }
        }

        // Event handler for the Close button to close the form
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }
    }




}
