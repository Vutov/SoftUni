import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class P2_ThreeLargestNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int len = input.nextInt();
		ArrayList<BigDecimal> numbers = new ArrayList<BigDecimal>();
		for (int i = 0; i < len; i++) {
			numbers.add(input.nextBigDecimal());
		}
		Collections.sort(numbers);
		if (len == 1) {
			System.out.println(numbers.get(0));
		} else if (len == 2) {
			for (int i = 0; i < 2; i++) {
				System.out.println(numbers.get(len - 1 - i));
			}
		} else {
			for (int i = 0; i < 3; i++) {
				System.out.println(numbers.get(len - 1 - i));
			}
		}
	}

}
