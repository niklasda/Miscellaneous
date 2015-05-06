using System.Collections.Generic;
using InterSystems.Data.CacheTypes;

namespace nida.model
{
    public class MyChild
    {
        private long? _childId;
        private long? _parentId;
        private string _name;
        private long? _age;
        private string _id;

        public MyChild(long? childId, long? parentId, string name, long? age, string id)
        {
            _childId = childId;
            _parentId = parentId;
            _name = name;
            _age = age;
            _id = id;
        }

        public long? ChildId
        {
            get { return _childId; }
        }
        public long? ParentId
        {
            get { return _parentId; }
        }
        public string Name
        {
            get { return _name; }
        }
        public long? Age
        {
            get { return _age; }
        }
        public string Id
        {
            get { return _id; }
        }
    }
}
