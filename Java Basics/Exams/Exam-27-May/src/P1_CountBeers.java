import java.util.Scanner;


public class P1_CountBeers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] data = input.nextLine().split("\\s+");
		int beers = 0;
		while(!data[0].equals("End")) {
			if (data[1].equals("stacks")) {
				beers += Integer.parseInt(data[0]) * 20;
			}
			else {
				beers += Integer.parseInt(data[0]);
			}
			data = input.nextLine().split("\\s+");
		}
		int stacks = beers / 20;
		beers = beers % 20;
		System.out.printf("%d stacks + %d beers", stacks, beers);
	}

}
