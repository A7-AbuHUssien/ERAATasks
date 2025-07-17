namespace Task_3;
public class clsBook
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool IsAvailable { get; set; }

    public clsBook(string  title, string author, string isbn, bool isAvailable = true)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        IsAvailable = isAvailable;
    }
}
public class clsLibrary
{
    public List<clsBook> _books;
    public clsLibrary()
    {
        _books = new List<clsBook>();
    }
    public bool AddBook(clsBook book)
    {
        _books.Add(book);
        return true;
    }
    public clsBook SearchByTitle(string title)
    {
        foreach (clsBook book in _books)
        {
            if (book.Title == title)
            {
                return book;
            }
        }
        return null;
    }
    public clsBook SearchByAuthorName(string Author)
    {
        foreach (clsBook book in _books)
        {
            if (book.Author == Author)
            {
                return book;
            }
        }
        return null;
    }
    public bool BorrowBook(string title)
    {
        clsBook book = SearchByTitle(title);
        if (book != null && book.IsAvailable)
        {
            book.IsAvailable = false;
            return true;
        }
        return false;
    }
    public bool ReturnBook(string title)
    {
        clsBook book = SearchByTitle(title);
        if (book != null && !book.IsAvailable)
        {
            book.IsAvailable = true;
            return true;
        }
        return false;
    }
    public List<clsBook> GetAllBooks()
    {
        return _books;
    }
}

class Program
{
    
    public static void PrintBook(clsBook book)
    {
        Console.WriteLine("===========================");
        Console.WriteLine("Title: " + book.Title);
        Console.WriteLine("Author: " + book.Author);
        Console.WriteLine("ISBN: " + book.ISBN);
        Console.WriteLine("Is Available: " + book.IsAvailable);
        Console.WriteLine("===========================");
    }
    
    public static void ShowMenue()
    {
        Console.WriteLine("\n==== Library Menu ====");
        Console.WriteLine("1. Add Book");
        Console.WriteLine("2. Search Book by Title");
        Console.WriteLine("3. Search Book by Author");
        Console.WriteLine("4. Borrow Book");
        Console.WriteLine("5. Return Book");
        Console.WriteLine("6. Show All Books");
        Console.WriteLine("7. Exit");
    }
    static void Main(string[] args)
    { 
        clsLibrary library = new clsLibrary();

        while (true)
        {
            ShowMenue();
            Console.Write("Choose an option (1-7): ");
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter ISBN: ");
                    string isbn = Console.ReadLine();

                    library.AddBook(new clsBook(title, author, isbn));
                    Console.WriteLine("Book added successfully.");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Write("Enter title to search: ");
                    string searchTitle = Console.ReadLine();
                    clsBook foundByTitle = library.SearchByTitle(searchTitle);
                    if (foundByTitle != null)
                        PrintBook(foundByTitle);
                    else
                        Console.WriteLine("Book not found.");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Write("Enter author name to search: ");
                    string searchAuthor = Console.ReadLine();
                    clsBook foundByAuthor = library.SearchByAuthorName(searchAuthor);
                    if (foundByAuthor != null)
                        PrintBook(foundByAuthor);
                    else
                        Console.WriteLine("Book not found.");
                    Console.ReadKey();
                    break;

                case "4":
                    Console.Write("Enter title to borrow: ");
                    string borrowTitle = Console.ReadLine();
                    if (library.BorrowBook(borrowTitle))
                        Console.WriteLine("Book borrowed successfully.");
                    else
                        Console.WriteLine("Book not found.");
                    Console.ReadKey();
                    break;

                case "5":
                    Console.Write("Enter title to return: ");
                    string returnTitle = Console.ReadLine();
                    if (library.ReturnBook(returnTitle))
                        Console.WriteLine("Book returned successfully.");
                    else
                        Console.WriteLine("Book not found.");
                    Console.ReadKey();
                    break;

                case "6":
                    List<clsBook> books = library.GetAllBooks();
                    if (books.Count == 0)
                    {
                        Console.WriteLine("No books in the library.");
                    }
                    else
                    {
                        int CountOfBooks = 1;
                        foreach (clsBook book in books)
                        {
                            Console.WriteLine("Book " + CountOfBooks);
                            CountOfBooks++;
                            PrintBook(book);
                        }
                    }
                    Console.ReadKey();
                    break;

                case "7":
                    Console.WriteLine("Goodbye!");
                    Console.ReadKey();
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
