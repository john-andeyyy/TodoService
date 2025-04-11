using Model.Manager;
using MySql.Data.MySqlClient;
using Todo_Service.Models.Request;

namespace Todo_Service.Models.Manager
{
    public class TodoManager : BaseManager
    {

        public List<TodoDetails> UserTodo(int Id)
        {
            var todoList = new List<TodoDetails>();
            using (MySqlConnection conn = GetConnection())
            {
                try
                {

                    conn.Open();
                    string query = "SELECT * FROM todos WHERE userId = @userId AND Status = 'A'";
                    var command = new MySqlCommand(query, conn);

                    command.Parameters.AddWithValue("@userId", Id);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var todo = new TodoDetails
                        {
                            Id = reader.GetInt32("id"),
                            UserId = reader.GetInt32("userId"),
                            Title = reader.GetString("title"),
                            Description = reader.GetString("description"),
                            IsCompleted = reader.GetBoolean("isCompleted"),
                            Status = reader.GetString("status"),
                            CreatedAt = reader.GetDateTime("createdAt")
                        };
                        todoList.Add(todo);
                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            }
            return todoList;
        }

        public bool CreateTodo(NewTodo TodoD)
        {
            var isOkay = false;
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = @" 
                    INSERT INTO Todos ( UserId, Title, Description)
                    VALUES (@UserId,@Title,@Description);
                    ";
                    MySqlCommand sql = new MySqlCommand(query, conn);
                    sql.Parameters.AddWithValue("@UserId", TodoD.UserId);
                    sql.Parameters.AddWithValue("@Title", TodoD.Title);
                    sql.Parameters.AddWithValue("@Description", TodoD.Description);

                    sql.ExecuteReader();
                    isOkay = true;
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Query: {ex.Message}");
            }
            return isOkay;
        }
        public TodoDetails GetTodoById(int Id)
        {
            TodoDetails todoDetails = null;

            using (MySqlConnection conn = GetConnection())
            {
                try
                {

                    conn.Open();
                    string query = "SELECT * FROM todo WHERE id = @id AND Status = 'A'";
                    var command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("@id", Id);
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        todoDetails = new TodoDetails
                        {
                            Id = reader.GetInt32("id"),
                            UserId = reader.GetInt32("userId"),
                            Title = reader.GetString("title"),
                            Description = reader.GetString("description"),
                            IsCompleted = reader.GetBoolean("isCompleted"),
                            Status = reader.GetString("status"),
                            CreatedAt = reader.GetDateTime("createdAt")
                        };

                    }
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Query: {ex.Message}");
                }
            }
            return todoDetails;
        }

        public bool UpdateTodo(TodoDetails todo)
        {
            var IsOkay = false;
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
            UPDATE Todos 
            SET 
                Title = @Title,
                Description = @Description,
                IsCompleted = @IsCompleted,
                Status = @Status;";

                    MySqlCommand sql = new MySqlCommand(query, conn);
                    sql.Parameters.AddWithValue("@Title", todo.Title);
                    sql.Parameters.AddWithValue("@Description", todo.Description);
                    sql.Parameters.AddWithValue("@IsCompleted", todo.IsCompleted);
                    sql.Parameters.AddWithValue("@Status", todo.Status);
                    sql.ExecuteNonQuery();
                    IsOkay = true;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Query: {ex.Message}");
                }
                return IsOkay;
            }


        }

        public bool Delete(int Id)
        {

            var IsOkay = false;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                try
                {
                    string query = "UPDATE Todos SET Status = 'D' WHERE Id = @ID";
                    MySqlCommand sql = new MySqlCommand(query, conn);
                    sql.Parameters.AddWithValue("@Id", Id);
                    sql.ExecuteNonQuery();
                    IsOkay = true;
                    conn.Close();


                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error Query: {ex.Message}");

                }
            }
            return IsOkay;
        }

        public bool IsCompleted(bool IsCompleted, int Id)
        {

            var IsOkay = false;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                try
                {
                    string query = "UPDATE Todos SET IsCompleted = @IsCompleted WHERE Id = @ID";
                    MySqlCommand sql = new MySqlCommand(query, conn);
                    sql.Parameters.AddWithValue("@Id", Id);
                    sql.Parameters.AddWithValue("@IsCompleted", IsCompleted);

                    sql.ExecuteNonQuery();
                    IsOkay = true;
                    conn.Close();


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Query: {ex.Message}");

                }
            }
            return IsOkay;
        }

    }
}
