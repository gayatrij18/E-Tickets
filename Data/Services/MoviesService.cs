
using E_Tickets.Data.Base;
using E_Tickets.Data.ViewModels;
using E_Tickets.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Data.Services
{
    public class MoviesService:EntityBaseRepository<Movie>, IMoviesService
    {
        public readonly AppDbContext _context;
        public MoviesService(AppDbContext context):base(context)
        {
            _context = context;


        }

        public async Task AddNewMovieAsync(NewMovieVM newMovie)
        {
            var newMovieData = new Movie()
            {
                Name = newMovie.Name,
                Description = newMovie.Description,
                Price = newMovie.Price,
                ImageURL = newMovie.ImageURL,
                CinemaId = newMovie.CinemaId,
                StartDate = newMovie.StartDate,
                EndDate = newMovie.EndDate,
                MovieCategory = newMovie.MovieCategory,
                ProducerId = newMovie.ProducerId,

            };
            await _context.Movies.AddAsync(newMovieData);
            await _context.SaveChangesAsync();


            foreach (var actorId in newMovie.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovieData.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);

            }
            await _context.SaveChangesAsync();
        }
       

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropDownValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()

        };
            
            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVM newMovie)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == newMovie.Id);
            if(dbMovie != null)
            {

                    dbMovie.Name = newMovie.Name;
                dbMovie.Description = newMovie.Description;
                dbMovie.Price = newMovie.Price;
                dbMovie.ImageURL = newMovie.ImageURL;
                dbMovie.CinemaId = newMovie.CinemaId;
                dbMovie.StartDate = newMovie.StartDate;
                dbMovie.EndDate = newMovie.EndDate;
                dbMovie.MovieCategory = newMovie.MovieCategory;
                dbMovie.ProducerId = newMovie.ProducerId;
                    
              
                await _context.SaveChangesAsync();


            }
            var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == newMovie.Id).ToList();



            foreach (var actorId in newMovie.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovieData.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);

            }
            await _context.SaveChangesAsync();
        }
    }
}
