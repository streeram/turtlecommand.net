//---------------------------------------------------------------------------------
// <copyright file="ReportCommand.cs" company="Cognizant Technology Solutions.">
//     © 2017 Cognizant. All Rights Reserved.
// </copyright>
//---------------------------------------------------------------------------------
namespace TurtlePuzzle.Core
{
    /// <summary>
    /// Implementation of a RIGHT command
    /// </summary>
    public class ReportCommand : ICommand
    {
        /// <summary>
        ///     Execute REPORT command
        /// </summary>
        /// <param name="turtle">turtle instance</param>
        /// <param name="arguments">NOT REQUIRED</param>
        /// <param name="message">message after command execution result</param>
        /// <returns>command execution result</returns>
        public bool DoExecution(ITurtle turtle, string[] arguments, out string message)
        {
            bool isSuccess;

            if (turtle != null && turtle.Report() != null)
            {
                TurtleState currentState = turtle.Report();
                isSuccess = true;
                message = string.Format("{0}, {1}, {2}", currentState.X, currentState.Y, currentState.FacingDirection.ToString().ToUpper());
            }
            else
            {
                isSuccess = false;
                message = MessageConstants.InvalidStateMsg;
            }

            return isSuccess;
        }
    }
}
