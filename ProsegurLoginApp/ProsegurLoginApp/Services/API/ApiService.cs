using ProsegurLoginApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurLoginApp.Services.API
{
    public class ApiService : IApiService
    {
        public Task<User> Login(string email, string password)
        {
            User user = new User()
            {
                Email = email,
                FirstName = "Ary",
                LastName = "Regojo"
            };

            return Task.FromResult(user);
        }
    }
}
