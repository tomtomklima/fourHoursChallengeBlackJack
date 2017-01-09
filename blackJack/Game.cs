using System;
using System.IO;

namespace blackJack {
	public class Game {
		private const int oneTurnMoney =  50;
		private const int startingMoney = 200;
		private const string scoreFile = "score.txt";
		private GameRound gameRound;
		public Game () {
			gameRound = new GameRound ();
		}

		/*
		 * return boolean if loading file is readable
		 */
		public bool isHumanScoreLoadable() {
			try {
				int score = File.ReadAllText (scoreFile);
				return true;
			} catch (Exception e) {
				return false;
			}
		}

		/*
		 * get human score from the file
		 * 
		 * throw Exception if anything goes wrong
		 */
		public int loadScoreFromFile() {
			try {
				int score = File.ReadAllText (scoreFile);
				return score;
			} catch (Exception e) {
				throw new Exception ("V souboru " + scoreFile + " není číslo, soubor není dostupný nebo vůbec neexistuje. Zpráva: " + e.Message);
			}
		}

		/*
		 * create new save file (and maybe delete the old one)
		 */
		public void createNewSave(string startingMoney = startingMoney) {
			try {
				File.Delete(scoreFile);
				File.WriteAllText (scoreFile, startingMoney);
			} catch (Exception e) {
				throw new Exception ("Soubor " + scoreFile + " není přístupný protože: " + e.Message);
			}
		}

		/*
		 * create new game instance for one play/shuffle/turn, with new deck and everyting
		 */
		public void startGameTurn() {
			gameRound = new GameRound();
		}

		/*
		 * make human loose his money when he loose!
		 */
		public void decreaseMoneyHumanLoose(int loosingMoney = oneTurnMoney) {
			manipulateScoreFile (-loosingMoney);
		}

		/*
		 * if human win, raise his money into to sky!
		 */
		public void raiseMoneyHumanWin(int raisingMoney = oneTurnMoney) {
			manipulateScoreFile (raisingMoney);
		}

		private void manipulateScoreFile(int difference) {
			try {
				int oldScore = loadScoreFromFile ();
				int newScore = oldScore + difference;
				File.WriteAllText (newScore.ToString ());
			} catch (Exception e) {
				throw new Exception ("Nepovedlo se uložit nové skóre protože: " + e.Message);
			}
		}
	}
}
