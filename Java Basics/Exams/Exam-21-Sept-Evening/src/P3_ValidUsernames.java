import java.util.ArrayList;
import java.util.Scanner;


public class P3_ValidUsernames {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] notValidatedDate = input.nextLine().split("[^a-zA-Z0-9_]+");
		ArrayList<String> data = new ArrayList<String>();
		for (String username : notValidatedDate) {
			boolean correntSize = username.length() >= 3 && username.length() <= 25;
			String user = username.toLowerCase();
			if (correntSize && user.charAt(0) >= 'a' && user.charAt(0) <= 'z') {
				data.add(username);
				//System.out.println(username);
			}
		}
		int bestIndex = 0;
		int maxLenght = 0;
		for (int i = 0; i < data.size(); i++) {
			for (int j = i; j < data.size() - 1; j++) {
				int currentLenght = data.get(j).length() + data.get(j + 1).length();
				if (currentLenght > maxLenght) {
					maxLenght = currentLenght;
					bestIndex = j;
				}
			}
		}
		System.out.println(data.get(bestIndex));
		System.out.println(data.get(bestIndex + 1));
	}

}
