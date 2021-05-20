using System;
using cs_all_spell.Models;
using cs_all_spell.Repositories;

namespace cs_all_spell.Services
{
    public class AccountsService
    {
        private readonly AccountsRepository _repo;

        public AccountsService(AccountsRepository repo)
        {
            _repo = repo;
        }
        internal Account GetOrCreateAccount(Account userInfo)
        {
            Account account = _repo.GetById(userInfo.Id);
            if (account == null)
            {
                return _repo.Create(userInfo);
            }
            return account;
        }
    }
}