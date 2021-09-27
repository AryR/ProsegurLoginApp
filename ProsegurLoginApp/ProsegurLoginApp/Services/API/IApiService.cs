using ProsegurLoginApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurLoginApp.Services.API
{
    public interface IApiService
    {
        Task<User> Login(string email, string password);
    }
}
