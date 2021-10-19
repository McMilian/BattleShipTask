# Introduction

Welcome to console application battleship game written in .NET 5.0 framework. This is the game only for two players and each player needs his/her computer to 
play the game.

# Gameplay

1. At the first step you are asked to provide number from the range 1 - 10000. This number is going to be a seed variable which
is going to be used in the randomizing algorythm to generate a position of ships in the board. Just pick your number and press enter.
In case of wrong input command will be repeated.

2. As you and your opponent picked the number, then exchange this information with each other and provide opponent's number in the
second question (your opponent in the second question provides your number).

3. Third and the last pre-game quesiton is to agree who shoots first:
If you agree that you start the game then you input 'y' and your opponent 'n'
if you agree that your opponent starts the game then you input 'n' and your opponent 'y'

4. Now you can see generated boards. Your board is on the left-hand side with your generated ships. Opponent's board is on the
right-hand side. It's empty at the beginning. Ship's parts are marked as () in the cell of the board

5. Game starts. Player who was agreed to start picks the shot coordinates inserting string in format for example 'C5' 
(which is shootto third row and fifth column) or 'H7' (which means eighth row and seventh column). Player is obliged to read
loud the coordinates of the shot so that opponent at the same time can input received shot.
When you hit opponents ship it will be shown as 'XX' if you miss then water is marked as '~~'.

6. Players input their shot coordinates and opponents shot coordinates as game progresses.

7. Game is over once one of the players destroys the ship of the other.

Have fun!

How to get the best experience from the game:
 - When you open console application make sure that the window of the game is wide enough. This is crucial to have a correct 
 view of boards.
 - During the game to have the best viewing experience resize the window so that only latest boards are visible so that boards 
 from previous turns will not disturb you.
 - In appsettings you can create ships configuration for the game. Keep in mind that if you set too many ships or too big 
 application will throw exception.


# Technical description

Game consists of 4 main services which build the engine of the game:
- Gameplay service: There's the definition how the actual game works.
- User Commands Service: This service's responsibility is to read and validate user's commands.
- Probability Generation Service: This service handles all operations based on the probability like drawing if created ship should
be placed horizontally or vertically as well as drawing starting position of the ship.
- Drawing Service: This service draws the current situation on boards.

Two Factories:
	- Ship Factory: Service responsible for creating the ship
	- Board Factory: Most complicated service which needs to create player's board and fill it out with the given ships configuration.
	It needs to calculate if ship can be placed in the randomly chosen location and not to interfere with already existing ship.

Main Models:
- PlayersBoard - model describes the state of the game from a player's perspective
- Battlefield - this model is used to manage the process of generation the ships' location
- Position - describes coordinate
- Field - contains given position and its content

# Appsetting - how to tweak game (be cautious)
There are a few game options:
 - ShowOpponentsShips - this is technical boolean option which lets you see opponents ships (for UAT test purpose)
 - ShipsSettings - array which let's user to set how many ships of which size should be generated
 - MaxNumberOfRandomTries - this technical int option states after how many random tries of generation the ships in battlefield process
 should be stopped and exception thrown (for example if user specifies too many ships in the ShipsSettings array).
