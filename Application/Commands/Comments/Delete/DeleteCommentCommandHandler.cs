﻿using Application.Exceptions;
using Application.Interfaces;

using MediatR;

namespace Application.Commands.Comments.Delete
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Guid>
    {
        private readonly INewsContext _context;

        public DeleteCommentCommandHandler(INewsContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteCommentCommand command, CancellationToken token)
        {

            var news = await _context.NewsL.FindAsync(command.NewsId);

            if (news == null) throw new ItemNotFoundException("News with this id does not exist");

            var comment = _context.Comments.FirstOrDefault(c => c.Id == command.Id && c.News == news);

            if (comment == null) throw new ItemNotFoundException("Comment with this id does not exist");

            _context.Comments.Remove(comment);

            await _context.SaveChangesAsync();

            return comment.Id;
        }
    }
}