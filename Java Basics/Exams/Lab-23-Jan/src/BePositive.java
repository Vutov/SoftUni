import java.util.ArrayList;
import java.util.Scanner;

public class BePositive {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scn = new Scanner(System.in);

		//Fixed the scanner to read line, not next int;
		String data = scn.nextLine();
		int countSequences = Integer.parseInt(data);

		for (int i = 0; i < countSequences; i++) {
			String[] input = scn.nextLine().trim().split(" ");
			ArrayList<Integer> numbers = new ArrayList<>();

			for (int j = 0; j < input.length; j++) {
				if (!input[j].equals("")) {
					int num = Integer.parseInt(input[j]);
					numbers.add(num);
				}
			}

			boolean found = false;
			for (int j = 0; j < numbers.size(); j++) {
				int currentNum = numbers.get(j);
				// Added =
				if (currentNum >= 0) {
					// Changed the condition to !=
					System.out.printf("%d%s", currentNum,
							j != numbers.size() - 1 ? " " : "\n");
					found = true;
				} else {
					//Added - 1 to fix exception - out of bounds
					if (j < numbers.size() - 1) {

						currentNum += numbers.get(j + 1);
						j++;
						// Added =
						if (currentNum >= 0) {
							// Changed the condition to !=
							System.out.printf("%d%s", currentNum,
									j != numbers.size() - 1 ? " " : "\n");
							found = true;

						}
					}
				}
			}

			if (!found) {
				System.out.println("(empty)");
			}
		}
	}
}