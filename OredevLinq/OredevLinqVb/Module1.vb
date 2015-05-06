Option Strict Off
Option Explicit Off
Option Compare Text
Option Infer On


Imports <xmlns:y="foobar">

Module Module1


    '// volta application?

    Sub Main()
        Dim s = "ll"
        s = 11
        Dim q = "3" * 3
        '        Dim w = s.BackColor() ' background compiler detects this stuff

        ' object allows late binding

        Console.WriteLine(q)
        Console.WriteLine(s)

        ' anonymous function, late binding

        Dim x = Function(A) A > 1

        Dim Books = New Integer() {}
        Dim D = <book>foo</book>
        Dim D2 = <y:books>       ' the xml namespace is imported at top
                     <%= From b As Object In Books _
                         Select b.Title %>
                     <bar>kool</bar>
                 </y:books>
        '
        Dim D3 = <y:books>       ' the xml namespace is imported at top
                     <book>asd1</book>
                     <book>asd2</book>
                     <book>asd3</book>
                     <book>asd4</book>
                 </y:books>


        Console.WriteLine(D3)

        ' schema could be used
        ' vb has easier syntax, no select needed
        ' more freeform syntax

        ' designed to avoid lambdas

        Dim qq = From B In D3.<book> _
             Take 2 _
             Take 1 _
             Select B.Value

        Console.WriteLine(qq.Count)
        Console.WriteLine(qq)

        Dim dcsharp = New XElement("book", "foo")

        ' object initializer, different syntax from c#
        ' anonymous type are mutable in vb
        ' because they are more useful in vb with late binding
        Dim p = New With {.Name = "nikl"}
        Console.WriteLine(p.Name)
        p.Name = "Joe Duffy"
        Console.WriteLine(p.Name)

        ' Key makes field immunable, and usable in hash jion
        Dim p2 = New With {Key .Name = "nikl"}
        Console.WriteLine(p2.Name)
        '       p2.Name = "Joe Duffy"
        '      Console.WriteLine(p2.Name)





        Console.ReadLine()
    End Sub

End Module
