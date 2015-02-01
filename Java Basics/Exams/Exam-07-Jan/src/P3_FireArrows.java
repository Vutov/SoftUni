import java.util.Scanner;

public class P3_FireArrows {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int lines = Integer.parseInt(input.nextLine());
		String data = input.nextLine();
		int len = data.length();
		char matrix[][] = new char[lines][len];
		for (int ch = 0; ch < len; ch++) {
			matrix[0][ch] = data.charAt(ch);
		}
		// Fill matrix;
		for (int i = 1; i < lines; i++) {
			data = input.nextLine();
			len = data.length();
			for (int ch = 0; ch < len; ch++) {
				matrix[i][ch] = data.charAt(ch);
			}
		}
		for (int i = 0; i < lines; i++) {
			for (int row = 0; row < matrix.length; row++) {
				for (int col = 0; col < len; col++) {
					char currentChar = matrix[row][col];
					if (currentChar == '^' && row >= 1 && matrix[row - 1][col] == 'o') {
						matrix[row - 1][col] = '^';
						matrix[row][col] = 'o';
					} else if (currentChar == 'v' && row < lines - 1 && matrix[row + 1][col] == 'o') {
						matrix[row + 1][col] = 'v';
						matrix[row][col] = 'o';
					} else if (currentChar == '>' && col < len - 1 && matrix[row][col + 1] == 'o') {
						matrix[row][col + 1] = '>';
						matrix[row][col] = 'o';
					} else if (currentChar == '<' && col >= 1 && matrix[row][col - 1] == 'o') {
						matrix[row][col - 1] = '<';
						matrix[row][col] = 'o';
					}
				}
			}
		}
			// Print
			for (int row = 0; row < matrix.length; row++) {
				for (int col = 0; col < len; col++) {
					System.out.print(matrix[row][col]);
				}
				System.out.println();
			}

	}

}
