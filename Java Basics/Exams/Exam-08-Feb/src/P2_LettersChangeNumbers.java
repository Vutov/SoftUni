import java.util.Scanner;

public class P2_LettersChangeNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		//Read data;
		String[] words = input.nextLine().trim().split("\\s+");
		double sum = 0;
		for (int w = 0; w < words.length; w++) {
			if (!words[w].equals("")) {
				String[] letters = words[w].split("\\d+");
				String[] digit = words[w].split("\\D");
				double number = Double.parseDouble(digit[1]);
				double currentSum = number;
				for (int i = 0; i < letters.length; i++) {
					char character = letters[i].charAt(0);
					//First letter;
					if (i == 0) {
						if (character >= 'a' && character <= 'z') {
							currentSum *= (character - 'a' + 1);
						}
						//Upper;
						else {
							currentSum /= (character - 'A' + 1);
						}
					}
					//Second letter;
					else {
						if (character >= 'a' && character <= 'z') {
							currentSum += (character - 'a' + 1);
						}
						//Upper;
						else {
							currentSum -= (character - 'A' + 1);
						}
					}
				}
				sum += currentSum;
			}
		}
		//Print result;
		System.out.printf("%.2f", sum);
	}
}
