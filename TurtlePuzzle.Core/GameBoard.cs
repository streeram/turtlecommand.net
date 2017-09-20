//---------------------------------------------------------------------------------
// <copyright file="GameBoard.cs" company="Cognizant Technology Solutions.">
//     © 2017 Cognizant. All Rights Reserved.
// </copyright>
//---------------------------------------------------------------------------------
namespace TurtlePuzzle.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This class represents the Gameboard
    /// </summary>
    public class GameBoard
    {
        /// <summary>
        /// Holds the list of classes implementing the commands
        /// </summary>
        private static Dictionary<TurtleInstruction, ICommand> strategies =
        new Dictionary<TurtleInstruction, ICommand>();

        /// <summary>
        /// A turtle object private instance
        /// </summary>
        private ITurtle turtle;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameBoard"/> class.
        /// </summary>
        /// <param name="turtle">a turtle object</param>
        public GameBoard(ITurtle turtle)
        {
            this.turtle = turtle;
            if (!strategies.ContainsKey(TurtleInstruction.Place)) 
            {
                strategies.Add(TurtleInstruction.Place, new PlaceCommand());
            }

            if (!strategies.ContainsKey(TurtleInstruction.Move))
            {
                strategies.Add(TurtleInstruction.Move, new MoveCommand());
            }

            if (!strategies.ContainsKey(TurtleInstruction.Left))
            {
                strategies.Add(TurtleInstruction.Left, new LeftCommand());
            }

            if (!strategies.ContainsKey(TurtleInstruction.Right))
            {
                strategies.Add(TurtleInstruction.Right, new RightCommand());
            }

            if (!strategies.ContainsKey(TurtleInstruction.Report))
            {
                strategies.Add(TurtleInstruction.Report, new ReportCommand());
            }

            if (!strategies.ContainsKey(TurtleInstruction.Invalid))
            {
                strategies.Add(TurtleInstruction.Invalid, new InvalidCommand());
            }
        }

        /// <summary>
        /// Strategy Pattern Execution of Commands
        /// </summary>
        /// <param name="instruction">Command Name</param>
        /// <param name="turtle">a turtle object</param>
        /// <param name="arguments">optional parameters</param>
        /// <param name="message">massage after command execution completed</param>
        /// <returns>command execution status</returns>
        public static bool DoExecution(TurtleInstruction instruction, ITurtle turtle, string[] arguments, out string message)
        {
            return strategies[instruction].DoExecution(turtle, arguments, out message);
        }

        /// <summary>
        /// Executed user command
        /// </summary>
        /// <param name="command">user command</param>
        /// <returns>command output</returns>
        public string ExecuteCommand(string command)
        {
            string response = string.Empty;
            bool isSuccess = false;

            // validate input commands and arguments
            string[] userArgs = command
                                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();

            response = this.ValidateAndExecuteInput(userArgs, out isSuccess);
            
            return response;
        }

        /// <summary>
        /// Validate and Execute user command
        /// </summary>
        /// <param name="userArgs">command arguments</param>
        /// <param name="isSuccess">boolean to denote a successful execution</param>
        /// <returns>command output</returns>
        private string ValidateAndExecuteInput(string[] userArgs, out bool isSuccess)
        {
            TurtleInstruction instruction;
            string message;

            if (userArgs.Length > 2)
            {
                instruction = TurtleInstruction.Invalid;
                isSuccess = false;
                return MessageConstants.InvalidArgsMsg;
            }

            if (userArgs.Length == 1)
            {
                if (Enum.TryParse(userArgs[0], true, out instruction))
                {
                    isSuccess = DoExecution(instruction, this.turtle, null, out message);
                    return message;
                }
                else
                {
                    isSuccess = false;
                    return MessageConstants.InvalidCommandMsg;
                }
            }

            if (userArgs.Length == 2)
            {
                // call doExection Method of PLACE command
                isSuccess = DoExecution(TurtleInstruction.Place, this.turtle, userArgs, out message);
                return message;
            }

            isSuccess = false;
            return MessageConstants.InvalidCommandMsg;
        }

        /// <summary>
        /// Gets the output for REPORT command
        /// </summary>
        /// <param name="turtle">turtle class instance</param>
        /// <param name="isSuccess">boolean representing a successful execution</param>
        /// <returns>command output</returns>
        private string GetReport(ITurtle turtle, out bool isSuccess)
        {
            if (turtle != null && turtle.Report() != null)
            {
                TurtleState currentState = turtle.Report();
                isSuccess = true;
                return string.Format("{0}, {1}, {2}", currentState.X, currentState.Y, currentState.FacingDirection.ToString().ToUpper());
            }

            isSuccess = false;
            return "Please place the turtle on the board before trying to get its current state.";
        }
    }
}
