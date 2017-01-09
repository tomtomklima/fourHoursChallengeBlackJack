using System;
using System.Collections.Generic;

namespace blackJack {
	public class GameRound {
		private Deck deck;
		private Player humanPlayer;
		private BankPlayer bankPlayer;

		/*
		 * initialize one game round with new deck and player logic
		 */
		public GameRound () {
			deck = new Deck();
			humanPlayer = new Player (deck);
			bankPlayer = new BankPlayer (deck);
		}

		/*
		 * return of human player actual score
		 */
		int GetHumanScore() {
			return humanPlayer.getScore ();
		}

		/*
		 * return bank player actual score
		 */
		int GetBankScore() {
			return bankPlayer.getScore ();
		}

		/* 
		 * start new human turn (draw two cards really...)
		 * 
		 * return human player actual hand
		 */
		List<string> NewHumanTurn() {
			humanPlayer.getCard ();
			humanPlayer.getCard ();
			return humanPlayer.getHand ();
		}

		/* 
		 * make human player draw one card only
		 * 
		 * return human player actual hand
		 */
		List<string> HumanDrawOneCard() {
			humanPlayer.getCard ();
			return humanPlayer.getHand ();
		}

		/*
		 * make bank player play whole turn against human player
		 * 
		 * return bank player actual hand
		 */
		List<string> PlayBankTurn() {
			bankPlayer.playAgaintsHuman (humanPlayer.getScore ());
			return bankPlayer.getHand();
		}

		/*
		 * get who won this round (if was corrent drawing of course (:
		 * 
		 * return name of winner || Exception when at least one player has no cards
		 */
		String WhoWon() {
			int humanScore = humanPlayer.getScore();
			int bankScore = bankPlayer.getScore ();

			//check if we played both players
			if (humanScore == 0 || bankScore == 0) {
				throw new Exception("Jeden z hráčů má nulové skóre a tedy nejspíš ještě nehrál");
			}

			if ((humanScore > bankScore) && (humanScore <= 21)) {
				return "human";
			} else {
				return "bank";
			}
			
		}
	}
}
