import java.util.ArrayList;
import java.util.Scanner;

public class P2_SumCards {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String data = input.nextLine();
		data = data.replaceAll("J", "12");
		data = data.replaceAll("Q", "13");
		data = data.replaceAll("K", "14");
		data = data.replaceAll("A", "15");
		String[] cardValue = data.split("\\D+");
		ArrayList<Integer> cards = new ArrayList<Integer>();
		for (String card : cardValue) {
			if (!card.equals("")) {
				cards.add(Integer.parseInt(card));
			}
		}
		int sum = 0;
		for (int i = 0; i < cards.size(); i++) {
			int currentSum = cards.get(i);
			int count = 1;
			if (i < cards.size() - 1) {
				while (cards.get(i) == cards.get(i + 1)) {
					count++;
					i++;
					if (i == cards.size() - 1) {
						break;
					}
				}
				if (count != 1) {
					sum += currentSum * count * 2;
				} else {
					sum += currentSum;
				}
			} else {
				sum += currentSum;
			}
		}
		System.out.println(sum);
	}

}
