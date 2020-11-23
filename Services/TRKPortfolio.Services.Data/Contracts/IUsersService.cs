namespace TRKPortfolio.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IUsersService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
