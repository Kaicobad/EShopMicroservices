﻿using Basket.API.Models;

namespace Basket.API.AppDbContext
{
    public class BasketContext :DbContext
    {
        public BasketContext(DbContextOptions<BasketContext> options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ShoppingCartItem>().HasNoKey();
        }
        DbSet<ShoppingCart> ShoppingCarts { get; set; }
        DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
