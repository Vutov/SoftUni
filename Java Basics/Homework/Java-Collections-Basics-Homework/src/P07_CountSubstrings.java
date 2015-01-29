import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class P07_CountSubstrings {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String data = input.nextLine().toLowerCase();
		String searchWord = input.nextLine();
		Pattern search = Pattern.compile(searchWord);
		Matcher matcher = search.matcher(data);
		int counter = 0;
		while (matcher.find()) {
			counter++;
		}
		System.out.println(counter);
	}

}
