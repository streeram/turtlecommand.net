//---------------------------------------------------------------------------------
// <copyright file="PlaceCommand.cs" company="Cognizant Technology Solutions.">
//     © 2017 Cognizant. All Rights Reserved.
// </copyright>
//---------------------------------------------------------------------------------
namespace TurtlePuzzle.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// Implementation of a PLACE X,Y,F command
    /// </summary>
    public class PlaceCommand : ICommand
    {
        /// <summary>
        ///     Execute PLACE command
        /// </summary>
        /// <param name="turtle">turtle instance</param>
        /// <param name="arguments">X, Y, F arguments</param>
        /// <param name="message">message after command execution result</param>
        /// <returns>command execution result</returns>
        public bool DoExecution(ITurtle turtle, string[] arguments, out string message)
        {
            TurtleInstruction instruction;

            if (arguments == null)
            {
                message = MessageConstants.MissingXYFArgsMsg;
                return false;
            }

            if (Enum.TryParse<TurtleInstruction>(arguments[0], true, out instruction))
            {
                int x = 0, y = 0;
                FacingDirection direction = FacingDirection.North;

                string[] place_args = arguments[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (place_args.Length != 3)
                {
                    message = MessageConstants.InvalidXYFArgsMsg;
                    return false;
                }

                if (instruction == TurtleInstruction.Place)
                {
                    if (!int.TryParse(place_args[0], out x))
                    {
                        message = MessageConstants.InvalidXNonIntMsg;
                        return false;
                    }
                    else
                    {
                        if (x < 0 || x >= turtle.BoardSizeX())
                        {
                            message = MessageConstants.InvalidXUnboundMsg + turtle.BoardSizeX();
                            return false;
                        }
                    }

                    if (!int.TryParse(place_args[1], out y))
                    {
                        message = MessageConstants.InvalidYNonIntMsg;
                        return false;
                    }
                    else
                    {
                        if (y < 0 || y >= turtle.BoardSizeY())
                        {
                            message = MessageConstants.InvalidYUnboundMsg + turtle.BoardSizeY();
                            return false;
                        }
                    }

                    if (!Enum.TryParse(place_args[2], true, out direction))
                    {
                        message = MessageConstants.InvalidFArgsMsg;
                        return false;
                    }
                    
                    bool isPlacedSuccessfull = turtle.Place(new TurtleState()
                    {
                        X = x,
                        Y = y,
                        FacingDirection = direction
                    });

                    if (isPlacedSuccessfull)
                    {
                        message = MessageConstants.DoneMsg;
                        return true;
                    }
                    else
                    {
                        message = MessageConstants.InvalidCommandMsg;
                        return false;
                    }
                }
                else
                {
                    message = MessageConstants.InvalidCommandMsg;
                    return false;
                }
            }
            else
            {
                message = MessageConstants.InvalidCommandMsg;
                return false;
            }
        }
    }
}
