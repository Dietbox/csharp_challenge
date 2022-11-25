namespace Dietbox.Interview.API.Services
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public Product? Get(int id);
        public void Add(Product product);
        public void Update(Product product);
        public void Delete(int id);
    }
}
