namespace Dietbox.Interview.API.Services
{
    public class ProductService : IProductService
    {
        private List<Product> _products;
        public ProductService()
        {
            _products = new List<Product>
            {
                new Product { Id = 0, Name = "Camiseta Bege", Description = "Camiseta Bege", Price = 10.00m },
                new Product { Id = 1, Name = "Camiseta Azul", Description = "Camiseta Azul", Price = 15.00m },
                new Product { Id = 2, Name = "Camiseta Preta", Description = "Camiseta Preta", Price = 20.00m },                
            };
        }
        
        public void Add(Product product)
        {
            if (_products.Any(x => x.Id == product.Id))
                throw new Exception();
            
            _products.Add(product);
        }

        public void Delete(int id)
        {
            var product = Get(id);
            if (product == null) throw new Exception();
            _products.Remove(product);
        }

        public Product? Get(int id)
        {
            return _products.Find(x => x.Id == id);
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public void Update(Product product)
        {
            var dbProduct = Get(product.Id);
            
            if (dbProduct == null) throw new Exception();
            
            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.Price = product.Price;
        }
    }
}
