using Ensek.BLL.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;
using Ensek.Entity.Entities;
using Ensek.DAL.Repositories;
using Ensek.DAL.Repositories.IRepositories;

namespace Ensek.BLL.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Task<List<Account>> GetAccounts()
        {
            var accounts = _accountRepository.GetList();
            return accounts;
        }
    }
}
