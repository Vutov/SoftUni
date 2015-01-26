import java.util.Collections;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;


public class P3_WeirdStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String data = input.nextLine();
		data = data.replaceAll("[\\/()|\\s]+", "");
		String[] words = data.split("[^a-zA-Z]+");
		int maxWeight = 0;
		int savedIndex = 0;
		for (int i = 0; i < words.length; i++) {
			for (int j = i; j < words.length - 1; j++) {
				int sumWeight = getWeight(words[j]) + getWeight(words[j + 1]);
				if (sumWeight >= maxWeight) {
					maxWeight = sumWeight;
					savedIndex = j;
				}
			}
		}
		System.out.println(words[savedIndex]);
		System.out.println(words[savedIndex + 1]);
		
	}
	private static int getWeight(String word) {
		int weight = 0;
		word = word.toLowerCase();
		for (int i = 0; i < word.length(); i++) {
			char letter = word.charAt(i);
			int charWeight = letter - 'a' + 1;
			weight += charWeight;
		}
		return weight;
	}
}
//method for weight -> treemap to sort > print first two 