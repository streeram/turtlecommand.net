//---------------------------------------------------------------------------------
// <copyright file="TurtleTests.cs" company="Cognizant Technology Solutions.">
//     © 2017 Cognizant. All Rights Reserved.
// </copyright>
//---------------------------------------------------------------------------------
namespace TurtlePuzzle.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TurtlePuzzle.Core;

    /// <summary>
    /// Unit Test Class
    /// </summary>
    [TestClass]
    public class TurtleTests
    {
        /// <summary>
        /// Instance of the Gameboard
        /// </summary>
        private GameBoard board;

        /// <summary>
        /// Turtle Initialized But Not Placed - CannotBeMoved
        /// </summary>
        [TestMethod]
        public void Turtle_InitializedButNotPlaced_CannotBeMoved()
        {
            // setup
            this.SetupTurtleTestsInitialize();

            // execute MOVE
            var result = this.board.ExecuteCommand(TurtleInstruction.Move.ToString());

            // assert
            Assert.AreEqual("Turtle cannot MOVE until it has been placed on the table.", result);
        }

        /// <summary>
        /// Turtle Initialized But Not Placed - CannotBeTurned
        /// </summary>
        [TestMethod]
        public void Turtle_InitializedButNotPlaced_CannotBeTurned()
        {
            // setup
            this.SetupTurtleTestsInitialize();
            
            // execute LEFT
            var result = this.board.ExecuteCommand(TurtleInstruction.Left.ToString());

            // assert
            Assert.AreEqual("Turtle cannot LEFT until it has been placed on the table.", result);
        }

        /// <summary>
        /// Turtle Initialized But Not Placed - CannotReportItsPosition
        /// </summary>
        [TestMethod]
        public void Turtle_InitializedButNotPlaced_CannotReportItsPosition()
        {
            // setup
            this.SetupTurtleTestsInitialize();

            // execute REPORT
            var result = this.board.ExecuteCommand(TurtleInstruction.Report.ToString());
            
            // assert
            Assert.AreEqual("Please place the turtle on the board before trying to get its current state.", result);
        }

        /// <summary>
        /// Turtle Placed Off Table - CannotBePlaced
        /// </summary>
        [TestMethod]
        public void Turtle_PlacedOffTable_CannotBePlaced()
        {
            // setup and execute PLACE -1,0,NORTH
            var result = this.SetupTurtleTestsInitialize(-1, 0, FacingDirection.North);

            // assert
            Assert.AreEqual("Invalid X-axis Co-ordinates. Should be a value above 0 and below the board boundary 5", result);

            // setup and execute PLACE 0,6,NORTH
            result = this.SetupTurtleTestsInitialize(0, 6, FacingDirection.North);
            
            // assert
            Assert.AreEqual("Invalid Y-axis Co-ordinates. Should be a value above 0 and below the board boundary 5", result);
        }

        /// <summary>
        /// Turtle Placed - CanReportItsPosition
        /// </summary>
        [TestMethod]
        public void Turtle_Placed_CanReportItsPosition()
        {
            // setup and execute
            var result = this.SetupTurtleTestsInitialize(3, 2, FacingDirection.East);
            Assert.AreEqual("Done.", result);

            // execute REPORT
            var position = this.board.ExecuteCommand(TurtleInstruction.Report.ToString());

            // assert
            Assert.AreEqual("3, 2, EAST", position);
        }

        /// <summary>
        /// Turtle Placed And Turned Left - ReportsCorrectPosition
        /// </summary>
        [TestMethod]
        public void Turtle_PlacedAndTurnedLeft_ReportsCorrectPosition()
        {
            // setup and execute PLACE 1,1,NORTH
            var result = this.SetupTurtleTestsInitialize(1, 1, FacingDirection.North);
            Assert.AreEqual("Done.", result);

            // execute turn LEFT and assert
            var position = this.board.ExecuteCommand(TurtleInstruction.Left.ToString());
            Assert.AreEqual("Done.", position);

            // execute REPORT and assert
            var report = this.board.ExecuteCommand(TurtleInstruction.Report.ToString());
            Assert.AreEqual("1, 1, WEST", report);
        }

        /// <summary>
        /// Turtle Placed And Turned Right - ReportsCorrectPosition
        /// </summary>
        [TestMethod]
        public void Turtle_PlacedAndTurnedRight_ReportsCorrectPosition()
        {
            // setup and execute PLACE 1,1,NORTH
            var result = this.SetupTurtleTestsInitialize(1, 1, FacingDirection.North);
            Assert.AreEqual("Done.", result);

            // execute turn RIGHT and assert
            var position = this.board.ExecuteCommand(TurtleInstruction.Right.ToString());
            Assert.AreEqual("Done.", position);

            // execute REPORT and assert
            var report = this.board.ExecuteCommand(TurtleInstruction.Report.ToString());
            Assert.AreEqual("1, 1, EAST", report);
        }

        /// <summary>
        /// Turtle Placed And Moved Off Table - CannotBeMoved
        /// </summary>
        [TestMethod]
        public void Turtle_PlacedAndMovedOffTable_CannotBeMoved()
        {
            // setup and execute PLACE 4,4,NORTH
            var result = this.SetupTurtleTestsInitialize(4, 4, FacingDirection.North);
            Assert.AreEqual("Done.", result);

            // execute turn MOVE and assert
            var position = this.board.ExecuteCommand(TurtleInstruction.Move.ToString());
            Assert.AreEqual("Turtle cannot MOVE there.", position);

            // execute REPORT and assert
            var report = this.board.ExecuteCommand(TurtleInstruction.Report.ToString());
            Assert.AreEqual("4, 4, NORTH", report);
        }

        /// <summary>
        /// Turtle Placed And Moved - ReportsCorrectPosition
        /// </summary>
        [TestMethod]
        public void Turtle_PlacedAndMoved_ReportsCorrectPosition()
        {
            // setup and execute PLACE 4,4,NORTH
            var result = this.SetupTurtleTestsInitialize(1, 1, FacingDirection.North);
            Assert.AreEqual("Done.", result);

            // execute turn MOVE and assert
            var position = this.board.ExecuteCommand(TurtleInstruction.Move.ToString());
            Assert.AreEqual("Done.", position);

            // execute REPORT and assert
            var report = this.board.ExecuteCommand(TurtleInstruction.Report.ToString());
            Assert.AreEqual("1, 2, NORTH", report);
        }

        /// <summary>
        /// Turtle Placed Moved And Turned - ReportsCorrectPosition
        /// </summary>
        [TestMethod]
        public void Turtle_PlacedMovedAndTurned_ReportsCorrectPosition()
        {
            // setup and execute PLACE 4,4,NORTH
            var result = this.SetupTurtleTestsInitialize(1, 2, FacingDirection.East);
            Assert.AreEqual("Done.", result);

            // execute turn MOVE and assert
            var position = this.board.ExecuteCommand(TurtleInstruction.Move.ToString());
            Assert.AreEqual("Done.", position);

            // execute turn MOVE and assert
            position = this.board.ExecuteCommand(TurtleInstruction.Move.ToString());
            Assert.AreEqual("Done.", position);

            // execute turn MOVE and assert
            position = this.board.ExecuteCommand(TurtleInstruction.Move.ToString());
            Assert.AreEqual("Done.", position);

            // execute turn LEFT and assert
            position = this.board.ExecuteCommand(TurtleInstruction.Left.ToString());
            Assert.AreEqual("Done.", position);

            // execute turn MOVE and assert
            position = this.board.ExecuteCommand(TurtleInstruction.Move.ToString());
            Assert.AreEqual("Done.", position);

            // execute REPORT and assert
            var report = this.board.ExecuteCommand(TurtleInstruction.Report.ToString());
            Assert.AreEqual("4, 3, NORTH", report);
        }

        /// <summary>
        /// Turtle Placed Moved - ReportCorrectPosition
        /// </summary>
        [TestMethod]
        public void Turtle_Placed_MoveAndReportCorrectPosition()
        {
            // setup and execute PLACE 0,0,NORTH
            var result = this.SetupTurtleTestsInitialize(0, 0, FacingDirection.North);
            Assert.AreEqual("Done.", result);

            // execute turn MOVE and assert
            var position = this.board.ExecuteCommand(TurtleInstruction.Move.ToString());
            Assert.AreEqual("Done.", position);

            // execute REPORT and assert
            var report = this.board.ExecuteCommand(TurtleInstruction.Report.ToString());
            Assert.AreEqual("0, 1, NORTH", report);
        }

        /// <summary>
        /// Turtle Placed Left - ReportCorrectPosition
        /// </summary>
        [TestMethod]
        public void Turtle_Placed_LeftAndReportCorrectPosition()
        {
            // setup and execute PLACE 0,0,NORTH
            var result = this.SetupTurtleTestsInitialize(0, 0, FacingDirection.North);
            Assert.AreEqual("Done.", result);

            // execute turn LEFT and assert
            var position = this.board.ExecuteCommand(TurtleInstruction.Left.ToString());
            Assert.AreEqual("Done.", position);

            // execute REPORT and assert
            var report = this.board.ExecuteCommand(TurtleInstruction.Report.ToString());
            Assert.AreEqual("0, 0, WEST", report);
        }

        /// <summary>
        /// Turtle Placed Move Left Move - ReportCorrectPosition
        /// </summary>
        [TestMethod]
        public void Turtle_Placed_MoveLeftMoveAndReportCorrectPosition()
        {
            // setup and execute PLACE 1,2,EAST
            var result = this.SetupTurtleTestsInitialize(1, 2, FacingDirection.East);
            Assert.AreEqual("Done.", result);

            // execute turn MOVE and assert
            var position = this.board.ExecuteCommand(TurtleInstruction.Move.ToString());
            Assert.AreEqual("Done.", position);

            // execute turn MOVE and assert
            position = this.board.ExecuteCommand(TurtleInstruction.Move.ToString());
            Assert.AreEqual("Done.", position);

            // execute turn LEFT and assert
            position = this.board.ExecuteCommand(TurtleInstruction.Left.ToString());
            Assert.AreEqual("Done.", position);

            // execute turn MOVE and assert
            position = this.board.ExecuteCommand(TurtleInstruction.Move.ToString());
            Assert.AreEqual("Done.", position);

            // execute REPORT and assert
            var report = this.board.ExecuteCommand(TurtleInstruction.Report.ToString());
            Assert.AreEqual("3, 3, NORTH", report);
        }

        /// <summary>
        /// Initialization Method of the Gameboard
        /// </summary>
        private void SetupTurtleTestsInitialize()
        {
            int boardXInitialSize = 5;
            int boardYInitialSize = 5;

            this.board = new GameBoard(new Turtle(boardXInitialSize, boardYInitialSize));
        }

        /// <summary>
        /// Initialize Gameboard and execute a PLACE X,Y,F command
        /// </summary>
        /// <param name="x">X co-ordinate</param>
        /// <param name="y">Y co-ordinate</param>
        /// <param name="direction">F co-ordinate</param>
        /// <returns>command output from PLACE execution</returns>
        private string SetupTurtleTestsInitialize(int x, int y, FacingDirection direction)
        {
            this.SetupTurtleTestsInitialize();
            return this.board.ExecuteCommand(TurtleInstruction.Place.ToString() + " " + x + "," + y + "," + direction.ToString());
        }
    }
}
