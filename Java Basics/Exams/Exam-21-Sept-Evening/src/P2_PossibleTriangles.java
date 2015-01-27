import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;


public class P2_PossibleTriangles {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String data = input.nextLine();
		boolean found = false;
		while (!data.equals("End")) {
			String[] sides = data.split("\\s+");
			ArrayList<Double> sortedSides = new ArrayList<Double>();
			for (String side : sides) {
				sortedSides.add(Double.parseDouble(side));
			}
			Collections.sort(sortedSides);
			if (sortedSides.get(0) + sortedSides.get(1) > sortedSides.get(2)) {
				System.out.printf("%.2f+%.2f>%.2f\n", 
						sortedSides.get(0), sortedSides.get(1), sortedSides.get(2));
				found = true;
			}
			
			
			data = input.nextLine();
		}
		if (!found) {
			System.out.println("No");
		}

	}
}
