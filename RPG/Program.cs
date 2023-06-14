using RPG.GameManagement;
using RPG.Helpers;

// Select our class
var number = InputActions.handleInput(StaticDictionaries.PlayerClasses, "Please select a player class: ");
var pClass = StaticDictionaries.PlayerClasses.ElementAt(number).Value;
var player = GameFactory.Instance().ParticipantFactory.CreateCharacter("TEST NAME", pClass);

// Init the game object
Game game = new Game(player);

// Init movement to allow moving our players location
player.InitMovement();

// run the game
game.run();