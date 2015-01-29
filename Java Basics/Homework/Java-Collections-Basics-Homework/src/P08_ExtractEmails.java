import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P08_ExtractEmails {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String data = input.nextLine();
		Pattern phonePattern = Pattern.compile("[a-zA-Z.]+(@)+[a-zA-Z.]+[.][a-z]+");
		Matcher matcher = phonePattern.matcher(data);
		while (matcher.find()) {
			System.out.println(matcher.group());
		}

	}
}
