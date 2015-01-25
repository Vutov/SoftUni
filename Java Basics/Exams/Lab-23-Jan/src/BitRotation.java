import java.util.Scanner;

public class BitRotation {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);

		byte number = Byte.parseByte(input.nextLine());
		byte rotations = Byte.parseByte(input.nextLine());

		for (int i = 0; i < rotations; i++) {
			String direction = input.nextLine();
			//Fixed the comparison
			if (direction.compareTo("right") == 0) {
				int rightMostBit = number & 1;
				number >>= 1;
				//Changed to 5
				number |= rightMostBit << 5;
			//Fixed the comparison
			} else if (direction.compareTo("left") == 0) {
				//Changed to 5
				int leftMostBit = (number >> 5) & 1;
				number <<= 1;
				number |= leftMostBit;
				//Added 7th bit zeroing to keep it 6 bits
				number &= ~(1 << 6);
			}
		}

		System.out.println(number);
	}
}