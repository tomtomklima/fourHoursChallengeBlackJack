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
			//safe finalMoney;

			//end of GameController
		}

		public int GameRoundController(int humanStartingMoney){
			var Deck = new Deck ();
			var humanPlayer = new Player();
			var bankPlayer = new BankPlayer ();

			//first the human
			humanPlayer.addCard(Deck.drawCard());
			humanPlayer.addCard(Deck.drawCard());

			//ask player if he wanna card
			int playerReaction;
			do {
				var humanHand = humanPlayer.getHand();
				List<int> humanScore = humanPlayer.getScore();
				//0 for stay, 1 for next card
				playerReaction = View.RenderHumanTurn(humanHand, humanScore, humanStartingMoney);
			} while (playerReaction == 1);

			//second the bank


			return finalMoney;
		}
	}
}

