//---------------------------------------------------------------------------------
// <copyright file="Turtle.cs" company="Cognizant Technology Solutions.">
//     © 2017 Cognizant. All Rights Reserved.
// </copyright>
//---------------------------------------------------------------------------------
namespace TurtlePuzzle.Core
{
    using System;

    /// <summary>
    /// This class represents the Turtle
    /// </summary>
    public class Turtle : ITurtle
    {
        /// <summary>
        /// Manages the current state of the turtle
        /// </summary>
        private TurtleState turtleState;

        /// <summary>
        /// Game Board X boundary on which the turtle is placed
        /// </summary>
        private int boardSizeX;

        /// <summary>
        /// Game Board Y boundary on which the turtle is placed
        /// </summary>
        private int boardSizeY;

        /// <summary>
        /// Command Execution Errors
        /// </summary>
        private string errorMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="Turtle"/> class
        /// </summary>
        public Turtle()
        {
            this.boardSizeX = 5;
            this.boardSizeY = 5;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Turtle"/> class with board X and Y boundaries
        /// </summary>  
        /// <param name="boardSizeX">arguments X boundary of the board</param>
        /// <param name="boardSizeY">arguments Y boundary of the board</param>
        public Turtle(int boardSizeX, int boardSizeY)
        {
            this.boardSizeX = boardSizeX;
            this.boardSizeY = boardSizeY;
        }

        /// <summary>
        /// Getter method for errorMessage member variable
        /// </summary>
        /// <returns>Message as string</returns>
        public string GetErrorMessage()
        {
            return this.errorMessage;
        }

        /// <summary>
        /// Getter method for Game board X boundary
        /// </summary>
        /// <returns>X in integer</returns>
        public int BoardSizeX()
        {
            return this.boardSizeX;
        }

        /// <summary>
        /// Getter method for Game board X boundary
        /// </summary>
        /// <returns>Y in integer</returns>
        public int BoardSizeY()
        {
            return this.boardSizeY;
        }

        /// <summary>
        /// PLACE Command
        /// </summary>
        /// <param name="turtleState">arguments X Y and F encapsulated inside TurtleState Object</param>
        /// <returns>execution status</returns>
        public bool Place(TurtleState turtleState)
        {
            var action = TurtleInstruction.Place;

            // Check if the placement is valid
            if (this.IsTurtleInsideTable(turtleState.X.Value, turtleState.Y.Value))
            {
                this.turtleState = turtleState;
                return true;
            }

            // invalid command
            this.SetErrorMessage(action, false);
            return false;
        }

        /// <summary>
        /// LEFT Command
        /// </summary>
        /// <returns>execution status</returns>
        public bool Left()
        {
            return this.MakeTurn(TurnDirection.Left);
        }

        /// <summary>
        /// RIGHT Command
        /// </summary>
        /// <returns>execution status</returns>
        public bool Right()
        {
            return this.MakeTurn(TurnDirection.Right);
        }

        /// <summary>
        /// MOVE Command
        /// </summary>
        /// <returns>execution status</returns>
        public bool Move()
        {
            var action = TurtleInstruction.Move;

            // Check if PLACE commmand has been executed before a MOVE command
            if (this.IsTurtlePlacedFirstOnTheTable())
            {
                // try and get the turtle's to new co-ordinates
                int newx = this.GetNewX();
                int newy = this.GetNewY();

                // check if turtle has not fallen off the table
                if (this.IsTurtleInsideTable(newx, newy))
                {
                    // move the turtle to the new co-ordinates
                    this.turtleState.X = newx;
                    this.turtleState.Y = newy;
                    return true;
                }
                
                // invalid MOVE action
                this.SetErrorMessage(action, true);
                return false;
            }

            // invalid MOVE action
            this.SetErrorMessage(action, false);
            return false;
        }

        /// <summary>
        /// REPORT Command
        /// </summary>
        /// <returns>X,Y and F state encapsulated inside TurtleState object</returns>
        public TurtleState Report()
        {
            return this.turtleState;
        }

        /// <summary>
        /// Gets the to-be new value of X after a command execution
        /// </summary>
        /// <returns>New X value</returns>
        private int GetNewX()
        {
            // Move Right if the turtle is facing East
            if (this.turtleState.FacingDirection == FacingDirection.East)
            {
                return this.turtleState.X.Value + 1;
            }
            else
            {
                // Move Left if the turtle is facing West
                if (this.turtleState.FacingDirection == FacingDirection.West)
                {
                    return this.turtleState.X.Value - 1;
                }
            }

            return this.turtleState.X.Value;
        }

        /// <summary>
        /// Gets the to-be new value of Y after a command execution
        /// </summary>
        /// <returns>New Y value</returns>
        private int GetNewY()
        {
            // Move Up if the turtle is facing North
            if (this.turtleState.FacingDirection == FacingDirection.North)
            {
                return this.turtleState.Y.Value + 1;
            }
            else
            {
                // Move Down if the turtle is facing South
                if (this.turtleState.FacingDirection == FacingDirection.South)
                {
                    return this.turtleState.Y.Value - 1;
                }
            }

            return this.turtleState.Y.Value;
        }

        /// <summary>
        /// Checks Validity before executing either a LEFT or a RIGHT command
        /// </summary>
        /// <param name="direction">LEFT or a RIGHT</param>
        /// <returns>execution status</returns>
        private bool MakeTurn(TurnDirection direction)
        {
            var action = (direction == TurnDirection.Left) ? TurtleInstruction.Left : TurtleInstruction.Right;

            // Check if action is valid
            if (this.IsTurtlePlacedFirstOnTheTable())
            {
                return this.Turn(direction);
            }

            // invalid action
            this.SetErrorMessage(action, false);
            return false;
        }

        /// <summary>
        /// Execute either a LEFT or a RIGHT command
        /// </summary>
        /// <param name="direction">LEFT or a RIGHT</param>
        /// <returns>execution status</returns>
        private bool Turn(TurnDirection direction)
        {
            if (this.IsTurtlePlacedFirstOnTheTable())
            {
                var facingAsNumber = (int)this.turtleState.FacingDirection;
                facingAsNumber += 1 * (direction == TurnDirection.Right ? 1 : -1);
                if (facingAsNumber == 5)
                {
                    facingAsNumber = 1;
                }

                if (facingAsNumber == 0)
                {
                    facingAsNumber = 4;
                }

                this.turtleState.FacingDirection = (FacingDirection)facingAsNumber;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if Turtle is Placed using a valid PLACE command already
        /// </summary>
        /// <returns>validity of the move</returns>
        private bool IsTurtlePlacedFirstOnTheTable()
        {
            if (this.turtleState == null || !this.turtleState.X.HasValue || !this.turtleState.X.HasValue)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the turtle has fallen off the board or not
        /// </summary>
        /// <param name="x">to-be X value</param>
        /// <param name="y">to-be Y value</param>
        /// <returns>validity of the move</returns>
        private bool IsTurtleInsideTable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= this.boardSizeX || y >= this.boardSizeY)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Sets the errorMessage member variable
        /// </summary>
        /// <param name="action">Name of the Command</param>
        /// <param name="isInitialized">denotes whether a valid PLACE command has been placed already</param>
        private void SetErrorMessage(TurtleInstruction action, bool isInitialized)
        {
            this.errorMessage = isInitialized ? 
                string.Format("Turtle cannot {0} there.", action.ToString().ToUpper()) : 
                string.Format("Turtle cannot {0} until it has been placed on the table.", action.ToString().ToUpper());
        }
    }
}
