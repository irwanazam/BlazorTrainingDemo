using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorTrainingDemo.Services
{
    public class AsyncQueryExecutor<TEntity> : IAsyncQueryExecutor<TEntity> where TEntity : class
    {
        public Task<int> CountAsync(IQueryable<TEntity> source, CancellationToken cancellationToken = default)
        {
            return source.CountAsync(cancellationToken);
        }

        public Task<List<TEntity>> ToListAsync(IQueryable<TEntity> source, CancellationToken cancellationToken = default)
        {
            return source.ToListAsync(cancellationToken);
        }
    }

    public interface IAsyncQueryExecutor<TEntity> where TEntity : class
    {
        Task<int> CountAsync(IQueryable<TEntity> source, CancellationToken cancellationToken = default);
        Task<List<TEntity>> ToListAsync(IQueryable<TEntity> source, CancellationToken cancellationToken = default);
    }
}
