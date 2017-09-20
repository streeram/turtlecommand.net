//---------------------------------------------------------------------------------
// <copyright file="MessageConstants.cs" company="Cognizant Technology Solutions.">
//     © 2017 Cognizant. All Rights Reserved.
// </copyright>
//---------------------------------------------------------------------------------
namespace TurtlePuzzle.Core
{
    /// <summary>
    /// Class that contains all application messages
    /// </summary>
    public static class MessageConstants
    {
        #region Game Messages
        /// <summary>
        /// Success message after a command is executed.
        /// </summary>
        public const string DoneMsg = "Done.";

        /// <summary>
        /// Error message when gameboard tries to execute an invalid command
        /// </summary>
        public const string InvalidCommandMsg = "Invalid command.";

        /// <summary>
        /// Error message when gameboard tries to execute a command with invalid arguments
        /// </summary>
        public const string InvalidArgsMsg = "Invalid Arguments. Please use a valid command arguments.";

        /// <summary>
        /// Error message when gameboard tries to execute a PLACE command with missing arguments
        /// </summary>
        public const string MissingXYFArgsMsg = "Missing X,Y,F arguments";

        /// <summary>
        /// Error message when gameboard tries to execute a PLACE command with invalid arguments
        /// </summary>
        public const string InvalidXYFArgsMsg = "Invalid X-axis, Y-Axis and Direction Co-ordinates.";

        /// <summary>
        /// Error message when gameboard tries to execute a PLACE command with invalid X argument which is not an integer
        /// </summary>
        public const string InvalidXNonIntMsg = "Invalid X-axis Co-ordinates. Please provide a valid integer.";

        /// <summary>
        /// Error message when gameboard tries to execute a PLACE command with invalid X argument which negative or a number greater than the board boundary
        /// </summary>
        public const string InvalidXUnboundMsg = "Invalid X-axis Co-ordinates. Should be a value above 0 and below the board boundary ";

        /// <summary>
        /// Error message when gameboard tries to execute a PLACE command with invalid Y argument which is not an integer
        /// </summary>
        public const string InvalidYNonIntMsg = "Invalid Y-axis Co-ordinates. Please provide a valid integer.";

        /// <summary>
        /// Error message when gameboard tries to execute a PLACE command with invalid Y argument which negative or a number greater than the board boundary
        /// </summary>
        public const string InvalidYUnboundMsg = "Invalid Y-axis Co-ordinates. Should be a value above 0 and below the board boundary ";

        /// <summary>
        /// Error message when gameboard tries to execute a PLACE command with invalid F argument
        /// </summary>
        public const string InvalidFArgsMsg = "Invalid Facing Direction argument.";

        /// <summary>
        /// Error message when gameboard tries to execute a REPORT command before a valid PLACE command has been placed
        /// </summary>
        public const string InvalidStateMsg = "Please place the turtle on the board before trying to get its current state.";
        #endregion
    }
}
