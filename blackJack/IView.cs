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

		public int RenderHumanTurn(List<string> HumanHand, List<int> HumanScore, int HumanMoney) {
			
		}

		public int RenderBankTurn(List<string> HumanHand, List<int> HumanScore, List<string> BankHand, List<int> BankScore, int HumanMoney) {
		
		}
	}
}
