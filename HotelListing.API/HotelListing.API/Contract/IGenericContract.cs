namespace HotelListing.API.Contract
{
    public interface IGenericContract<T> where T : class
    {
        public Task<List<T>> GetAllAsync();

        public Task<T?> GetAsync(int? id);

        public Task AddAsync(T entity);

        public Task UpdateAsync(T entity);

        public Task DeleteAsync(int id);

        public Task<bool> Exists(int id);
    }
}
