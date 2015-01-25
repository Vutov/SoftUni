import java.util.Scanner;


public class P1_DozenEggs {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int eggs = 0;
		for (int i = 0; i < 7; i++) {
			String[] line = input.nextLine().split("\\s");
			if (line[1].equals("dozens")) {
				eggs += 12 * Integer.parseInt(line[0]);
			}
			else {
				eggs += Integer.parseInt(line[0]);
			}
		}
		int dozens = eggs / 12;
		eggs = eggs % 12;
		System.out.printf("%d dozens + %d eggs", dozens, eggs);
	}

}
