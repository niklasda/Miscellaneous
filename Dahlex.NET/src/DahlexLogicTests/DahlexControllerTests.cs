using System;
using System.Drawing;
using Dahlex;
//using Dahlex.Settings;
using Dahlex.Theming;
using DotNetMock.Dynamic;
using DotNetMock.Dynamic.Predicates;
using NUnit.Framework;

namespace DahlexTests
{
    /// <summary>
    /// Summary description for DahlexControllerTests
    /// </summary>
    [TestFixture]
    public class DahlexControllerTests
    {
        

        [Test]
        public void ControllerTest2()
        {
            Size boardSize = new Size(11, 11);
            Size squareSize = new Size(10, 10);

            Type tut = typeof(IDahlexView);
            
            IDynamicMock mock = new DynamicMock(tut); 
            IDahlexView viewMock = (IDahlexView)mock.Object;

            mock.Expect("Clear"); 
            mock.Expect("DrawGrid", boardSize.Width, boardSize.Height, squareSize.Width, squareSize.Height, null);
            mock.Expect("DrawBoard", new IsAnything(), squareSize.Width, squareSize.Height);
            mock.Expect("ShowStatus", 1, 1, 1, 2, new OrPredicate(new IsEqual(0), new IsEqual(1)), 30);

            mock.ExpectNoCall(tut.GetMethod("AddLineToLog").Name);
            
            //BoardDefinition def = new BoardDefinition(boardSize, squareSize);
           // Options opts = new Options();
            DahlexController controller = new DahlexController(viewMock, new Theme());
            controller.StartGame();

            
            mock.Verify();
        }

        [Test]
        public void ControllerTest3()
        {
            Size boardSize = new Size(11, 11);
            Size squareSize = new Size(10, 10);

            Type tut = typeof(IDahlexView);

            IDynamicMock mock = new DynamicMock(tut); 

        //    IDynamicGenericMock<IDahlexView> mock = new DynamicGenericMock<IDahlexView>();
            IDahlexView viewMock = (IDahlexView)mock.Object;



            mock.Expect("Clear");
            mock.Expect("DrawGrid", boardSize.Width, boardSize.Height, squareSize.Width, squareSize.Height, null);
            mock.Expect("DrawBoard", new IsAnything(), squareSize.Width, squareSize.Height);
            mock.Expect("ShowStatus", 1, 1, 1, 2, new OrPredicate(new IsEqual(0), new IsEqual(1)), 30);

          //  BoardDefinition def = new BoardDefinition(boardSize, squareSize);
           // Options opts = new Options();
            DahlexController controller = new DahlexController(viewMock, new Theme());
            controller.StartGame();

            mock.Expect("AddLineToLog", new IsTypeOf(typeof(string)));

            // calls AddLineToLog
            bool success = controller.MoveProfessorToTemp(MoveDirection.East);

            Assert.AreEqual(true, success, "Error moving prof to temp");

            mock.Verify();
        }
        
    }
}
