﻿using AutoMapper;
using Core.Constants;
using Core.DTO;
using Core.Entities.UserEntity;
using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.CustomService;
using Core.Resources;
using Core.Specifications;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Security.Claims;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<IdentityUserRole<string>> _userRoleRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(
            IRepository<User> userRepository,
            IRepository<IdentityUserRole<string>> userRoleRepository,        
            IMapper mapper,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;           
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;          
        }

        public string GetCurrentUserNameIdentifier(ClaimsPrincipal currentUser)
        {
            return currentUser.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public async Task<UserProfileInfoDTO> GetUserProfileInfoAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            ExceptionMethods.UserNullCheck(user);

            return _mapper.Map<UserProfileInfoDTO>(user);
        }

        public async Task<string> GetUserRoleAsync(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            if (userRoles == null)
            {
                throw new HttpException(ErrorMessages.RoleNotFound, HttpStatusCode.NotFound);
            }

            return userRoles.First(); // we get only the first role, because the user will have only one
        }

        public async Task UserEditProfileInfoAsync(UserEditProfileInfoDTO userEditProfileInfo, string userId, string callbackUrl)
        {
            var updateUser = await _userRepository.GetByIdAsync(userId);

            ExceptionMethods.UserNullCheck(updateUser);

            updateUser.Name = userEditProfileInfo.Name;
            updateUser.Surname = userEditProfileInfo.Surname;

            if (!userEditProfileInfo.Email.Equals(updateUser.Email))
            {
                if (await _userRepository.AnyAsync(new UserSpecification.GetByEmail(userEditProfileInfo.Email)))
                {
                    throw new HttpException(ErrorMessages.FailedSendEmail, HttpStatusCode.BadRequest);
                }

                updateUser.Email = userEditProfileInfo.Email;
                updateUser.UserName = userEditProfileInfo.Email;
                updateUser.NormalizedEmail = userEditProfileInfo.Email.ToUpper();
                updateUser.NormalizedUserName = userEditProfileInfo.Email.ToUpper();
                updateUser.EmailConfirmed = false;
                
                //await _emailService.SendConfirmationEmailAsync(updateUser, callbackUrl);
            }

            await _userRepository.UpdateAsync(updateUser);
        }

        public async Task<UserFullNameDTO> GetUserFullNameAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            ExceptionMethods.UserNullCheck(user);

            return _mapper.Map<UserFullNameDTO>(user);
        }

        public async Task<PaginatedList<UserDTO>> GetAllUsersAsync(PaginationFilterDTO paginationFilter)
        {
            var roleId = (await _roleManager.FindByNameAsync(IdentityRoleNames.User.ToString())).Id;

            var userRolesCount = await _userRoleRepository
                .CountAsync(new IdentityUserRoleSpecification.GetUserRoleByRoleId(roleId, paginationFilter));

            int totalPages = PaginatedList<UserDTO>.GetTotalPages(paginationFilter, userRolesCount);

            if (totalPages == 0)
            {
                return null;
            }

            var userRoles = await _userRoleRepository
                .ListAsync(
                new IdentityUserRoleSpecification
                .GetUserRoleByRoleId(roleId, paginationFilter));

            List<string> userIds = new List<string>();

            foreach(var userRole in userRoles)
            {
                userIds.Add(userRole.UserId);
            }

            var userList = await _userRepository
                .ListAsync(new UserSpecification.GetByIds(userIds));

            return PaginatedList<UserDTO>
                .Evaluate(_mapper.Map<List<UserDTO>>(userList), paginationFilter.PageNumber, userRolesCount, totalPages);
        }

        public async Task<string> GetUserIdByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            ExceptionMethods.UserNullCheck(user);

            return user.Id;
        }
    }
}
