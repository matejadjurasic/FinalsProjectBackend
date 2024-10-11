using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.Exceptions;
using FitnessPal.Application.Features.Users.Requests.Commands;
using FitnessPal.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Users.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Email = request.UserCreateDto!.Email,
                Name = request.UserCreateDto.Name,
                UserName = request.UserCreateDto.Email,
                NormalizedUserName = request.UserCreateDto.Email.ToUpper(),
                NormalizedEmail = request.UserCreateDto.Email.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            var password = $"{user.Name}123";
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);

            try
            {
                await _unitOfWork.UserRepository.AddAsync(user);
                await _unitOfWork.Save();

                await _unitOfWork.UserRepository.AddUserToClientRole(user);
                await _unitOfWork.Save();
            }
            catch (DbUpdateException)
            {
                throw new DuplicateEmailException("A user with this email already exists.");
            }
            catch (Exception)
            {
                throw;
            }

            return user.Id;
        }
    }
}
