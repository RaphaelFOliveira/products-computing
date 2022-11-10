namespace ProductsComputing.Repository.Contract
{
    public interface IRepositoryGeneric<T>
    {
        public T Get(int id);
        public List<T> GetAll(T entity);
        public T Update(T entity);
        public void Delete(int id);
        public T Create(T entity);
    }
}
