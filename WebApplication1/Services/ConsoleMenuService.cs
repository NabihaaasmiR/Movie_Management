using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Services
{
    public class ConsoleMenuService
    {
        private readonly MovieService _movieService;
        private readonly ApplicationDbContext _context; // Direct context or service for directors/actors

        public ConsoleMenuService(MovieService movieService, ApplicationDbContext context)
        {
            _movieService = movieService;
            _context = context;
        }

        public async Task RunAsync()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("       MOVIE MANAGEMENT SYSTEM          ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Manage Movies (CRUD)");
                Console.WriteLine("2. Manage Directors");
                Console.WriteLine("3. Manage Actors");
                Console.WriteLine("4. Exit");
                Console.Write("\nSelect an option (1-4): ");

                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        await ManageMoviesMenuAsync();
                        break;
                    case "2":
                        await ManageDirectorsMenuAsync();
                        break;
                    case "3":
                        await ManageActorsMenuAsync();
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("Exiting application. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private async Task ManageMoviesMenuAsync()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("--- Movie Management ---");
                Console.WriteLine("1. View All Movies");
                Console.WriteLine("2. Add New Movie");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("\nSelect an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        var movies = await _movieService.GetMoviesAsync();
                        foreach (var m in movies)
                        {
                            Console.WriteLine($"ID: {m.Id} | Title: {m.Title} | Genre: {m.Genre} | Price: ${m.Price:F2}");
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Write("Title: ");
                        var title = Console.ReadLine() ?? string.Empty;
                        Console.Write("Genre: ");
                        var genre = Console.ReadLine() ?? string.Empty;
                        Console.Write("Price: ");
                        decimal.TryParse(Console.ReadLine(), out decimal price);
                        Console.Write("Director ID: ");
                        int.TryParse(Console.ReadLine(), out int directorId);

                        var movie = new Movie
                        {
                            Title = title,
                            Genre = genre,
                            Price = price,
                            ReleaseDate = DateTime.Now,
                            DirectorId = directorId
                        };

                        await _movieService.CreateMovieAsync(movie);
                        Console.WriteLine("Movie added successfully! Press any key...");
                        Console.ReadKey();
                        break;
                    case "3":
                        back = true;
                        break;
                }
            }
        }

        private async Task ManageDirectorsMenuAsync()
        {
            Console.Clear();
            Console.WriteLine("--- Director Management ---");
            Console.WriteLine("1. View Directors (Placeholder)");
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        private async Task ManageActorsMenuAsync()
        {
            Console.Clear();
            Console.WriteLine("--- Actor Management ---");
            Console.WriteLine("1. View Actors (Placeholder)");
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }
    }
}