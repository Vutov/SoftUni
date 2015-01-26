import java.util.Scanner;

public class P1_Timespan {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] startTime = input.nextLine().split(":");
		String[] endTime = input.nextLine().split(":");
		long startSecs = Long.parseLong(startTime[0]) * 3600
				+ Long.parseLong(startTime[1]) * 60
				+ Long.parseLong(startTime[2]);
		long endSecs = Long.parseLong(endTime[0]) * 3600
				+ Long.parseLong(endTime[1]) * 60
				+ Long.parseLong(endTime[2]);
		long diff = startSecs - endSecs;
		long diffHours = diff / 3600;
		long diffMin = (diff - diffHours * 3600) / 60;
		long diffSeconds = diff - diffHours * 3600 - diffMin * 60;
		System.out.printf("%d:%02d:%02d", diffHours, diffMin, diffSeconds);
	}
}
