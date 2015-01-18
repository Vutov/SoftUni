import java.math.BigInteger;
import java.util.Scanner;


public class P2_Tribonacii {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		BigInteger firstNum = input.nextBigInteger();
		BigInteger secondNum = input.nextBigInteger();
		BigInteger thirdNum = input.nextBigInteger();
		int neededNum = input.nextInt();
		BigInteger nextNum = new BigInteger("0");
		
		switch (neededNum) {
		case 1:
			System.out.println(firstNum);
			break;
		case 2:
			System.out.println(secondNum);
			break;
		case 3:
			System.out.println(thirdNum);
			break;

		default:
			for (int i = 3; i < neededNum; i++) {
				nextNum = firstNum.add(secondNum).add(thirdNum);
				firstNum = secondNum;
				secondNum = thirdNum;
				thirdNum = nextNum;
			}
			System.out.println(nextNum);
			break;
		}

	}
}
