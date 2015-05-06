Imports System.Runtime.CompilerServices

Public Class VbSyntaxClass

    Public Sub New()
        Dim list As ICollection(Of String) = New List(Of String)

    End Sub

    <Dynamic()>
    Public ReadOnly Property SomeProp As Object
        Get
            Return 123
        End Get
    End Property

    Public Function Stuff(ByVal name As String) As String
        Return "test"
    End Function






    ' auto prop
    Public Property CustomerID As Integer

    ' collection initializer
    Dim words As New List(Of String) From {"Hello", "World"}
End Class





Public Interface IWhat(Of Out T)
    Function Give(ByVal name As String) As T
End Interface

Public Interface IWho(Of In T)
    Function Give(ByVal name As T) As String
End Interface
