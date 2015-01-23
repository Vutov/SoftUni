
import java.util.Scanner;

public class BitRotation {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int number = Integer.parseInt(input.nextLine());
        int rotations = Integer.parseInt(input.nextLine());
        System.out.println(Integer.toBinaryString(number));
        for (int i = 0; i < rotations; i++) {
            String direction = input.nextLine();

            if (direction.compareTo("right") == 0) {
                int rightMostBit = number & 1;
                number >>= 1;
                number |= rightMostBit << 6;
            } else if (direction.compareTo("left") == 0) {
                int leftMostBit = (number >> 6) & 1;
                number <<= 1; //number = number << 1
                //System.out.println(Integer.toBinaryString(number));
                number = number & ~(1);
                number ^= leftMostBit;
                
                int left = (number >> 6) & 1;
                if (left == 1) {
					number = number ^ (1 << 6);
				}
                System.out.println(Integer.toBinaryString(number));
            }
        }

        System.out.println(number);
    }
}