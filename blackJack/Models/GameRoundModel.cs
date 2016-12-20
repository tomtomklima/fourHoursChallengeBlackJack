using System;

namespace blackJack {
	public class GameRoundModel {
		int OneTurnMoney = 50;
		public int getAdjustedMoney(int playerMoney, int playerScore, int bankScore) {
			if (playerScore > bankScore && playerScore <= 21) {
				return playerMoney + OneTurnMoney;
			} else {
				return playerMoney - OneTurnMoney;
			}
		}
	}
}
