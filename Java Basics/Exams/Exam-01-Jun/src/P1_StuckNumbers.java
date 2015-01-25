import java.util.Scanner;

public class P1_StuckNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int len = input.nextInt();
		int[] numbers = new int[len];
		for (int i = 0; i < len; i++) {
			numbers[i] = input.nextInt();
		}
		boolean found = false;
		len = numbers.length;
		for (int a = 0; a < len; a++) {
			for (int b = 0; b < len; b++) {
				for (int c = 0; c < len; c++) {
					for (int d = 0; d < len; d++) {
						if (a != b && a != c && a != d && b != c && b != d
								&& c != d) {
							String wordOne = "" + numbers[a] + numbers[b];
							String wordTwo = "" + numbers[c] + numbers[d];
							if (wordOne.equals(wordTwo)) {
								System.out.printf("%s|%s==%s|%s\n", numbers[a],
										numbers[b], numbers[c], numbers[d]);
								found = true;
							}
						}
					}
				}
			}
		}
		if (!found) {
			System.out.println("No");
		}

	}

}