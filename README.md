# OptimaCodingExercise

** Development line and decisions **

ScoreBoard.Core
Entities "Team", "TeamGame", "Game"

	- "Team" have the TeamName(string). Here we have the information about a team (foundation, stadium...), for this 
	exercise is only the name. can use it for others sports.
	- "TeamGame" have the team(Team) and the score(int). Here we have the information of the team in a match, for this
	exercise only the score,  here we can have all the stats(shots, passes....).
	- "Game" have two "TeamGame", one for home and other for away, and StartDate(Datetime), this will have the data of 
	the game. Right now only  the two teams and the Date, but here we can have the information of the competition.....
	I add an Id, this allow us to finish a game than search in the list for the teams.	

ScoreBoard.Test functions
	
	StartGame: IsTrue for new games and IsFalse when a team is already playing a game
	FinishGame: IsTrue when the id passed exists, IsFalse when not exists
	UpdateScore: IsTrue when the id passed exists, IsFalse when not exists.
	GetAllGames: Check that if not null the list returned. Check the type of the list returned.
	
ScoreBoard.Application functions
	
	StartGame: the parameters here are two string, for create the team name, but normally you will have your database 
	and the parameters will be an id for the teams selected in a dropdown, for example. But for this exercise we need
	the names and create all the objects.
	FinishGame: the parameter is the id of the game to delete.
	UpdateScore: parameters are the ids, homeTeamScore and awayTeamScore.
	
	The functions of GetAllGames dont have any special construction, only the specified orders.


Something to mention is that te parameters of the functions are simples. Receive a DTO for create and update, and send a DTO for the GetAll will be better. For the types, I dont made a check or a parse inside the function, i made that in a console project that i made for test it. This is what I think for this exercise and will depends on the fronts or services that connects whit it.

	
