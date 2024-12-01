using Lab_Db;

MenuOption _option = default;
IMediaRepository _mediaRepository = new MSSQLMediaRepository("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=medialabDb;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"); //new ListMediaRepository();

while (_option != MenuOption.Exit)
{
    _option = PrintMenu();
    HandleOption(_option);
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey(true);
    Console.Clear();
}

#region Menu Methods
MenuOption PrintMenu()
{
    Console.WriteLine("1. Add Movie");
    Console.WriteLine("2. Add Book");
    Console.WriteLine("3. List All");
    Console.WriteLine("4. List Books");
    Console.WriteLine("5. List Movies");
    Console.WriteLine("6. Remove Book");
    Console.WriteLine("7. Remove Movie");
    Console.WriteLine("8. Exit");
    Console.Write("Enter your choice: ");
    while (true)
    {
        if (Enum.TryParse<MenuOption>(Console.ReadLine(), out MenuOption option))
        {
            return option;
        }
        else
        {
            Console.WriteLine("Invalid option. Please try again.");
        }
    }
}


void HandleOption(MenuOption option)
{
    switch (option)
    {
        case MenuOption.AddMovie:
            AddMovie();
            break;
        case MenuOption.AddBook:
            AddBook();
            break;
        case MenuOption.ListAll:
            ListAll();
            break;
        case MenuOption.ListBooks:
            ListBooks();
            break;
        case MenuOption.ListMovies:
            ListMovies();
            break;
        case MenuOption.RemoveBook:
            RemoveBook();
            break;
        case MenuOption.RemoveMovie:
            RemoveMovie();
            break;
        case MenuOption.Exit:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Not a valid option. try again");
            break;
    }
}

#endregion

#region Media Access Methods

void RemoveMovie()
{
    var movies = _mediaRepository.GetMovies();
    foreach (var movie in movies)
    {
        Console.WriteLine($"{movie.Id}. {movie.Title} by {movie.Director}");
    }
    int id = GetInput<int>("Enter the id of the movie to remove: ");
    _mediaRepository.RemoveMovie(id);
}

void RemoveBook()
{
    var books = _mediaRepository.GetBooks();
    foreach (var book in books)
    {
        Console.WriteLine($"{book.Id}. {book.Title} by {book.Author}");
    }
    int id = GetInput<int>("Enter the id of the book to remove: ");
    _mediaRepository.RemoveBook(id);
}

void ListMovies()
{
    var movies = _mediaRepository.GetMovies();
    foreach (var movie in movies)
    {
        Console.WriteLine($"{movie.Title} by {movie.Director}");
    }
}

void ListBooks()
{
    var books = _mediaRepository.GetBooks();
    foreach (var book in books)
    {
        Console.WriteLine($"{book.Title} by {book.Author}");
    }
}

void ListAll()
{
    ListBooks();
    ListMovies();
}

void AddBook()
{
    string title = GetInput<string>("Enter the title: ");
    string author = GetInput<string>("Enter the author: ");
    int pages = GetInput<int>("Enter the number of pages: ");
    _mediaRepository.Add(new Book { Title = title.Trim(), Author = author.Trim(), Pages = pages });
}

void AddMovie()
{
    string title = GetInput<string>("Enter the title: ");
    string director = GetInput<string>("Enter the director: ");
    int length = GetInput<int>("Enter the duration: ");
    _mediaRepository.Add(new Movie { Title = title.Trim(), Director = director.Trim(), Length = length });
}

#endregion

#region Input Helper
T GetInput<T>(string message)
{

    Console.Write(message);
    try
    {
        return (T)Convert.ChangeType(Console.ReadLine() ?? "", typeof(T));
    }
    catch (Exception)
    {
        Console.WriteLine("Invalid input. Please try again.");
        return GetInput<T>(message);
    }
}
#endregion