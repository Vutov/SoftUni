import java.util.ArrayList;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;


public class P11_MostFrequentWord {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] data = input.nextLine().toLowerCase().split("\\W+");
		TreeMap<String, Integer> words = new TreeMap<String, Integer>();
		for (String word : data) {
			if (words.containsKey(word)) {
				words.put(word, words.get(word) + 1);
			}
			else {
				words.put(word, 1);
			}
		}
		int maxCount = 1;
		ArrayList<String> bestWords = new ArrayList<>();
		for (Entry<String, Integer> word : words.entrySet()) {
			int currentCount = word.getValue();
			if (currentCount >= maxCount) {
				maxCount = currentCount;
				bestWords.add(word.getKey());
			}
		}
		for (int i = 0; i < bestWords.size(); i++) {
			System.out.printf("%s -> %d\n", bestWords.get(i), maxCount);
		}
		
	}

}
