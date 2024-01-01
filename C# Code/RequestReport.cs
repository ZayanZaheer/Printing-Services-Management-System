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
    public partial class RequestReport : Form
    {
        private SqlConnection conn; // SqlConnection object for database connection


        public RequestReport(SqlConnection connection)
        {
            InitializeComponent();
            conn = connection; // Assigning the passed SqlConnection object to the private conn variable

            // Populate the month and year combo boxes with distinct values from the Orders table
            PopulateMonthComboBox();
            PopulateYearComboBox();
        }

        private void PopulateMonthComboBox()
        {
            // Populate the ComboBox with distinct months from the Orders table
            try
            {
                conn.Open(); // Open the database connection
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Month FROM Orders", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Read distinct months and add them to the ComboBox
                while (reader.Read())
                {
                    string month = reader["Month"].ToString();
                    monthComboBox.Items.Add(month);
                }
                reader.Close(); // Close the data reader
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);// Display an error message if an exception occurs

            }
            finally
            {
                conn.Close(); // Close the database connection
            }
        }

        private void PopulateYearComboBox()
        {
            // Populate the ComboBox with distinct years from the Orders table
            try
            {
                conn.Open(); // Open the database connection
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT YEAR(DOR) AS OrderYear FROM Orders", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Read distinct years and add them to the ComboBox
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
                conn.Close(); // Close the database connection
            }
        }

        private void generateButton_Click_1(object sender, EventArgs e)
        {
            // Event handler for the Generate button click
            //MessageBox.Show("Generate button clicked.");  // Debug message

            // Get the selected month and year from combo boxes
            string selectedMonth = monthComboBox.SelectedItem?.ToString();
            string selectedYear = yearComboBox.SelectedItem?.ToString();

            // Check if both month and year are selected, then refresh DataGridViews
            if (!string.IsNullOrEmpty(selectedMonth) && !string.IsNullOrEmpty(selectedYear))
            {
                RefreshDataGridViews(selectedMonth, selectedYear);
            }
            else
            {
                MessageBox.Show("Please select both month and year before generating the report."); // Message to ensure both month and year is selected
            }
        }

        private void RefreshDataGridViews(string selectedMonth, string selectedYear)
        {
            try
            {
                conn.Open();
                // Open the database connection
                // Populate the DataGridView for urgent completed requests
                SqlDataAdapter urgentDataAdapter = new SqlDataAdapter("SELECT ServiceID, UserName, Service, DOR, Month, Fee, Numofpage FROM Orders WHERE Month = @Month AND [OrderYear] = @Year AND Urgency = 1 AND Status = 'complete'", conn);
                urgentDataAdapter.SelectCommand.Parameters.AddWithValue("@Month", selectedMonth);
                urgentDataAdapter.SelectCommand.Parameters.AddWithValue("@Year", selectedYear);
                DataTable urgentDataTable = new DataTable();
                urgentDataAdapter.Fill(urgentDataTable);
                urgentDataGridView.DataSource = urgentDataTable;
                //MessageBox.Show("Urgent Rows: " + urgentDataTable.Rows.Count.ToString()); //Debugging Message
                urgentDataGridView.Refresh();

                // Populate the DataGridView for non-urgent completed requests
                SqlDataAdapter nonUrgentDataAdapter = new SqlDataAdapter("SELECT ServiceID, UserName, Service, DOR, Month, Fee, Numofpage FROM Orders WHERE Month = @Month AND [OrderYear] = @Year AND Urgency = 0 AND Status = 'complete'", conn);
                nonUrgentDataAdapter.SelectCommand.Parameters.AddWithValue("@Month", selectedMonth);
                nonUrgentDataAdapter.SelectCommand.Parameters.AddWithValue("@Year", selectedYear);
                DataTable nonUrgentDataTable = new DataTable();
                nonUrgentDataAdapter.Fill(nonUrgentDataTable);
                nonUrgentDataGridView.DataSource = nonUrgentDataTable;
                //MessageBox.Show("Non-Urgent Rows: " + nonUrgentDataTable.Rows.Count.ToString()); //Debugging Message
                nonUrgentDataGridView.Refresh();
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

        // Close Request Report Form
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
