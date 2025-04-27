using MovieApi.Application.Feautures.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Feautures.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _context;
        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery request)
        {
            var movie = await _context.Movies.FindAsync(request.MovieId);
            return new GetMovieByIdQueryResult
            {
                
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Status = movie.Status,
                Rating = movie.Rating,
                CoverImageUrl = movie.CoverImageUrl,
                Duration = movie.Duration,
                CreatedYear = movie.CreatedYear,



            };
        }
    }
}
