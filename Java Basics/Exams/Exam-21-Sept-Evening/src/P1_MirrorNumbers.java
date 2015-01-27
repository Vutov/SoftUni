import java.util.Scanner;


public class P1_MirrorNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int len = input.nextInt();
		int[] numbers = new int[len];
		for (int i = 0; i < len; i++) {
			numbers[i] =  input.nextInt();
		}
		boolean found = false;
		for (int num1 = 0; num1 < numbers.length; num1++) {
			for (int num2 = num1 + 1; num2 < numbers.length; num2++) {
				String numOne = "" + numbers[num1];
				String numTwo = new StringBuilder("" + numbers[num2]).reverse().toString();
				if (numOne.equals(numTwo)) {
					found = true;
					System.out.printf("%d<!>%d\n", numbers[num1], numbers[num2]);
				}
			}
		}
		if (!found) {
			System.out.println("No");
		}
	}

}
