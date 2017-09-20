//---------------------------------------------------------------------------------
// <copyright file="ITurtle.cs" company="Cognizant Technology Solutions.">
//     © 2017 Cognizant. All Rights Reserved.
// </copyright>
//---------------------------------------------------------------------------------
namespace TurtlePuzzle.Core
{
    /// <summary>
    /// Interface definition of a Turtle Type
    /// </summary>
    public interface ITurtle
    {
        /// <summary>
        /// This command places the turtle on a square gameboard facing a particular direction.
        /// </summary>
        /// <param name="turtleState">
        ///     X specifies the X-Axis position on the square board
        ///     Y specifies the Y-Axis position on the square board
        ///     FacingDirection specified the direction in which the turtle is facing currently. It can be North, East, South, West
        /// </param>
        /// <returns>True if the placement is valid or False is it is not a valid placement</returns>
        bool Place(TurtleState turtleState);

        /// <summary>
        /// This command tries to move the turtle 1 valid step forward in the direction it is currently placed.
        /// </summary>
        /// <returns>True if the move succeeds or False if it is an invalid move </returns>
        bool Move();

        /// <summary>
        /// Turns the direction of the turtle anti-clockwise by 90 degrees without moving the turtle.
        /// </summary>
        /// <returns>True if the command can turn the turtle, False if it is an invalid move</returns>
        bool Left();

        /// <summary>
        /// Turns the direction of the turtle clockwise by 90 degrees without moving the turtle.
        /// </summary>
        /// <returns>True if the command can turn the turtle, False if it is an invalid move</returns>
        bool Right();

        /// <summary>
        /// This command returns the state of the turtle on the board with information like its X axis position, Y axis position and the direction it is facing currently.
        /// </summary>
        /// <returns>Turtle State object</returns>
        TurtleState Report();

        /// <summary>
        /// Gets the Error Message to display to user in case of an invalid input or action.
        /// </summary>
        /// <returns>Error Message</returns>
        string GetErrorMessage();
        
        /// <summary>
        /// Returns the board X boundary
        /// </summary>
        /// <returns>Size of the X boundary of the gameboard</returns>
        int BoardSizeX();

        /// <summary>
        /// Returns the board X boundary
        /// </summary>
        /// <returns>Size of the Y boundary of the gameboard</returns>
        int BoardSizeY();
    }
}
