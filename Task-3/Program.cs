namespace Task_3
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Availability { get; set; }
        
        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Availability = true; 
        }
    }

    class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"The book '{book.Title}' added to the library.");
        }

        public Book SearchBook(string searchText)
        {
            foreach (Book book in books)
            {
                if (book.Title.Contains(searchText) || book.Author.Contains(searchText))
                {
                    return book;
                }
            }
            return null; 
        }

        
        public void BorrowBook(string title)
        {
            Book book = SearchBook(title);
            if (book == null)
            {
                Console.WriteLine($"The book '{title}' is not available in the library.");
            }
            else if (!book.Availability)
            {
                Console.WriteLine($"The book '{book.Title}' is currently borrowed.");
            }
            else
            {
                book.Availability = false;
                Console.WriteLine($"You have borrowed the book '{book.Title}'.");
            }
        }

        public void ReturnBook(string title)
        {
            Book book = SearchBook(title);
            if (book == null)
            {
                Console.WriteLine($"The book '{title}' is not in the library.");
            }
            else if (book.Availability)
            {
                Console.WriteLine($"The book '{book.Title}' was not borrowed.");
            }
            else
            {
                book.Availability = true;
                Console.WriteLine($"You have returned the book '{book.Title}'.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));
            library.AddBook(new Book("Clean Code", "Robert C. Martin", "9780132350884"));
            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

        }
    }
}
