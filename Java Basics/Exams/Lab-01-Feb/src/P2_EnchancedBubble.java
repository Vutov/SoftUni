import java.util.ArrayList;
import java.util.Scanner;

public class P2_EnchancedBubble {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);

		String[] numbers = scan.nextLine().replace("[", "").replace("]", "")
				.split(", ");
		ArrayList<Integer> numbersArr = new ArrayList<Integer>();

		for (String num : numbers) {
			numbersArr.add(Integer.parseInt(num));
		}

		for (int i = numbersArr.size() - 1; i >= 0; i--) {
			for (int j = 0; j < i; j++) {
				if (numbersArr.get(j) > numbersArr.get(j + 1)) {
					int temp = numbersArr.get(j);
					numbersArr.set(j, numbersArr.get(j + 1));
					numbersArr.set(j + 1, temp);
				}
			}
		}

		// stopWatch.stop();
		// long time = stopWatch.getTime();
		System.out.println(numbersArr);
		// System.out.println(time/1000.0);
	}
}