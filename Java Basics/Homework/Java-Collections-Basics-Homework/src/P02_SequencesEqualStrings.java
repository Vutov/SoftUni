import java.util.Scanner;

public class P02_SequencesEqualStrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String dataInput = input.nextLine();
		dataInput += " END"; //It will never be read, used to avoid
		//exception in last pass of the loop (i + 1);s
		String[] data =	dataInput.split("\\s+");
		int count = 1;
		for (int i = 0; i < data.length - 1; i++) {
			if (data[i].equals(data[i + 1])) {
				count++;
			} else {
				for (int word = 0; word < count; word++) {
					System.out.print(data[i] + " ");
				}
				count = 1;
				System.out.println();
			}
		}
	}
}
