Programming Task - Turtle Command

Description
The application is a simulation of a turtle moving on a square tabletop, of dimensions 5 units x 5 units.

There are no other obstructions on the table surface

The turtle is free to roam around the surface of the table, but must be prevented from falling to destruction. Any movement that would result in the turtle falling from the table must be prevented, however further valid movement commands must still be allowed.

Create a console application that can read in commands of the following form:
●	PLACE X,Y,F
●	MOVE
●	LEFT
●	RIGHT
●	REPORT

PLACE will put the turtle on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.

The origin (0,0) can be considered to be the SOUTH WEST most corner.

The first valid command to the turtle is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The application should discard all commands in the sequence until a valid PLACE command has been executed.

MOVE will move the turtle one unit forward in the direction it is currently facing.

LEFT and RIGHT will rotate the turtle 90 degrees in the specified direction without changing the position of the turtle.

REPORT will announce the X,Y and F of the turtle. This can be in any form, but standard output is sufficient.

A turtle that is not on the table can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands.

Input can be from a file or from standard input. It must be possible to accept input from either a file or from standard input.

Provide tests with good coverage to exercise the application.

Constraints
The turtle must not fall off the table during movement. This also includes the initial placement of the turtle. 

Any move that would cause the turtle to fall must be ignored.

Example Input and Output:

--- Input ---
PLACE 0,0,NORTH
MOVE
REPORT

--- Output ---
0,1,NORTH

--- Input ---
PLACE 0,0,NORTH
LEFT
REPORT

--- Output ---
0,0,WEST

--- Input ---
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT

--- Output ---
3,3,NORTH

Deliverables
A maven project (if applying of a Java role) or a Visual Studio solution (if applying for a .NET/C# role) with associated source files, and tests. There should be no dependencies other than the chosen unit test framework.
