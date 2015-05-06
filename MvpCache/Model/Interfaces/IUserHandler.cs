using System.Collections.Generic;

namespace nida.model
{
    public interface IUserHandler
    {
        List<MyChild> RetrieveChildren(int? parentId);
        List<MyChild> RetrieveChildren();
        List<MyParent> RetrieveParents();
        void Create(int id, string name);
        void Delete(string id);
    }
}