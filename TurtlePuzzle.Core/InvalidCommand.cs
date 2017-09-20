//---------------------------------------------------------------------------------
// <copyright file="InvalidCommand.cs" company="Cognizant Technology Solutions.">
//     © 2017 Cognizant. All Rights Reserved.
// </copyright>
//---------------------------------------------------------------------------------
namespace TurtlePuzzle.Core
{
    /// <summary>
    /// Implementation of a RIGHT command
    /// </summary>
    public class InvalidCommand : ICommand
    {
        /// <summary>
        ///     Execute any unsupported command
        /// </summary>
        /// <param name="turtle">turtle instance</param>
        /// <param name="arguments">NOT REQUIRED</param>
        /// <param name="message">message after command execution result</param>
        /// <returns>command execution result</returns>
        public bool DoExecution(ITurtle turtle, string[] arguments, out string message)
        {
            message = MessageConstants.InvalidCommandMsg;
            return false;
        }
    }
}
