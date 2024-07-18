using JobPortal.Data;
using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }

        public async Task<GetUserDto> CreateUserAsync(CreateUserDto userDto)
        {
            try
            {
                var User = await _userRepository.CreateAsync(new User()
                {
                    Email = userDto.Email,
                    Password = userDto.Password,
                    Contact = userDto.Contact,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
                var userData = new GetUserDto(User.Id, User.Email, User.Password, User.Contact, User.IsActive);
                return userData;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This User already exists.");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteUserAsync(long id)
        {
            try
            {
                var user = await _userRepository.GetAsync(id);

                if (user == null)
                {
                    throw new Exception($"User not found for id : {id}");
                }
                var deletedUserData = await _userRepository.DeleteAsync(user);
                return deletedUserData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetUserDto>> GetAllUsersAsync()
        {
            try
            {
                var countries = await _userRepository.GetAllAsync();
                var UserDto = countries.Select(User => new GetUserDto(User.Id, User.Email, User.Password, User.Contact, User.IsActive));
                return UserDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetUserDto> GetUserByIdAsync(long id)
        {
            try
            {
                var User = await _userRepository.GetAsync(id);

                if (User == null)
                {
                    throw new Exception($"User not found for id : {id}");
                }

                var UserData = new GetUserDto(User.Id, User.Email, User.Password, User.Contact, User.IsActive);
                return UserData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetUserDto> UpdateUserAsync(long id, UpdateUserDto UserDto)
        {
            try
            {
                var oldUser = await _userRepository.GetAsync(id);

                if (oldUser == null)
                {
                    throw new Exception($"User not found for id : {id}");
                }

                oldUser.Email = UserDto.Email;
                oldUser.Password = UserDto.Password;
                oldUser.Contact = UserDto.Contact;
                oldUser.IsActive = UserDto.IsActive;

                await _userRepository.UpdateAsync(oldUser);

                var updatedUserInfo = new GetUserDto(oldUser.Id, oldUser.Email, oldUser.Password, oldUser.Contact, oldUser.IsActive);
                return updatedUserInfo;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This User already exists.");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
