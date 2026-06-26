using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace demo
{
    public class tasks
    {
        // Database connection string
        string connection = @"Data source=(localdb)\MSSQLLocalDB;Database=master";

        // Create table if it does not already exist
        public void CreateTableIfNotExists()
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                try
                {
                    connect.Open();

                    string createTableQuery = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='demo_tasks' AND xtype='U')
                        BEGIN
                            CREATE TABLE demo_tasks (
                                task_id INT IDENTITY(1,1) PRIMARY KEY,
                                task_name NVARCHAR(100) NOT NULL,
                                task_description NVARCHAR(255),
                                task_dueDate NVARCHAR(50),
                                task_status NVARCHAR(20)
                            )
                        END";

                    SqlCommand createCommand = new SqlCommand(createTableQuery, connect);
                    createCommand.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error creating table: " + error.Message);
                }
            }
        }

        // Test database connection
        public void test_connection()
        {
            SqlConnection connect = new SqlConnection(connection);

            try
            {
                connect.Open();
                MessageBox.Show("connected..");
                connect.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        // Insert new task into database
        public void insert_task(string name, string description, string dueDate, string status)
        {
            using (SqlConnection connects = new SqlConnection(connection))
            {
                connects.Open();

                string query =
                    $"insert into demo_tasks values('{name}','{description}','{dueDate}','{status}');";

                SqlCommand run_query = new SqlCommand(query, connects);
                run_query.ExecuteNonQuery();
            }
        }

        // Load all tasks into ListView
        public void load_tasks(ListView view_task)
        {
            SqlConnection connects = new SqlConnection(connection);
            connects.Open();

            string query = "select * from demo_tasks;";
            SqlCommand run_query = new SqlCommand(query, connects);
            SqlDataReader data_collect = run_query.ExecuteReader();

            bool data_found = false;

            while (data_collect.Read())
            {
                data_found = true;

                string task_id = data_collect["task_id"].ToString();
                string task_name = data_collect["task_name"].ToString();
                string task_description = data_collect["task_description"].ToString();
                string task_dueDate = data_collect["task_dueDate"].ToString();
                string task_status = data_collect["task_status"].ToString();

                view_task.Items.Add(
                    task_id + " " + task_name +
                    " with " + task_description +
                    " due on " + task_dueDate +
                    " and is " + task_status
                );
            }

            if (!data_found)
            {
                view_task.Items.Add("No task found");
            }

            connects.Close();
        }

        // Mark task as completed
        public void update_taskStatus(int id)
        {
            SqlConnection connects = new SqlConnection(connection);
            connects.Open();

            string query = $"update demo_tasks set task_status='done' where task_id={id}";
            SqlCommand run_query = new SqlCommand(query, connects);
            run_query.ExecuteNonQuery();

            connects.Close();
        }

        // Delete task
        public void delete_task(int id)
        {
            SqlConnection connects = new SqlConnection(connection);
            connects.Open();

            string query = $"delete from demo_tasks where task_id={id}";
            SqlCommand run_query = new SqlCommand(query, connects);
            run_query.ExecuteNonQuery();

            connects.Close();
        }
    }
}