using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using Skidly.Dtos;
using Skidly.Models;

namespace Skidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET /api/movies
        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
        {
            return _dbContext.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        // GET /api/movies/1
        [HttpGet]
        public MovieDto GetMovie(int id)
        {
            var movie = _dbContext.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Movie,MovieDto>(movie);
        }

        // POST /api/movie
        [HttpPost]
        public MovieDto CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            movieDto.Id = movie.Id;

            return movieDto;
        }

        // PUT /api/movie/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);

            _dbContext.SaveChanges();

        }

        // DELETE /api/movie/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dbContext.Movies.Remove(movieInDb);
            _dbContext.SaveChanges();
        }
    }
}
