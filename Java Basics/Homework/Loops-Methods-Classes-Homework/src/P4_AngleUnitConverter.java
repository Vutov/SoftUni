import java.util.Scanner;


public class P4_AngleUnitConverter {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int lines = Integer.parseInt(input.nextLine());
		for (int i = 0; i < lines; i++) {
			String[] data = input.nextLine().split("\\s");
			if (data[1].equals("deg")) {
				System.out.printf("%.6f rad\n", degToRad(Double.parseDouble(data[0])));
			}
			else {
				System.out.printf("%.6f deg\n", radToDeg(Double.parseDouble(data[0])));
			}
		}

	}
	private static double degToRad(double degrees) {
		double radians = degrees * 0.0174532925d;
		return radians;
	}
	
	private static double radToDeg(double radians) {
		double degrees = radians * 57.2957795d;
		return degrees;
	}
}
