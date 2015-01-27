import java.util.ArrayList;
import java.util.Scanner;

public class P3_LongestOddEvenSequence {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] nums = input.nextLine().split("\\D+");
		ArrayList<Integer> numbers = new ArrayList<Integer>();
		for (int i = 0; i < nums.length; i++) {
			if (!nums[i].equals("")) {
				numbers.add(Integer.parseInt(nums[i]));
			}
		}
		int maxOddEven = 1;
		for (int i = 0; i < numbers.size(); i++) {
			int currentMax = 1;
			boolean prevIsEven = numbers.get(i) % 2 == 0;
			for (int j = i + 1; j < numbers.size(); j++) {
				boolean currentIsEven = numbers.get(j) % 2 == 0;
				//If 0 has to be odd;
				if (numbers.get(j) == 0) {
					if (prevIsEven) {
						currentIsEven = false;
					}
				}
				//Check odd-even-odd or even-odd-even;
				if ((prevIsEven && !currentIsEven) || (!prevIsEven && currentIsEven)) {
					currentMax++;
					if (currentMax > maxOddEven) {
						maxOddEven = currentMax;
					}
				}
				else {
					currentMax = 1;
				}
				prevIsEven = currentIsEven;
			}

		}
		System.out.println(maxOddEven);
	}

}
