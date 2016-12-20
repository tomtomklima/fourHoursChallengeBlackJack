using System;
using System.Collections.Generic;

namespace blackJack {
	public class Controllers {
		private View View;

		public Controllers() {
			var View = new View ();
		}

		public void MainController() {
			
			int userChoice = View.RenderMainMenu ();
			//0 == help page, 1 == start game

			switch (userChoice) {
			case 0:
				{
					View.RenderHelpPage ();
					break;
				}
			case 1:
				{
					//create an instance of a game
					this.GameController ("new");
					break;
				}
			case 2:
				{
					this.GameController ("continue");
					break;
				}
			default: {
				throw new Exception ("Unknown userChoice");
				}
			}


			//end of program
		}

		public void GameController(string typeOfGame) {
			var Game = new GameModel();
			int money;
			switch (typeOfGame) {
			case "new":
				//create game
				money = Game.CreateNewGame();
				break;
			case "continue": 
				//get save
				money = Game.ContinueGame();
				break;
			default:
				throw new Exception ("Unknown typeOfGame");
			}

			int finalMoney = this.GameRoundController (money);
			Game.SaveMoney(finalMoney);

			//end of GameController
		}

		public int GameRoundController(int humanStartingMoney){
			var GameRound = new GameRoundModel ();
			var Deck = new Deck ();
			var humanPlayer = new Player();
			var bankPlayer = new BankPlayer();

			//first the human
			humanPlayer.addCard(Deck.drawCard());

			int playerReaction;
			do {
				humanPlayer.addCard(Deck.drawCard()); //draw scond card for in first loop
				var humanHand = humanPlayer.getHand();
				int humanScore = humanPlayer.getScore();

				//ask player; 0 for stay, 1 for next card
				playerReaction = View.RenderHumanTurn(humanHand, humanScore, humanStartingMoney);
			} while (playerReaction == 1);

			//second the bank
			//TODO add "get minimal value from list, not first"
			while (bankPlayer.playAgaintsHuman(humanPlayer.getScore()) == "getCard") { //else "holdOn"
				bankPlayer.addCard(Deck.drawCard());
			}

			int finalMoney = GameRound.getAdjustedMoney (humanStartingMoney, humanPlayer.getScore(), bankPlayer.getScore());

			View.RenderBankTurn (humanPlayer.getHand (), humanPlayer.getScore (), bankPlayer.getHand (), bankPlayer.getScore(), finalMoney);

			return finalMoney;
		}
	}
}

