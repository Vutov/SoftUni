import java.util.Scanner;

public class P04_LongestIncreasingSequence {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] data = input.nextLine().split("\\s+");
		int[] numbers = new int[data.length + 1];
		for (int i = 0; i < data.length; i++) {
			numbers[i] = Integer.parseInt(data[i]);
		}
		numbers[data.length] = Integer.MIN_VALUE; // So the last sequence can be
		// printed properly;
		int maxCount = 1;
		int currentCount = 1;
		int startIndex = 0;
		int maxStartIndex = 0;
		for (int d2 = 0; d2 < numbers.length - 1; d2++) {
			if (numbers[d2] < numbers[d2 + 1]) {
				currentCount++;
				if (currentCount > maxCount) {
					maxCount = currentCount;
					maxStartIndex = d2 - currentCount + 2;
				}
			} else {
				for (int i = startIndex; i < currentCount + startIndex; i++) {
					System.out.print(numbers[i] + " ");
				}
				System.out.println();
				currentCount = 1;
				startIndex = d2 + 1;
			}
		}
		System.out.print("Longest: ");
		for (int i = maxStartIndex; i < maxStartIndex + maxCount; i++) {
			System.out.print(numbers[i] + " ");
		}
	}
}
