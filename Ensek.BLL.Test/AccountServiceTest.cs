using Ensek.BLL.Services;
using Ensek.DAL.Repositories.IRepositories;
using Ensek.Entity.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Ensek.BLL.Test
{
    [TestClass]
    public class AccountServiceTest
    {
        private Services.IServices.IAccountService accountService;
        private List<Account> _accountList;

        [TestInitialize]
        public void Setup()
        {
            _accountList = new List<Account>()
            {
                new Account()
                {
                    AccountId =1,
                    FirstName ="Sam",
                    LastName = "Alkmos"
                }
            };

            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(a => a.GetList(null)).ReturnsAsync(_accountList);
            accountService = new AccountService(accountRepositoryMock.Object);
        }

      
        [TestMethod]
        public void GetAccounts_ShouldReturnAccountsList()
        {
            var accounts = accountService.GetAccounts().Result;

            Assert.AreEqual(accounts.Count, _accountList.Count);
            Assert.AreEqual(accounts[0].FirstName, _accountList[0].FirstName);
            Assert.AreEqual(accounts[0].LastName, _accountList[0].LastName);

        }
    }
}