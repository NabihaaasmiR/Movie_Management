using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Services
{
    public class ConsoleMenuService
    {
        private readonly MovieService _movieService;

        public ConsoleMenuService(MovieService movieService)
        {
            _movieService = movieService;
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
                Console.WriteLine("1. View All Movies");
                Console.WriteLine("2. Find Movie by ID");
                Console.WriteLine("3. Add New Movie");
                Console.WriteLine("4. Update Movie");
                Console.WriteLine("5. Delete Movie");
                Console.WriteLine("6. Exit");
                Console.Write("\nSelect an option (1-6): ");

                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        await ViewAllMoviesAsync();
                        break;
                    case "2":
                        await FindMovieByIdAsync();
                        break;
                    case "3":
                        await AddMovieAsync();
                        break;
                    case "4":
                        await UpdateMovieAsync();
                        break;
                    case "5":
                        await DeleteMovieAsync();
                        break;
                    case "6":
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

        private async Task ViewAllMoviesAsync()
        {
            Console.WriteLine("--- All Movies ---");
            var movies = await _movieService.GetMoviesAsync();
            foreach (var m in movies)
            {
                Console.WriteLine($"ID: {m.Id} | Title: {m.Title} | Genre: {m.Genre} | Price: ${m.Price:F2} | Released: {m.ReleaseDate:yyyy-MM-dd}");
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        private async Task FindMovieByIdAsync()
        {
            Console.Write("Enter Movie ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var m = await _movieService.GetMovieAsync(id);
                if (m != null)
                {
                    Console.WriteLine($"\nFound: ID: {m.Id} | Title: {m.Title} | Genre: {m.Genre} | Price: ${m.Price:F2} | Released: {m.ReleaseDate:yyyy-MM-dd}");
                }
                else
                {
                    Console.WriteLine("Movie not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        private async Task AddMovieAsync()
        {
            Console.WriteLine("--- Add New Movie ---");
            Console.Write("Title: ");
            var title = Console.ReadLine() ?? string.Empty;

            Console.Write("Genre: ");
            var genre = Console.ReadLine() ?? string.Empty;

            Console.Write("Price: ");
            decimal.TryParse(Console.ReadLine(), out decimal price);

            var movie = new Movie
            {
                Title = title,
                Genre = genre,
                Price = price,
                ReleaseDate = DateTime.Now
            };

            await _movieService.CreateMovieAsync(movie);
            Console.WriteLine("\nMovie added successfully!");
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        private async Task UpdateMovieAsync()
        {
            Console.Write("Enter Movie ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var movie = await _movieService.GetMovieAsync(id);
                if (movie == null)
                {
                    Console.WriteLine("Movie not found.");
                }
                else
                {
                    Console.Write($"New Title [{movie.Title}]: ");
                    var title = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(title)) movie.Title = title;

                    Console.Write($"New Genre [{movie.Genre}]: ");
                    var genre = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(genre)) movie.Genre = genre;

                    Console.Write($"New Price [{movie.Price}]: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal price)) movie.Price = price;

                    await _movieService.EditMovieAsync(movie);
                    Console.WriteLine("\nMovie updated successfully!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        private async Task DeleteMovieAsync()
        {
            Console.Write("Enter Movie ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var movie = await _movieService.GetMovieAsync(id);
                if (movie == null)
                {
                    Console.WriteLine("Movie not found.");
                }
                else
                {
                    await _movieService.RemoveMovieAsync(id);
                    Console.WriteLine("\nMovie deleted successfully!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }
}