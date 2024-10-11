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
			optionsBuilder.UseSqlServer("");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
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

			modelBuilder.Entity<Comment>()
				.Property(c => c.Rating)
				.IsRequired();


			modelBuilder.Entity<Author>()
				.HasMany<Article>(a => a.Articles)
				.WithOne(ar => ar.Author)
				.HasForeignKey(ar => ar.AuthorId);

			modelBuilder.Entity<Article>()
				.HasMany<Comment>(ar => ar.Comments)
				.WithOne(c => c.Article)
				.HasForeignKey(c => c.ArticleId);
		}
	}
}
