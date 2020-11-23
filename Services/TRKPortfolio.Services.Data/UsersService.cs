namespace TRKPortfolio.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TRKPortfolio.Data.Common.Repositories;
    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Data.Contracts;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepo;

        public UsersService(IDeletableEntityRepository<ApplicationUser> userRepo)
        {
            this.userRepo = userRepo;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.userRepo.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.UserName,
                }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.UserName));
        }
    }
}
