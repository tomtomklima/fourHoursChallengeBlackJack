using System;

namespace blackJack {
	public class BankPlayer:Player {
		public string playAgaintsHuman(int humanScore) {
			int myScore = this.getScore;
			if (myScore < humanScore) {
				return "getCard";
			} else {
				return "holdOn";
			}
		}
	}
}

