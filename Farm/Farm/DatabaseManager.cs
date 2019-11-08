using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    public class DatabaseManager
    {
        private string connectionString;

        public DatabaseManager()
        {
            string currentDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            string databaseDirectory = Path.Combine(projectDirectory, "Farm\\Database.mdf");
            this.connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={databaseDirectory};Integrated Security=True";
        }

        public DataTable RunQuery(string query)
        {
            DataTable product = new DataTable();
            SqlConnection connection = new SqlConnection(this.connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            connection.Open();
            dataAdapter.Fill(product);
            connection.Close();
            dataAdapter.Dispose();
            return product;
        }

        public void ExecuteInstruction(string instruction)
        {
            DataTable product = new DataTable();
            SqlConnection connection = new SqlConnection(this.connectionString);
            SqlCommand command = new SqlCommand(instruction, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
