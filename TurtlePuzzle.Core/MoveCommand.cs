//---------------------------------------------------------------------------------
// <copyright file="MoveCommand.cs" company="Cognizant Technology Solutions.">
//     © 2017 Cognizant. All Rights Reserved.
// </copyright>
//---------------------------------------------------------------------------------
namespace TurtlePuzzle.Core
{
    using System;

    /// <summary>
    /// Implementation of a MOVE command
    /// </summary>
    public class MoveCommand : ICommand
    {
        /// <summary>
        ///     Execute MOVE command
        /// </summary>
        /// <param name="turtle">turtle instance</param>
        /// <param name="arguments">NOT REQUIRED</param>
        /// <param name="message">message after command execution result</param>
        /// <returns>command execution result</returns>
        public bool DoExecution(ITurtle turtle, string[] arguments, out string message)
        {
            bool isSuccess;

            if (turtle.Move())
            {
                isSuccess = true;
                message = MessageConstants.DoneMsg;
            }
            else
            {
                isSuccess = false;
                message = turtle.GetErrorMessage();
            }

            return isSuccess;
        }
    }
}
