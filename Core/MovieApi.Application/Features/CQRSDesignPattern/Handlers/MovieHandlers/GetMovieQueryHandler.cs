using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Feautures.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly MovieContext _context;
        public GetMovieQueryHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<GetMovieByIdQueryResult> Handle()
        {
            var movie = await _context.Movies.ToListAsync();

           return movie.Select(x => new GetMovieByIdQueryResult
           {
               MovieId = x.MovieId,
               Title = x.Title,
               CoverImageUrl = x.CoverImageUrl,
               Rating = x.Rating,
               Description = x.Description,
               Duration = x.Duration,
               ReleaseDate = x.ReleaseDate,
               CreatedYear = x.CreatedYear,
               Status = x.Status
           }).FirstOrDefault();
        }
    }
}
