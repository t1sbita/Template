using Template.Api.Core.Domain.Entities.Base;
using Template.Api.Core.Util;
using Template.Api.Infrastructure.Data.Context;
using Template.Api.Infrastructure.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Template.Api.Infrastructure.Data.Repository.Base
{

    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : BaseEntity
    {
        private bool _disposed;
        protected readonly TemplateContext Context;
        private DbSet<T> Entities { get; set; }

        public BaseRepository(TemplateContext context)
        {
            Context = context;
            Entities = context.Set<T>();
        }

        private IQueryable<T> Query(params Expression<Func<T, object>>[] includes)
        {
            var query = Entities.AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                    if (include != null)
                        query = query.Include(include);
            }
            return query;
        }

        public T Get(Expression<Func<T, bool>> filters, params Expression<Func<T, object>>[] includes)
        {
            var query = Query(includes).AsNoTracking();

            if (filters != null)
                return query.Where(filters).SingleOrDefault();

            return query.SingleOrDefault();
        }

        public T GetById(long Id, params Expression<Func<T, object>>[] includes)
        {
            return Query(includes).SingleOrDefault(i => i.Id.Equals(Id));
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> filters = null,
            params Expression<Func<T, object>>[] includes)
        {
            var query = Query(includes).AsNoTracking();

            if (filters != null)
                query = query.Where(filters);

            return query;
        }

        public List<T> GetAll(Expression<Func<T, bool>> filters = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> sortedBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            var query = Query(includes).AsNoTracking();

            if (filters != null)
                query = query.Where(filters);

            if (sortedBy != null)
                query = sortedBy(query);

            return query.ToList();
        }

        public PageConsultation<T> GetAllPaged(int page, int itemsByPage,
            ICollection<Expression<Func<T, bool>>> filters = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> sortedBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            var query = Query(includes).AsNoTracking();

            PageConsultation<T> pageConsultation = new PageConsultation<T>();

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            int total = query.Count();

            if (sortedBy != null)
                query = sortedBy(query);
            else
                query = query.OrderBy(o => o.Id);

            if (page < 1)
                page = 1;

            pageConsultation.NumberPage = page;
            pageConsultation.SizePage = itemsByPage;
            pageConsultation.TotalRecords = total;

            if (pageConsultation.TotalRecords > 0 && pageConsultation.SizePage > 0)
            {
                pageConsultation.TotalPages = pageConsultation.TotalRecords / pageConsultation.SizePage;

                if (pageConsultation.TotalRecords % pageConsultation.SizePage > 0)
                {
                    pageConsultation.TotalPages++;
                }
            }

            pageConsultation.List = query.Skip(itemsByPage * (page - 1)).Take(itemsByPage).ToList();

            return pageConsultation;
        }

        public T Add(T Entity)
        {
            if (Entity == null)
                throw new ArgumentNullException(typeof(T).FullName);

            var retorno = Entities.Add(Entity);

            return retorno.Entity;
        }

        public T Update(T Entity)
        {
            if (Entity == null)
                throw new ArgumentNullException(typeof(T).FullName);

            T exist = Entities.SingleOrDefault(t => t.Id == Entity.Id);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(Entity);
                return Entity;
            }

            return null;
        }

        public bool Delete(long Id)
        {
            T exist = Entities.SingleOrDefault(t => t.Id == Id);
            if (exist != null)
            {
                Entities.Remove(exist);
                return true;
            }

            return false;
        }

        public bool Delete(T entityToDelete)
        {
            if (entityToDelete == null)
                throw new ArgumentNullException(typeof(T).FullName);

            T exist = Entities.SingleOrDefault(t => t.Id == entityToDelete.Id);
            if (exist != null)
            {
                Entities.Remove(exist);
                return true;
            }

            return false;
        }

        public void Attach(T entity) => Context.Attach(entity);
        
        public void Save()
        {
            Context.SaveChanges();
        }

        public void CreateTransaction()
        {
            Context.Database.BeginTransaction();
        }
        public void Commit()
        {
            Context.Database.CommitTransaction();
        }
        public void Rollback()
        {
            Context.Database.RollbackTransaction();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                Context.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
