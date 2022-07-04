﻿using Application.DTOs;

using MediatR;

namespace Application.Queries
{
    public class GetAllCommentsQuery : IRequest<IEnumerable<CommentDTO>>
    {
        public Guid NewsId { get; set; }
    }
}
