module FUnit
 
open MbUnit.Framework
open ClassLibrary1

[<TestFixture>]
type PatternMatchingFixture = class
  new() = {}

  [<Test>]
  [<Row("Niklas", 23)>]
  member x.RowTest(name, age) =
    Assert.AreEqual("Niklas", name) 
    Assert.AreEqual(23, age) 

end