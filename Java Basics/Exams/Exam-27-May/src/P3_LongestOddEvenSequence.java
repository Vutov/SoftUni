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
			for (int j = i; j < numbers.size() - 1; j++) {
				if (numbers.get(j) % 2 == 0
						&& (numbers.get(j + 1) % 2 == 1 || numbers.get(j + 1) == 0)) {
					currentMax++;
				} else if ((numbers.get(j) % 2 == 1 || numbers.get(j) == 0)
						&& numbers.get(j + 1) % 2 == 0) {
					currentMax++;
				} else {
					break;
				}
			}
			if (currentMax > maxOddEven) {
				maxOddEven = currentMax;
			}
		}
		System.out.println(maxOddEven);
	}

}
