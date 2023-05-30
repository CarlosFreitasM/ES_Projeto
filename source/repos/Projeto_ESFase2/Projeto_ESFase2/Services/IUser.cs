using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Projeto_ESFase2.Models;

namespace Projeto_ESFase2.Services
{
    public interface IUser
    {
        User GetUserById(int Id);

    }

}
