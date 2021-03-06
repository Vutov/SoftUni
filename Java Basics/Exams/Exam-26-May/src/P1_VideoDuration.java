import java.util.Scanner;


public class P1_VideoDuration {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		
		int totalMin = 0;
		String data = input.next();
		while (data.compareTo("End") != 0) {
			String[] video = data.split(":");
			totalMin += Integer.parseInt(video[0]) * 60 + Integer.parseInt(video[1]);
			data = input.next();
		}
		int totalHours = totalMin / 60;
		totalMin = totalMin - (totalHours * 60);
		System.out.printf("%d:%02d", totalHours, totalMin);
		//System.out.println(totalHours + ":" + totalMin);
	}

}
