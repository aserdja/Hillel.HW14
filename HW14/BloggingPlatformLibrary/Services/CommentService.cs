using BloggingPlatformLibrary.Interfaces;
using BloggingPlatformLibrary.Models;

namespace BloggingPlatformLibrary.Services
{
	public class CommentService(IRepository<Comment> repository)
	{
		private readonly IRepository<Comment> _repository = repository;

		public async Task AddComment(Comment comment)
		{
			await _repository.Add(comment);
		}

		public async Task RemoveComment(Comment comment)
		{
			await _repository.Delete(comment);
		}

		public async Task UpdateComment(Comment comment)
		{
			await _repository.Update(comment);
		}

		public async Task<Comment> GetCommentById(int id)
		{
			return await _repository.Get(id);
		}
	}
}
