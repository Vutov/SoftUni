import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;

public class P1_CognateWords {
	
	//Need debug zero test 3
	
	
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		boolean found = false;
		HashMap<String, Integer> foundCouples = new HashMap<String, Integer>();
		// String data = "java..?|basics/*-+=javabasics";
		String data = input.nextLine();
		String[] words = data.split("\\W+");
		for (int i = 0; i < words.length - 1; i++) {
			for (int j = 0; j < words.length; j++) {
				for (int k = 0; k < words.length; k++) {
					String nextWords = words[i] + words[j];
					if (nextWords.compareTo(words[k]) == 0
							&& words[j] != words[i]) {
						if (foundCouples.containsKey(nextWords)) {
							foundCouples.put(nextWords, 2);
						} else {
							foundCouples.put(nextWords, 1);
							System.out.printf("%s|%s=%s\n", words[i], words[j],
									words[k]);
						}
						found = true;
					}
				}
			}
		}

		if (!found) {
			System.out.println("No");
		}
	}

}
