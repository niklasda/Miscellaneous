
module FUnit
 
open MbUnit.Framework
open MbUnitDemo

[<TestFixture>]
type PatternMatchingFixture = class
  new() = {}

  [<Test>]
  [<Row("Niklas", 23)>]
  member x.RowPersonTest(name, age) =
    let p = Person(name, age)
    Assert.AreEqual("Niklas", p.Name) 
    Assert.AreEqual(23, p.Age) 
 
  [<Test>]
  [<Row("Niklas", 23)>]
  member x.RowTest(name, age) =
    Assert.AreEqual("Niklas", name) 
    Assert.AreEqual(23, age) 

end