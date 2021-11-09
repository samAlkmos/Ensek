using Ensek.Entity.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ensek.BLL.Services.IServices
{
    public interface IAccountService
    {
        Task<List<Account>> GetAccounts();
    }
}
