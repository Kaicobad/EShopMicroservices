﻿namespace Catalog.API.AppDbContext
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
