using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;

namespace hio_q
{
    public partial class Form1 : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\hio_q.accdb;";
        public Form1()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            // inserting the data 
            string sql = "INSERT INTO v_hio (name, num, law, day) VALUES (@Value1, @Value2, @Value3, @Value4)";
            OleDbCommand command = new OleDbCommand(sql, connection);
            command.Parameters.AddWithValue("@Value1", "ahmed sayessssssssssd");
            command.Parameters.AddWithValue("@Value2", "45623");
            //string dateString = "14/05/2023";
            // string timeString = "10:30 AM";
            command.Parameters.AddWithValue("@Value3", "التامين الصحى");
            string dateString = "2023-05-17";
            DateTime dateValue = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            command.Parameters.AddWithValue("@Value4", dateValue);

            try
            {
                object result = command.ExecuteScalar();
                // Do something with the result if needed
            }
            catch (OleDbException ex)
            {
                // Handle the exception and display or log the error message
                Console.WriteLine("Error executing SQL statement: " + ex.Message);
            }
            //command.ExecuteNonQuery();
            // end inserting the data 
            connection.Close();


        }

    }
}
