import java.util.Scanner;


public class P8_CountEqualBitPairs {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		long number = input.nextLong();

		int count = 0;
		String binary = Long.toBinaryString(number);
		int len = binary.length();
		for(int bit = 0; bit < len - 1; bit++) {
		    long currentBit = (number >> bit) & 1L;
		    long nextBit = (number >> bit + 1) & 1L;
		    if (currentBit == nextBit) {
		        count++;
		    }
		}
		System.out.println(count);
	}

}
