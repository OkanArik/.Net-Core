using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;


namespace WebApi.DbOperations
{
    public class DataGenerator 
    {
        public static void Initiliaze(IServiceProvider serviceProvider)
        {
            using (var context= new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                   return;

                context.Authors.AddRange(
                    new Author{
                        Name = "Eric",
                        SurName = "Ries",
                        dateOfBirth = new DateTime(1978,09,22)
                    },
                    new Author{
                        Name = "Charlotte",
                        SurName = "Perkins Gilman",
                        dateOfBirth = new DateTime(1860,07,03)
                    },
                    new Author{
                        Name = "Frank",
                        SurName = "Herbert",
                        dateOfBirth = new DateTime(1920,10,08)
                    }
                );

                context.Genres.AddRange( 
                    new Genre{
                        Name = "Personal Growth",
                    },
                     new Genre{
                        Name = "Science Fiction",
                    },
                     new Genre{
                        Name = "Romance",
                    }
                );

                context.Books.AddRange(
                    new Book{
                        Title="Lean Startup",
                        GenreId=1,
                        AuthorId=1,
                        PageCount=200,
                        PublishDate=new DateTime(2001,06,12) 
                    },
                    new Book{
                        Title="Herland",
                        GenreId=2,
                        AuthorId=2,
                        PageCount=250,
                        PublishDate=new DateTime(2010,05,23) 
                    },
                    new Book{   
                        Title="Dune",
                        GenreId=2,
                        AuthorId=3,
                        PageCount=540,
                        PublishDate=new DateTime(2001,12,21) 
                    }
                );
               
                context.SaveChanges(); // Db de bir işlem yaptığımızda bu değişiklikleri kaydetmemiz gerekmektedir.
            }
        }
    }
}