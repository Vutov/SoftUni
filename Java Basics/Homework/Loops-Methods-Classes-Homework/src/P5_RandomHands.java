import java.util.Random;
import java.util.Scanner;


public class P5_RandomHands {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		Random rng = new Random();
		int hands = Integer.parseInt(input.nextLine());
		char[] suits = { '\u2660', '\u2665', '\u2666', '\u2663' };
		for (int i = 0; i < hands; i++) {
			String[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J",
					"Q", "K", "A" };
			int cards = 0;
			for (int card = 0; card < 5; card++) {
				int face = rng.nextInt(faces.length);
				int suit = rng.nextInt(suits.length);
				if (!faces[face].equals("")) {
					System.out.printf("%s%s ",faces[face], suits[suit]);
					faces[face] = "";
					cards++;
					if (cards == 5) {
						System.out.println();
						cards = 1;
					}
				}
				else {
					card--;
				}
				
			}
		}

	}

}
