//---------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Cognizant Technology Solutions.">
//     © 2017 Cognizant. All Rights Reserved.
// </copyright>
//---------------------------------------------------------------------------------
namespace TurtlePuzzle
{
    using System;
    using System.IO;
    using TurtlePuzzle.Core;

    /// <summary>
    /// Turtle Command Puzzle Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry Point of Execution
        /// </summary>
        /// <param name="args">Command Arguments</param>
        public static void Main(string[] args)
        {
            // Initialize the board size. It can be even changed as user input in future
            int boardXInitialSize = 5;
            int boardYInitialSize = 5;

            // Initialize a Gameboard
            GameBoard board = new GameBoard(new Turtle(boardXInitialSize, boardYInitialSize));

            string strCommandFilePath;

            try
            {
                // Check if user wants to input commmands from command line or execute a bunch of instructions from a file
                if (GetUserChoiceOfExec(out strCommandFilePath))
                {
                    GetUserInputFromFile(strCommandFilePath, board, boardXInitialSize, boardYInitialSize);
                }
                else
                {
                    GetUserInputFromConsole(board, boardXInitialSize, boardYInitialSize);
                }
            }
            catch (Exception ex)
            {
                // Print error details
                DisplayError(ex);
            }
        }

        /// <summary>
        /// Starts the puzzle accepting user commands from a file
        /// </summary>
        /// <param name="strCommandFilePath">absolute path from where the file has to be read</param>
        /// <param name="board">instance of the board object</param>
        /// <param name="boardXInitialSize">x dimension of the board</param>
        /// <param name="boardYInitialSize">y dimension of the board</param>
        private static void GetUserInputFromFile(string strCommandFilePath, GameBoard board, int boardXInitialSize, int boardYInitialSize)
        {
            if (File.Exists(strCommandFilePath))
            {
                string[] lines = File.ReadAllLines(strCommandFilePath);

                DislplayBootMessage(boardXInitialSize, boardYInitialSize);

                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        Console.WriteLine(line);

                        // get user commands from File
                        string command = line;

                        // end application if user is trying to quit.
                        if (command.ToUpper() == "EXIT" || command.ToUpper() == "QUIT" || command.ToUpper() == "Q" || command.ToUpper() == "X")
                        {
                            Environment.Exit(0);
                        }

                        // try process the command
                        var output = board.ExecuteCommand(command);
                        if (!output.ToUpper().Equals("DONE."))
                        {
                            Console.WriteLine(string.Empty);
                            Console.WriteLine("-----------------------------OUTPUT----------------------------------");
                            Console.WriteLine(output);
                        }
                    }
                }

                Console.WriteLine(string.Empty);
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid File.");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Starts the puzzle accepting user commands from console
        /// </summary>
        /// <param name="board">instance of the board object</param>
        /// <param name="boardXInitialSize">x dimension of the board</param>
        /// <param name="boardYInitialSize">y dimension of the board</param>
        private static void GetUserInputFromConsole(GameBoard board, int boardXInitialSize, int boardYInitialSize)
        {
            // Display baic instructions on how to play the game
            DislplayBootMessage(boardXInitialSize, boardYInitialSize);

            DisplayValidInstructions();

            while (true)
            {
                // Get user command from console
                string command = Console.ReadLine();

                // End application if user is trying to quit.
                if (command.ToUpper() == "EXIT" || command.ToUpper() == "QUIT" || command.ToUpper() == "Q" || command.ToUpper() == "X")
                {
                    Environment.Exit(0);
                }

                // Try process the command
                var output = board.ExecuteCommand(command);

                // Print out the output
                DisplayOutput(output);
            }
        }

        /// <summary>
        /// Get Users choice of execution (Console / File)
        /// </summary>
        /// <param name="strFilePath">Absolute path of the file</param>
        /// <returns>a boolean</returns>
        private static bool GetUserChoiceOfExec(out string strFilePath)
        {
            Console.WriteLine("#: Do you want to give commands from console or from file ? choice C for Console / F for File :");
            var choice = Console.ReadLine();
            if (choice.ToUpper().Equals("C", StringComparison.InvariantCultureIgnoreCase))
            {
                strFilePath = string.Empty;
                return false;
            }
            else
            {
                Console.WriteLine("#: Please provide full path of the file to read commands from (e.g c:\\temp\\testcmd.txt) : ");
                strFilePath = Console.ReadLine();
                return true;
            }
        }

        /// <summary>
        /// Displays boot message
        /// </summary>
        /// <param name="boardXInitialSize">x dimension of the board</param>
        /// <param name="boardYInitialSize">y dimension of the board</param>
        private static void DislplayBootMessage(int boardXInitialSize, int boardYInitialSize)
        {
            Console.WriteLine("Turtle puzzle started with square gameboard of size " + boardXInitialSize + " X " + boardYInitialSize);
            Console.WriteLine(string.Empty);
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine(string.Empty);
            Console.WriteLine("-----------------------------INPUT----------------------------------");
        }

        /// <summary>
        /// Display List of Valid Commands to help user start the puzzle.
        /// </summary>
        private static void DisplayValidInstructions()
        {
            Console.WriteLine("-------Valid Input Commands------------------------------------------");
            Console.WriteLine(string.Empty);
            Console.WriteLine("PLACE X,Y,F (where X and Y are integer co-ordinates, F represents direction (North, East, West, South) towards which the turtle will be facing on the board.");
            Console.WriteLine("MOVE ");
            Console.WriteLine("LEFT ");
            Console.WriteLine("RIGHT ");
            Console.WriteLine("REPORT ");
            Console.WriteLine(string.Empty);
            Console.WriteLine("-------Valid Input Commands------------------------------------------");
            Console.WriteLine(string.Empty);
        }

        /// <summary>
        /// Display OUTPUT to user console
        /// </summary>
        /// <param name="output">Command Output from the Game</param>
        private static void DisplayOutput(string output)
        {
            if (!output.ToUpper().Equals("DONE."))
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine("-----------------------------OUTPUT----------------------------------");
                Console.WriteLine(output);
            }
        }

        /// <summary>
        /// Display ERROR to user console
        /// </summary>
        /// <param name="ex">Exception wrapper</param>
        private static void DisplayError(Exception ex)
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine("-----------------------------UNEXPECTED ERROR OCCURED----------------------------------");
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
    }
}
