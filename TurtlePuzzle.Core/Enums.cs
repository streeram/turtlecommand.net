namespace TurtlePuzzle.Core
{
    /// <summary>
    /// List of Instructions
    /// </summary>
    public enum TurtleInstruction
    {
        /// <summary>
        /// Invalid Command
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// PLACE X,Y,F Command 
        /// </summary>
        Place = 1,

        /// <summary>
        /// MOVE Command
        /// </summary>
        Move = 2,

        /// <summary>
        /// LEFT Command
        /// </summary>
        Left = 3,

        /// <summary>
        /// RIGHT Command
        /// </summary>
        Right = 4,

        /// <summary>
        /// REPORT Command
        /// </summary>
        Report = 5,
    }

    /// <summary>
    /// Possible Facing Directions of the turtle
    /// </summary>
    public enum FacingDirection
    {
        /// <summary>
        /// North Direction
        /// </summary>
        North = 1,

        /// <summary>
        /// East Direction
        /// </summary>
        East = 2,

        /// <summary>
        /// South Direction
        /// </summary>
        South = 3,

        /// <summary>
        /// West Direction
        /// </summary>
        West = 4,
    }

    /// <summary>
    /// Possible Turn Directions for the turtle
    /// </summary>
    public enum TurnDirection
    {
        /// <summary>
        /// Turn Anti Clockwise by 90 degrees
        /// </summary>
        Left = 1,

        /// <summary>
        /// Turn Clockwise by 90 degrees
        /// </summary>
        Right = -1,
    }
}
