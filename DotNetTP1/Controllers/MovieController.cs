using Microsoft.AspNetCore.Mvc;
using DotNetTP1.Models;

namespace DotNetTP1.Controllers
{
    public class MovieController : Controller
    {
        public IEnumerable<Movie> getAllMovies()
        {
            var movies = new List<Movie>()
             {
            new Movie { Id = 0, Name="Die Hard", ReleaseDate = new DateTime(2005, 12,01)},
            new Movie { Id = 1, Name = "Harry Potter", ReleaseDate = new DateTime(2003, 01, 01) },
            new Movie { Id = 2, Name = "Now You See Me", ReleaseDate = new DateTime(2016, 5, 10) },
            new Movie { Id = 3, Name = "Catch Me If You Can", ReleaseDate = new DateTime(2017, 5, 12) }
            };
            return movies;
        }


        public List<Customer> customers = new List<Customer>()
        {
            new Customer() { Id = 1,Name="Melek"},
            new Customer() { Id = 2,Name="Ahemd"},
            new Customer() { Id = 3,Name="Tarek"},

        };



        // GET: HomeController1
        public ActionResult Index()
        {
            List<Movie> movies = (List<Movie>)getAllMovies();
            return View(movies);
        }


        [Route("Movie/ByRelease/{month}/{year}")]
        public IActionResult ByRelease(int month, int year)
        {

            var movies = getAllMovies();

            var filtered = movies.Where(movie => (movie.ReleaseDate.Year == year && movie.ReleaseDate.Month == month));


            ViewBag.Month = month;
            ViewBag.Year = year;

            return View(filtered);
        }

        [Route("Movie/Customers/{id}")]
        public IActionResult CustomersByMovie(int id)
        {




            List<Movie> movies = (List<Movie>)getAllMovies();

            var m = movies.Find(movie => movie.Id == id);
            if (m == null)
            {
                return Content("Movie not found");
            }
            CustomerMovieViewModel cm = new CustomerMovieViewModel
            {
                movie = m,
                customers = this.customers
            };

            return View(cm);
        }


    }
}