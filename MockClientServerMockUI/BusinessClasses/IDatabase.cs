namespace Mockdemo.BusinessClasses
{
    public interface IDatabase
    {
        string GetVersion();
        Product GetExistingProduct(int id);
        bool ProductIdAlreadyExists(int id);
    }
}