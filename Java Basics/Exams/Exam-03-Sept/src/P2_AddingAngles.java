import java.util.Scanner;

public class P2_AddingAngles {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int numAngles = Integer.parseInt(input.nextLine());
		int[] angles = new int[numAngles];
		for (int i = 0; i < numAngles; i++) {
			angles[i] = input.nextInt();
		}
		boolean found = false;
		for (int first = 0; first < angles.length; first++) {
			for (int second = first; second < angles.length; second++) {
				for (int third = second; third < angles.length; third++) {
					if (first != second && first != third && second != third) {
						int sum = angles[first] + angles[second]
								+ angles[third];
						if (sum % 360 == 0) {
							System.out.printf("%d + %d + %d = %d degrees\n",
									angles[first], angles[second],
									angles[third], sum);
							found = true;
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
