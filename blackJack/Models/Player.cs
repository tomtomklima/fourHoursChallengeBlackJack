using System;
using System.Collections.Generic;

namespace blackJack {
	public class Player {
		private List <string> Hand = null;

		public void addCard(string Card) {
			Hand.Add (Card);
		}

		public List<string> getHand() {
			return Hand;
		}

		public List <int> getScore() {
			//TODO implement
			var score = new List<int> {20};
			return score;
		}
	}
}

