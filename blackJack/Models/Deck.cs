using System;
using System.Collections.Generic;
using System.Linq;

//TODO
namespace blackJack {
	public class Deck {
		private List<string> deckOfCards;
		private List<string> suits = new List<string> () {
			"H",
			"D",
			"S",
			"C",
		};
		private List<string> values = new List<string> () {
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8",
			"9",
			"10",
			"J",
			"Q",
			"K",
			"A",
		};

		public void makeNewDeck() {
			foreach (string suit in suits) {
				foreach (string value in values) {
					deckOfCards.Add (suit + value);
				}
			}

			this.shuffle ();
		}

		public void shuffle() {
			var shuffledDeck = deckOfCards.OrderBy (a => Guid.NewGuid ());
			deckOfCards = shuffledDeck.ToList();
		}

		public string drawCard () {
			var first = deckOfCards.First();
			deckOfCards.RemoveAt (0);
			this.shuffle ();
			return first;
		}
	}
}

