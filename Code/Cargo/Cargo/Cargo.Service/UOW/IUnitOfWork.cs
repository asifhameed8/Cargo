using Cargo.Core.Context;
using Cargo.Core.Repositories;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Service.UOW
{
    public interface IUnitOfWork
    {
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        long Commit();
        /// <returns>The number of objects in an Added, Modified, or Deleted state asynchronously</returns>
        Task<long> CommitAsync();
        /// <returns>Repository</returns>
        IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class;

        public List<TEntity> SpRepository<TEntity>(string SpName, params object[] parameters) where TEntity : class;
        DatabaseFacade Database();
        DatabaseContext Tables();
    }
}
