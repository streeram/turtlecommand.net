//---------------------------------------------------------------------------------
// <copyright file="LeftCommand.cs" company="Cognizant Technology Solutions.">
//     © 2017 Cognizant. All Rights Reserved.
// </copyright>
//---------------------------------------------------------------------------------
namespace TurtlePuzzle.Core
{
    /// <summary>
    /// Implementation of a LEFT command
    /// </summary>
    public class LeftCommand : ICommand
    {
        /// <summary>
        ///     Execute LEFT command
        /// </summary>
        /// <param name="turtle">turtle instance</param>
        /// <param name="arguments">NOT REQUIRED</param>
        /// <param name="message">message after command execution result</param>
        /// <returns>command execution result</returns>
        public bool DoExecution(ITurtle turtle, string[] arguments, out string message)
        {
            bool isSuccess;

            if (turtle.Left())
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
