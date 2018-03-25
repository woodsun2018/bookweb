using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Linq;

namespace BookWeb
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> books { get; set; }

    }

    public static class SeedBookData
    {
        public static void SeedDB(BookDbContext context)
        {
            //重要：如果数据库完全为空，可以自动创建数据库！
            context.Database.EnsureCreated();

            // DB has been seeded
            if (context.books.Any())
                return;

            context.books.AddRange(
                  new Book() { Name = "射雕英雄传", PublishDate = new DateTime(1964, 1, 1), Author = "金庸", Price = 9.5f, },
                  new Book() { Name = "神雕侠侣", PublishDate = new DateTime(1965, 3, 1), Author = "金庸", Price = 10.5f, },
                  new Book() { Name = "倚天屠龙记", PublishDate = new DateTime(1968, 12, 1), Author = "金庸", Price = 12, }
                  );

            context.SaveChanges();
        }
    }
}
