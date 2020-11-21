using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bolgrot.Core.Common.Entity;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;

namespace Bolgrot.Core.Common.Repository
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> GetAccountByLogin(string login);
        Task<Account> GetAccountByApiKey(string apikey);
        Task<Account> GetAccountByTicket(string ticket);
    }

    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(IDbConnection databaseManager) : base(databaseManager)
        {
        }

        public async Task<Account> GetAccountByLogin(string login)
        {
            var keyValue = this.Entities().FirstOrDefault(x => x.Value is Account && x.Value.Login == login);
            Account account = (keyValue.Key == null ? null : keyValue.Value);

            if (account == null)
            {
                this.DatabaseManager.Open();

                var fetchedAccounts = await this.DatabaseManager.SelectAsync<Account>(x => x.Login == login);
                if (fetchedAccounts.Count != 0)
                {
                    account = fetchedAccounts.First();
                    this.Entities().TryAdd(account.Id, account);
                }

                this.DatabaseManager.Close();
            }

            return account;
        }

        public async Task<Account> GetAccountByApiKey(string apikey)
        {
            var keyValue = this.Entities().FirstOrDefault(x => x.Value is Account && x.Value.ApiKey == apikey);
            Account account = (keyValue.Key == null ? null : keyValue.Value);

            if (account == null)
            {
                this.DatabaseManager.Open();

                var fetchedAccounts = await this.DatabaseManager.SelectAsync<Account>(x => x.ApiKey == apikey);
                if (fetchedAccounts.Count != 0)
                {
                    account = fetchedAccounts.First();
                    this.Entities().TryAdd(account.Id, account);
                }

                this.DatabaseManager.Close();
            }

            return account;
        }
        public async Task<Account> GetAccountByTicket(string ticket)
        {
            var keyValue = this.Entities().FirstOrDefault(x => x.Value is Account && x.Value.Ticket == ticket);
            var teste = this.Entities();
            Account account = (keyValue.Key == null ? null : keyValue.Value);


            if (account == null)
            {
                string defaultname = DatabaseManager.Database;
                
                this.DatabaseManager.Open();
                DatabaseManager.ChangeDatabase("bolgrot_auth");

                var fetchedAccounts = await this.DatabaseManager.SelectAsync<Account>(x => x.Ticket == ticket);
                //var fetchedAccounts = await this.DatabaseManager.SelectAsync<Account>($"SELECT * FROM bolgrot_auth.Account WHERE bolgrot_auth.Account.Ticket =\"{ticket}\"");
                if (fetchedAccounts.Count != 0)
                {
                    account = fetchedAccounts.First();
                    this.Entities().TryAdd(account.Id, account);
                }
                DatabaseManager.ChangeDatabase(defaultname);
                this.DatabaseManager.Close();
                
            }

            return account;
        }
        //public void ForceSave() {
        //    base.PersistEntities();
        //}

    }
}