using System;
using System.Collections.Generic;

namespace blackJack {
	//extends Lukas code here
	//var View = new Lukas.???;

	class View {
		public int RenderMainMenu () {
			Console.WriteLine ("Hello World!");
			return 0;
		}

		public int RenderHelpPage() {
			Console.WriteLine ("Help page!");
			return 0;
		}

		public int RenderHumanTurn(List<string> HumanHand, int HumanScore, int HumanMoney) {
			//dummy
			return 0;
		}

		public void RenderBankTurn(List<string> HumanHand, int HumanScore, List<string> BankHand, int BankScore, int HumanMoney) {
		
		}
	}
}
