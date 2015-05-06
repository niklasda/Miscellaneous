using System.Collections.Generic;
using InterSystems.Data.CacheTypes;

namespace nida.model
{
    public class MyParent
    {
        private long? _parentId;
        private string _name;
        private CacheDate _lastLogin;
        private string _id;
        private int _childCount;
        private List<MyChild> _children = new List<MyChild>();

        public MyParent(long? parentId, string name, CacheDate lastLogin, string id, int childCount)
        {
            _parentId = parentId;
            _name = name;
            _lastLogin = lastLogin;
            _childCount = childCount;
            _id = id;
        }

        public long? ParentId
        {
            get { return _parentId; }
        }
        public string Name
        {
            get { return _name; }
        }
        public CacheDate LastLogin
        {
            get { return _lastLogin; }
        }
        public int ChildCount
        {
            get { return _childCount; }
        }
        public string Id
        {
            get { return _id; }
        }

        public List<MyChild> Children
        {
            get { return _children; }
        }
    }
}
