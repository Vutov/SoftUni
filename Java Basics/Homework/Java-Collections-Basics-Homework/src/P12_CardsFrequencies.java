import java.util.LinkedHashMap;
import java.util.Map.Entry;
import java.util.Scanner;


public class P12_CardsFrequencies {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);	
		String[] data = input.nextLine().split("[^\\dAKQJ]+");
		LinkedHashMap<String, Integer> cards = new LinkedHashMap<String, Integer>();
		for (String card : data) {
			if (cards.containsKey(card)) {
				cards.put(card, cards.get(card) + 1);
			}
			else {
				cards.put(card, 1);
			}
		}
		for (Entry<String, Integer> card : cards.entrySet()) {
			double freq = card.getValue() / (double) data.length;
			freq = freq * 100;
			System.out.printf("%s -> %.2f%%\n", card.getKey(), freq);
		}
	}

}
