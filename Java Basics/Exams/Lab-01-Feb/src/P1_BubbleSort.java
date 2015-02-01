import java.util.ArrayList;
import java.util.Scanner;

//import org.apache.commons.lang.time.StopWatch;

public class P1_BubbleSort {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);

		String[] numbers = scan.nextLine().replace("[", "").replace("]", "")
				.split(", ");
		ArrayList<Integer> numbersArr = new ArrayList<Integer>();
		
		for (String num : numbers) {
			numbersArr.add(Integer.parseInt(num));
		}

		// StopWatch stopWatch = new StopWatch();
		// stopWatch.start();

		boolean sort = true;
		while (sort) {
			sort = false;
			for (int i = 0; i < numbersArr.size() -1; i++) {
				if (numbersArr.get(i) > numbersArr.get(i + 1)) {
					//Second number is smaller than first number
					int swapper = numbersArr.get(i);
					int next = numbersArr.get(i + 1);
					numbersArr.set(i, next);
					numbersArr.set(i + 1, swapper);
					sort = true;
				}
			}
		}
		// stopWatch.stop();
		// long time = stopWatch.getTime();
		System.out.println(numbersArr);
		// System.out.println(time/1000.0);
	}
}
