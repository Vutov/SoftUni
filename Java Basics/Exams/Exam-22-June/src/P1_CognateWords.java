import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class P1_CognateWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		boolean found = false;
		Set<String> foundCouples = new HashSet<String>();
		// String data = "java..?|basics/*-+=javabasics";
		String data = input.nextLine();
		String[] words = data.split("([^a-zA-Z])+");
		for (int i = 0; i < words.length; i++) {
			for (int j = 0; j < words.length; j++) {
				for (int k = 0; k < words.length; k++) {
					String nextWords = words[i] + words[j];
					if (nextWords.compareTo(words[k]) == 0 && j != i
							&& !foundCouples.contains(nextWords)) {
						System.out.printf("%s|%s=%s\n", words[i], words[j],
								words[k]);
						foundCouples.add(nextWords);
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
