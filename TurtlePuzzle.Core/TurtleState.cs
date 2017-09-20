//---------------------------------------------------------------------------------
// <copyright file="TurtleState.cs" company="Cognizant Technology Solutions.">
//     © 2017 Cognizant. All Rights Reserved.
// </copyright>
//---------------------------------------------------------------------------------
namespace TurtlePuzzle.Core
{
    /// <summary>
    /// Class Representation for the current state of the Turtle
    /// </summary>
    public class TurtleState
    {
        /// <summary>
        /// Gets or sets X co-ordinate of the cell where the turtle is 
        /// </summary>
        public int? X { get; set; }

        /// <summary>
        /// Gets or sets Y co-ordinate of the cell where the turtle is 
        /// </summary>
        public int? Y { get; set; }

        /// <summary>
        /// Gets or sets F co-ordinate which is the direction in which the turtle is facing
        /// </summary>
        public FacingDirection FacingDirection { get; set; }
    }
}
