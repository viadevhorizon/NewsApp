﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.DTOs;

using MediatR;

namespace Application.Queries
{
    public class GetCommentByIdQuery : IRequest<CommentDTO>
    { 
        public Guid Id { get; set; }

        public Guid NewsId { get; set; }
    }
}
