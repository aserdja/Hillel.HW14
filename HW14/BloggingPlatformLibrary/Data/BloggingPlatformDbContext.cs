using BloggingPlatformLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformLibrary.Data
{
	public class BloggingPlatformDbContext : DbContext
	{
		public virtual DbSet<Author> Authors { get; set; }
		public virtual DbSet<Article> Articles { get; set; }
		public virtual DbSet<Comment> Comments { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BloggingPlatform;Integrated Security=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Author>().HasKey(a => a.Id);
			modelBuilder.Entity<Article>().HasKey(ar => ar.Id);
			modelBuilder.Entity<Comment>().HasKey(c => c.Id);


			modelBuilder.Entity<Author>()
				.Property(a => a.Name)
				.IsRequired();

			modelBuilder.Entity<Article>()
				.Property(ar => ar.Title)
				.IsRequired();

			modelBuilder.Entity<Article>()
				.Property(ar => ar.Content)
				.IsRequired();

			modelBuilder.Entity<Comment>()
				.Property(c => c.UserName)
				.IsRequired();

			modelBuilder.Entity<Comment>()
				.Property(c => c.Content)
				.IsRequired();


			modelBuilder.Entity<Article>()
				.HasOne<Author>(ar => ar.Author)
				.WithMany(a => a.Articles)
				.HasForeignKey(ar => ar.AuthorId);

			modelBuilder.Entity<Comment>()
				.HasOne<Article>(c => c.Article)
				.WithMany(ar => ar.Comments)
				.HasForeignKey(c => c.ArticleId);
		}
	}
}
