import java.util.ArrayList;
import java.util.Scanner;


public class P2_MagicSum {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int divider = Integer.parseInt(input.nextLine());
		String number = input.nextLine();
		ArrayList<Integer> numbers = new ArrayList<Integer>();
		while (!number.equals("End")) {
			int num = Integer.parseInt(number);
			numbers.add(num);
			number = input.nextLine();
		}
		int savedSum = Integer.MIN_VALUE;
		int savedNum1 = 0;
		int savedNum2 = 0;
		int savedNum3 = 0;
		boolean found = false;
		for (int num1 = 0; num1 < numbers.size(); num1++) {
			for (int num2 = 0; num2 < numbers.size(); num2++) {
				for (int num3 = 0; num3 < numbers.size(); num3++) {
					if (num1 != num2 && num2 != num3 && num1 != num2 && num1 != num3) {
						int currentSum = numbers.get(num1) + numbers.get(num2) +
								numbers.get(num3);
						if (currentSum % divider == 0) {
							if (currentSum > savedSum) {
								savedSum = currentSum;
								savedNum1 = numbers.get(num1);
								savedNum2 = numbers.get(num2);
								savedNum3 = numbers.get(num3);
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
		else {
			System.out.printf("(%d + %d + %d) %% %d = 0", savedNum1, savedNum2, savedNum3, divider);
		}

	}

}
