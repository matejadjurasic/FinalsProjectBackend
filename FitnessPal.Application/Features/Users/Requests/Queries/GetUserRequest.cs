﻿using FitnessPal.Application.DTOs.UserDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Users.Requests.Queries
{
    public class GetUserRequest : IRequest<UserReadDto>
    {
        public int Id { get; set; }
    }
}