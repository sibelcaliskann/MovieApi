﻿using MovieApi.Application.Feautures.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly MovieContext _context;
        public RemoveMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async void Handle(RemoveMovieCommand command)
        {
            var value = await _context.Movies.FindAsync(command.MovieId);
            _context.Movies.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
