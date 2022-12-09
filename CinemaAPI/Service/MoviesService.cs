﻿using AutoMapper;
using CinemaAPI.Dto;
using CinemaAPI.Models;
using CinemaAPI.Repository;
using System.Data;

namespace CinemaAPI.Service {
    public class MoviesService : IMoviesService {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;

        public MoviesService(IMoviesRepository moviesRepository, IMapper mapper) {
            this._moviesRepository = moviesRepository;
            this._mapper = mapper;
        }

        public List<Movie> GetAllMovies() {
            return _moviesRepository.GetAllMovies();
        }

        public Movie GetMovieById(int id) {
            return _moviesRepository.GetMovieById(id);
        }

        public MovieDto AddMovie(AddMovieDto addMoviedto) {
            Movie movie = _mapper.Map<AddMovieDto, Movie>(addMoviedto);

            Movie addedMovie = _moviesRepository.AddMovie(movie);

            MovieDto addedMovieDto = _mapper.Map<Movie, MovieDto>(addedMovie);

            return addedMovieDto;
        }

        public Movie UpdateMovie(int id, AddMovieDto updateMovieDto) {
            var movie = GetMovieById(id);
            return movie != null ? _moviesRepository.UpdateMovie(id, updateMovieDto) : null;
        }

        public bool DeleteMovie(int id) {

            var movie = GetMovieById(id);

            if(movie == null) {
                return false;
            }

            _moviesRepository.DeleteMovie(movie);
            return true;

        }
    }
}
