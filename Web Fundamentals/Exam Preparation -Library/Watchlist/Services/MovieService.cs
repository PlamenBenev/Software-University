using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Services
{
	public class MovieService : IMovieService
	{
		private readonly WatchlistDbContext context;

		public MovieService(WatchlistDbContext _context)
		{
			context = _context;
		}

		public async Task AddMovieAsync(AddMovieViewModel movieModel)
		{
			var entity = new Movie()
			{
				Director = movieModel.Director,
				GenreId = movieModel.GenreId,
				ImageUrl = movieModel.ImageUrl,
				Rating = movieModel.Rating,
				Title = movieModel.Title,
			};

			await context.Movies.AddAsync(entity);
			await context.SaveChangesAsync();
		}

		public async Task AddMovieToCollectionAsync(int movieId, string userId)
		{
			var user = await context.Users
				.Where(u => u.Id == userId)
				.Include(u => u.UsersMovies)
				.FirstOrDefaultAsync();

			if (user == null)
			{
				throw new ArgumentException("Invalid User Id");
			}

			var movie = await context.Movies.FindAsync(movieId);

			if (movie == null)
			{
				throw new ArgumentException("Invalid Movie Id");
			}

			if (!user.UsersMovies.Any(m => m.MovieId == movieId))
			{
				user.UsersMovies.Add(new UserMovie()
				{
					MovieId = movieId,
					UserId = userId,
				});

				await context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<MovieViewModel>> GetAllAsync()
		{
			var entities = await context.Movies.ToListAsync();

			return entities
				.Select(x => new MovieViewModel()
				{
					Id = x.Id,
					Title = x.Title,
					Director = x.Director,
					Genre = x?.Genre?.Name,
					ImageUrl = x.ImageUrl,
					Rating = x.Rating,
				});
		}

		public async Task<IEnumerable<Genre>> GetGenresAsync()
		{
			return await context.Genres.ToListAsync();
		}

		public async Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId)
		{
			var user = await context.Users
				.Where(u => u.Id == userId)
				.Include(u => u.UsersMovies)
				.ThenInclude(um => um.Movie)
				.ThenInclude(m => m.Genre)
				.FirstOrDefaultAsync();

			if (user == null)
			{
				throw new ArgumentException("Invalid User Id");
			}

			return user.UsersMovies.Select(x => new MovieViewModel()
			{
				Director = x.Movie.Director,
				Genre = x.Movie.Genre?.Name,
				ImageUrl = x.Movie.ImageUrl,
				Rating = x.Movie.Rating,
				Id = x.MovieId,
				Title = x.Movie.Title,
			});
		}

		public async Task RemoveMovieFromCollectionAsync(int movieId, string userId)
		{
			var user = await context.Users
				.Where(u => u.Id == userId)
				.Include(u => u.UsersMovies)
				.FirstOrDefaultAsync();

			if (user == null)
			{
				throw new ArgumentException("Invalid User Id");
			}

			var movie = user.UsersMovies.FirstOrDefault(m => m.MovieId == movieId);

			if (movie != null)
			{
				 user.UsersMovies.Remove(movie);

				await context.SaveChangesAsync();
			}
		}
	}
}
