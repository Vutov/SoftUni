import java.util.Collections;
import java.util.ArrayList;
import java.util.Scanner;

public class P4_StraightFlush {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String data = input.nextLine();
		String[] cards = data.split("[,\\s]+");
		ArrayList<Integer> spades = new ArrayList<Integer>();
		ArrayList<Integer> hearts = new ArrayList<Integer>();
		ArrayList<Integer> diamonds = new ArrayList<Integer>();
		ArrayList<Integer> clubs = new ArrayList<Integer>();
		int len = cards.length;
		/*
		 * for (String card : cards) { System.out.println("."+card+"."); }
		 */
		for (int i = 0; i < len; i++) {
			// System.out.println(cards[i]);
			switch (cards[i].substring(cards[i].length() - 1)) {
			case "S":
				spades.add(fillList(cards, i));
				break;
			case "H":
				hearts.add(fillList(cards, i));
				break;
			case "D":
				diamonds.add(fillList(cards, i));
				break;
			case "C":
				clubs.add(fillList(cards, i));
				break;
			}
		}
		Collections.sort(spades);
		Collections.sort(hearts);
		Collections.sort(diamonds);
		Collections.sort(clubs);
		boolean found = false;
		found = printFlushes(spades, 'S', found);
		found = printFlushes(hearts, 'H', found);
		found = printFlushes(diamonds, 'D', found);
		found = printFlushes(clubs, 'C', found);
		if (!found) {
			System.out.println("No Straight Flushes");
		}
	}

	private static int fillList(String[] cards, int index) {
		switch (cards[index].charAt(0)) {
		case '1':
			return 10;
		case 'J':
			return 11;
		case 'Q':
			return 12;
		case 'K':
			return 13;
		case 'A':
			return 14;
		default:
			String element = cards[index];
			int value = Character.getNumericValue(element.charAt(0));
			return value;
		}
	}

	private static boolean printFlushes(ArrayList<Integer> cards, char suit, boolean found) {
		for (int i = 0; i < cards.size() - 4; i++) {
			if (cards.get(i) + 1 == cards.get(i + 1)
					&& cards.get(i + 1) + 1 == cards.get(i + 2)
					&& cards.get(i + 2) + 1 == cards.get(i + 3)
					&& cards.get(i + 3) + 1 == cards.get(i + 4)) {
				System.out.printf("[%s, %s, %s, %s, %s]\n",
						getCard(cards.get(i)) + suit,
						getCard(cards.get(i + 1)) + suit,
						getCard(cards.get(i + 2)) + suit,
						getCard(cards.get(i + 3)) + suit,
						getCard(cards.get(i + 4)) + suit);
				found = true;
			}
		}
		return found;
	}

	private static String getCard(int cardValue) {
		switch (cardValue) {
		case 1:
			return "1";
		case 2:
			return "2";
		case 3:
			return "3";
		case 4:
			return "4";
		case 5:
			return "5";
		case 6:
			return "6";
		case 7:
			return "7";
		case 8:
			return "8";
		case 9:
			return "9";
		case 10:
			return "10";
		case 11:
			return "J";
		case 12:
			return "Q";
		case 13:
			return "K";
		case 14:
			return "A";
		default:
			return "Error";
		}
	}
}
/*
 * Split to cards; sort cards in 4 lists; for-loop to find flushes
 */