//---------------------------------------------------------------------------------
// <copyright file="RightCommand.cs" company="Cognizant Technology Solutions.">
//     © 2017 Cognizant. All Rights Reserved.
// </copyright>
//---------------------------------------------------------------------------------
namespace TurtlePuzzle.Core
{
    /// <summary>
    /// Implementation of a RIGHT command
    /// </summary>
    public class RightCommand : ICommand
    {
        /// <summary>
        ///     Execute RIGHT command
        /// </summary>
        /// <param name="turtle">turtle instance</param>
        /// <param name="arguments">NOT REQUIRED</param>
        /// <param name="message">message after command execution result</param>
        /// <returns>command execution result</returns>
        public bool DoExecution(ITurtle turtle, string[] arguments, out string message)
        {
            bool isSuccess;

            if (turtle.Right())
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
