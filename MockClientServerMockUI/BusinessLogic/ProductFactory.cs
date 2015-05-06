using Mockdemo.BusinessClasses;
using Mockdemo.Server;

namespace Mockdemo.BusinessLogic
{
    public class ProductFactory
    {
        public ProductFactory(IDatabase database)
        {
            db = database;
        }
        public ProductFactory(bool connected)
        {
            db = new Database(connected);
        }
        private IDatabase db;
        
        public Product CreateNewProduct(int id)
        {
            bool alreadyExists = db.ProductIdAlreadyExists(id);

            if(alreadyExists)
            {
                throw new BusinessException( string.Format("Product id={0} already exists", id));
            }
            return new Product(id);
        }

        public Product GetExistingProduct(int id)
        {
            Product existing = db.GetExistingProduct(id);
            
            if(existing == null)
            {
                throw new BusinessException( string.Format("Product id={0} does not exist", id) );                
            }
            return existing;
        }

    }
}
