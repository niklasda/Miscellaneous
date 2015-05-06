Class User.Parent Extends (%Persistent, %Populate)
{

Property ParentId As %Integer [ Required ];

Property Name As %String(COLLATION = "EXACT", MAXLEN = 50) [ Required ];

Property LastLogin As %Date;

Relationship MyChildren As User.Child [ Cardinality = children, Inverse = MyParent ];

Index ParentIdIndex On ParentId [ Unique ];

Query RetrieveAll() As %SQLQuery
{
SELECT %ID FROM Parent
Order By Name
}

}
