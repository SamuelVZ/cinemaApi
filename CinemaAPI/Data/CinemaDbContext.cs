﻿using CinemaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Data {
    public class CinemaDbContext : DbContext {

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options): base(options) {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

    }
}
