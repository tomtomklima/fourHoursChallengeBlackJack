using System;
using System.Collections.Generic;

namespace blackJack {
	public class Player {
		private List <string> hand = new List <string>();
		private Deck deck;

		public Player(Deck deck) {
			this.deck = deck;
		}

		public void getCard() {
			hand.Add (deck.drawCard());
		}

		public List<string> getHand() {
			return hand;
		}

		public int getScore() {
			var hand = this.getHand ();
			var scores = new Dictionary<string, int> {
				{"2", 2},
				{"3", 3},
				{"4", 4},
				{"5", 5},
				{"6", 6},
				{"7", 7},
				{"8", 8},
				{"9", 9},
				{"10", 10},
				{"J", 10},
				{"Q", 10},
				{"K", 10},
				{"A", 1},
			};
			int finalScore = 0;

			foreach (string card in hand) {
				string value = card.Substring (1);
				int valueScore = scores [value];
				finalScore += valueScore;
			}

			return finalScore;
		}
	}

	public class BankPlayer:Player {
		public BankPlayer (Deck deck) : base (deck) {}

		public void playAgaintsHuman(int humanScore) {
			this.getCard ();
			this.getCard ();

			//get cards until you have more or same points as human player
			while (this.getScore() < humanScore) {
				this.getCard ();
			}
		}
	}
}
