using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		//
		// GET: /Movie/Random
		
		
		public ActionResult ShowMovies()
		{
			var movie = new List<Movie>()
			{
			    new Movie(){Name =  "Shark!" ,Id = 1}
			
			};
			var customers = new List<Customer>()
			{
				new Customer(){Name="Customer 1",Id = 1},
				new Customer(){Name="Customer 2",Id = 2},
				new Customer(){Name="Customer 3",Id = 3},
				new Customer(){Name="Customer 4",Id = 4},
				new Customer(){Name="Customer 5",Id = 5},
				new Customer(){Name="Customer 6",Id = 6}
			};

			var viewModel=new RandomMovieViewModel()
			{
				Movie = movie,
				Customers=customers
			};
			
			return View(viewModel);

		}

		
	}
}