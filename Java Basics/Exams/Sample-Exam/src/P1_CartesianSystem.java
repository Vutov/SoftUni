import java.util.Scanner;


public class P1_CartesianSystem {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		double x = input.nextDouble();
		double y = input.nextDouble();
		
		if (x == 0 && y == 0) {
			System.out.println(0);
		}
		else if(x > 0 && y > 0) {
			System.out.println(1);
		}
		else if (x < 0 && y > 0) {
			System.out.println(2);
		}
		else if (x < 0 && y < 0) {
			System.out.println(3);
		}
		else if (x >0 && y < 0) {
			System.out.println(4);
		}
		else if (x == 0) {
			System.out.println(5);
		}
		else { //y == 0
			System.out.println(6);
		}

	}

}
