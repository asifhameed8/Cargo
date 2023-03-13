using Cargo.Core.Repositories;
using Cargo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Service.QuotesSrv
{
    public interface IQuotesServices
    {
        Task<QuotesDetailsVM> GetRandomQuotes();
        Task<ListAuthorDetailsVM> GetAllAuthor(string AuthorName, int Limit, string Filds);
    }
}
