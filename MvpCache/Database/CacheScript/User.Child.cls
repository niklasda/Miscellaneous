Class User.Child Extends (%Persistent, %Populate)
{

Property ChildId As %Integer [ Required ];

Relationship MyParent As User.Parent [ Cardinality = parent, Inverse = MyChildren ];

Property ParentId As %Integer [ Required ];

Property Name As %String(COLLATION = "EXACT", MAXLEN = 50) [ Required ];

Property Age As %Integer [ Required ];

Index ChildIdIndex On ChildId [ Unique ];

Query RetrieveAllChildren(parentId As %Integer) As %SQLQuery
{
SELECT %ID FROM Child
Where (ParentId)=:parentId
Order By Name
}

Query RetrieveAll() As %SQLQuery
{
SELECT %ID FROM Child
Order By Name
}

}
