using Microsoft.EntityFrameworkCore;
using ProductsComputing.Infra.Data;
using ProductsComputing.Model;
using ProductsComputing.Repository.Contract;

namespace ProductsComputing.Repository.Implementation
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : BaseEntity
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public RepositoryGeneric(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public T Create(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _dbContext.SaveChanges();

                return entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Delete(int id)
        {
            try
            {
                T entity = _dbSet.Where(x => x.Id.Equals(id)).FirstOrDefault();

                if (entity == null)
                    return;

                _dbSet.Remove(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public T Get(int id)
        {
            try
            {
                T entity = _dbSet.Where(x => x.Id.Equals(id)).FirstOrDefault();

                if (entity is Product)
                {
                    entity = _dbSet.Where(x => x.Equals(entity)).Include("Stock").FirstOrDefault();
                }
                return entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<T> GetAll(T entity)
        {
            try
            {
                if (entity is Product)
                    return _dbSet.Include("Stock").ToList();

                return _dbSet.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public T Update(T entity)
        {
            try
            {
                T entityAux = null;
                if (entity is Product)
                {

                    Product product = entity as Product;

                    entityAux = _dbSet.Where(x => x.Id.Equals(product.Id))
                        .Include("Stock")
                        .FirstOrDefault();

                    if (entityAux == null)
                        return null;

                    Product update = entityAux as Product;

                    product.Stock.Id = update.Stock.Id;

                    _dbContext.Entry(update.Stock).CurrentValues.SetValues(product.Stock);
                    _dbContext.SaveChanges();
                }

                entityAux = _dbSet
                    .Where(x => x.Id.Equals(entity.Id))
                    .FirstOrDefault();

                if (entityAux == null)
                    return null;

                _dbContext.Entry(entityAux).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();

                return entityAux;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
