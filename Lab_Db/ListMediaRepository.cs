using Lab_Db;

internal class ListMediaRepository : IMediaRepository
{
    private readonly List<Media> _media = [];

    public void Add(Book book)
    {
        int id = _media.Select(m => m.Id).DefaultIfEmpty(0).Max() + 1;
        book.Id = id;
        _media.Add(book);
    }

    public void Add(Movie movie)
    {
        int id = _media.Select(m => m.Id).DefaultIfEmpty(0).Max() + 1;
        movie.Id = id;
        _media.Add(movie);
    }

    public IEnumerable<Book> GetBooks()
    {
        return _media.OfType<Book>();
    }

    public IEnumerable<Movie> GetMovies()
    {
        return _media.OfType<Movie>();
    }

    public void RemoveBook(int id)
    {
        _media.RemoveAll(m => m.Id == id);
    }

    public void RemoveMovie(int id)
    {
        _media.RemoveAll(m => m.Id == id);
    }
}