using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context=new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
		public ActionResult New()
		{
			var genre = _context.Genres.ToList();
			var viewModel= new MovieFormViewModel()
			{
                Movie = new Movie(),
				Genres = genre
			};
			ViewBag.pageTitle = "New Movie";

			return View("MovieForm",viewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new MovieFormViewModel()
				{
					Movie = movie,
					Genres = _context.Genres
				};
				return View("MovieForm", viewModel);
			}

			if (movie.Id == 0)
				_context.Movies.Add(movie);
			else
			{
				var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
				//TryUpdateModel(movieInDb,"",new string[]{"Name","ReleaseDate"});
				movieInDb.Name = movie.Name;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.GenreId = movie.GenreId;
				movieInDb.NumberInStock = movie.NumberInStock;
			}
			_context.SaveChanges();
			
		  
		  return  RedirectToAction("Index","Movies");
		}

		
		public ViewResult Index()
		{

			var movies = _context.Movies.Include(m=>m.Genre).ToList();
			return View( movies);
		}

		public ActionResult Details(int id)
		{
			var movie = _context.Movies.Include(m=>m.Genre).SingleOrDefault(m => m.Id == id);
			if (movie==null)
			{
				return HttpNotFound();
			}
			return View(movie);

		}

		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.Single(m => m.Id == id);
			if (movie == null)
			{
				return HttpNotFound();
			}
			
			var viewModel=new MovieFormViewModel()
				{
					Movie = movie,
					Genres = _context.Genres.ToList()
				};
			ViewBag.pageTitle = "Edit Movie";
		   
			return View("MovieForm",viewModel);
		}
		
		
		//public ActionResult ShowMovies()
		//{
		//    var movie = new List<Movie>()
		//    {
		//        new Movie(){Name =  "Shark!" ,Id = 1}
			
		//    };
		//    var customers = new List<Customer>()
		//    {
		//        new Customer(){Name="Customer 1",Id = 1},
		//        new Customer(){Name="Customer 2",Id = 2},
		//        new Customer(){Name="Customer 3",Id = 3},
		//        new Customer(){Name="Customer 4",Id = 4},
		//        new Customer(){Name="Customer 5",Id = 5},
		//        new Customer(){Name="Customer 6",Id = 6}
		//    };

		//    var viewModel=new RandomMovieViewModel()
		//    {
		//        Movie = movie,
		//        Customers=customers
		//    };
			
		//    return View(viewModel);

		//}

		
	}
}