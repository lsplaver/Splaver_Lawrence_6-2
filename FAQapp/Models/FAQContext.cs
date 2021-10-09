using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FAQapp.Models
{
    public class FAQContext : DbContext
    {
        public FAQContext(DbContextOptions<FAQContext> options) : base(options)
        { }

        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FAQ>().HasData(
                new FAQ
                {
                    FAQId = 1,
                    Name = "Nightwish",
                    YearFormed = "1996",
                    GenreId = "sym-metal",
                    CategoryId = "hist"
                },
                new FAQ
                {
                    FAQId = 2,
                    Name = "Nightwish",
                    Description = "Finland's Nightwish are an award-winning, best-selling symphonic metal band fronted by Floor Jansen, their third female vocalist.",
                    GenreId = "sym-metal",
                    CategoryId = "gen"
                },
                new FAQ
                {
                    FAQId = 3,
                    Name = "Nightwish",
                    BandWebsite = "https://www.nightwish.com/",
                    SecondLink = "https://open.spotify.com/artist/2NPduAUeLVsfIauhRwuft1",
                    GenreId = "sym-metal",
                    CategoryId = "link"
                },
                new FAQ
                {
                    FAQId = 4,
                    Name = "DragonForce",
                    YearFormed = "1999",
                    GenreId = "spd-metal",
                    CategoryId = "hist"
                },
                new FAQ
                {
                    FAQId = 5,
                    Name = "DragonForce",
                    Description = "Known as the fastest band in the world, Grammy-nominated extreme power metal band DragonForce is based in London, England.",
                    GenreId = "spd-metal",
                    CategoryId = "gen"
                },
                new FAQ
                {
                    FAQId = 6,
                    Name = "DragonForce",
                    BandWebsite = "https://dragonforce.com/",
                    SecondLink = "https://open.spotify.com/artist/2pH3wEn4eYlMMIIQyKPbVR",
                    GenreId = "spd-metal",
                    CategoryId = "link"
                },
                new FAQ
                {
                    FAQId = 7,
                    Name = "Battle Beast",
                    YearFormed = "2005",
                    GenreId = "pow-metal",
                    CategoryId = "hist"
                },
                new FAQ
                {
                    FAQId = 8,
                    Name = "Battle Beast",
                    Description = "Famous for their energetic shows, incredibly catchy choruses and odd sense of humour, Finland’s Battle Beast are destined for glory.",
                    GenreId = "pow-metal",
                    CategoryId = "gen"
                },
                new FAQ
                {
                    FAQId = 9,
                    Name = "Battle Beast",
                    BandWebsite = "https://battlebeast.fi/",
                    SecondLink = "https://open.spotify.com/artist/7k5jeohQCF20a8foBD9ize",
                    GenreId = "pow-metal",
                    CategoryId = "link"
                }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = "sym-metal", Name = "Symphonic Metal" },
                new Genre { GenreId = "spd-metal", Name = "Speed Metal" },
                new Genre { GenreId = "pow-metal", Name = "Power Metal" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "hist", Name = "History" },
                new Category { CategoryId = "gen", Name = "General" },
                new Category { CategoryId = "link", Name = "Websites" }
            );
        }
    }
}
