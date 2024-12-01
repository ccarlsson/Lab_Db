
using Microsoft.Data.SqlClient;

namespace Lab_Db;
internal class MSSQLMediaRepository(string connectionString) : IMediaRepository
{
    private readonly string _connectionString = connectionString;

    public void Add(Book book)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Books (Title, Author, Pages) VALUES (@Title, @Author, @Pages)";
        command.Parameters.AddWithValue("@Title", book.Title);
        command.Parameters.AddWithValue("@Author", book.Author);
        command.Parameters.AddWithValue("@Pages", book.Pages);
        command.ExecuteNonQuery();
    }

    public void Add(Movie movie)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Movies (Title, Director, Length) VALUES (@Title, @Director, @Length)";
        command.Parameters.AddWithValue("@Title", movie.Title);
        command.Parameters.AddWithValue("@Director", movie.Director);
        command.Parameters.AddWithValue("@Length", movie.Length);
        command.ExecuteNonQuery();
    }

    public IEnumerable<Book> GetBooks()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Title, Author, Pages FROM Books";
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            yield return new Book
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Author = reader.GetString(2),
                Pages = reader.GetInt32(3)
            };
        }
    }

    public IEnumerable<Movie> GetMovies()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Title, Director, Length FROM Movies";
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            yield return new Movie
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Director = reader.GetString(2),
                Length = reader.GetInt32(3)
            };
        }
    }

    public void RemoveBook(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Books WHERE Id = @Id";
        command.Parameters.AddWithValue("@Id", id);
        command.ExecuteNonQuery();
    }

    public void RemoveMovie(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Movies WHERE Id = @Id";
        command.Parameters.AddWithValue("@Id", id);
        command.ExecuteNonQuery();
    }
}
