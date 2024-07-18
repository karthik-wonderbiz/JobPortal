using JobPortal.Data;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IUserServices
    {
        public Task<GetUserDto> GetUserByIdAsync(long id);

        public Task<IEnumerable<GetUserDto>> GetAllUsersAsync();
        public Task<GetUserDto> CreateUserAsync(CreateUserDto userDto);
        public Task<GetUserDto> UpdateUserAsync(long id, UpdateUserDto userDto);
        public Task<bool> DeleteUserAsync(long id);
    }
}
