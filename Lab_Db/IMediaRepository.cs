using Lab_Db;

internal interface IMediaRepository
{
    void Add(Book book);
    void Add(Movie movie);
    IEnumerable<Book> GetBooks();
    IEnumerable<Movie> GetMovies();
    void RemoveBook(int id);
    void RemoveMovie(int id);
}