using System;

namespace blackJack {
	public class GameModel {
		private int startingMoney = 1000;

		public int CreateNewGame() {
			//create save, use startingMoney
			return startingMoney;
		}

		public int ContinueGame() {
			//TODO get save
			int savedMoney = 888;
			return savedMoney;
		}
	}
}
