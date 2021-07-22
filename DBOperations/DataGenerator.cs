using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                   new Book()
                   {
                       Title = "Book1",
                       GenreId = 1,
                       PageCount = 200,
                       PublishDate = new DateTime(2001, 06, 12)
                   },
                   new Book()
                   {
                       Title = "Book2",
                       GenreId = 2,
                       PageCount = 500,
                       PublishDate = new DateTime(2012, 02, 09)
                   },
                    new Book()
                    {
                        Title = "Book3",
                        GenreId = 3,
                        PageCount = 100,
                        PublishDate = new DateTime(2020, 11, 22)
                    });

                context.SaveChanges();
            }
        }
    }
}