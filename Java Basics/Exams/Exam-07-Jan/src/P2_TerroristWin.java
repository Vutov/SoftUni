import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P2_TerroristWin {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String text = input.nextLine();
		Pattern bombPattern = Pattern.compile("\\|(.*?)\\|");
		Matcher matcher = bombPattern.matcher(text);
		ArrayList<String> bombs = new ArrayList<>();
		while (matcher.find()) {
			String bomb = matcher.group();
			bomb = bomb.replaceAll("\\|", "");
			bombs.add(bomb);
		}
		for (String bomb : bombs) {
			int bombStrenght = 0;
			for (int i = 0; i < bomb.length(); i++) {
				bombStrenght += bomb.charAt(i);
			}
			String bombStr = "" + bombStrenght;
			int len = bombStr.length();
			String lastDigit = "" + bombStr.charAt(len - 1);
			bombStrenght = Integer.parseInt(lastDigit);
			int firstSlash = text.indexOf("|");
			int secondSlash = text.indexOf("|", firstSlash + 1);
			firstSlash -= bombStrenght;
			secondSlash += bombStrenght;
			String newText = "";
			for (int i = 0; i < text.length(); i++) {
				if (i >= firstSlash && i <= secondSlash) {
					newText += ".";
				}
				else {
					newText += text.charAt(i);
				}
			}
			text = newText;
		}
		System.out.println(text);
	}
}
