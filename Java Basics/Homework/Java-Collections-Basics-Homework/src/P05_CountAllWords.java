import java.util.Scanner;


public class P05_CountAllWords {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] data = input.nextLine().split("[^a-zA-Z]+");
		System.out.println(data.length);
	}

}
