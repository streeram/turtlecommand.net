//---------------------------------------------------------------------------------
// <copyright file="ICommand.cs" company="Cognizant Technology Solutions.">
//     © 2017 Cognizant. All Rights Reserved.
// </copyright>
//---------------------------------------------------------------------------------
namespace TurtlePuzzle.Core
{
    /// <summary>
    /// Interface for input commands
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Command Execution Block
        /// </summary>
        /// <param name="turtle">Turtle Object Instance</param>
        /// <param name="arguments">Command Arguments</param>
        /// <param name="message">Command Messages</param>
        /// <returns>Command Execution Status</returns>
        bool DoExecution(ITurtle turtle, string[] arguments, out string message);
    }
}
