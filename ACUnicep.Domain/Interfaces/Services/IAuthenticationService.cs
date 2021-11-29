using ACUnicep.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACUnicep.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<string> GerarJWT(string email, TokenSettings tokenSettings);
        string CriptografarSenha(string senha);
    }
}
