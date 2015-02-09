import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class P3_LegoBlocks {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int len = Integer.parseInt(input.nextLine());
		//Fill first matrix;
		ArrayList<ArrayList<String>> firstMatrix = new ArrayList<>();
		for (int i = 0; i < len; i++) {
			String data[] = input.nextLine().trim().split("\\s+");
			ArrayList<String> col = new ArrayList<>();
			for (String string : data) {
				col.add(string);
			}
			firstMatrix.add(col);
		}
		//Fill second matrix;
		ArrayList<ArrayList<String>> secondMatrix = new ArrayList<>();
		for (int i = 0; i < len; i++) {
			String data[] = input.nextLine().trim().split("\\s+");
			ArrayList<String> col = new ArrayList<>();
			for (String string : data) {
				col.add(string);
			}
			secondMatrix.add(col);
		}
		//Reverse second matrix;
		ArrayList<ArrayList<String>> reversedSecond = new ArrayList<>();
		for (int i = 0; i < secondMatrix.size(); i++) {
			ArrayList col = secondMatrix.get(i);
			Collections.reverse(col);
			reversedSecond.add(col);
		}
		//Merge matrixes;
		ArrayList<ArrayList<String>> finalPrint = new ArrayList<>();
		for (int i = 0; i < firstMatrix.size(); i++) {
			ArrayList<String> firstList = firstMatrix.get(i);
			ArrayList<String> secondList = reversedSecond.get(i);
			firstList.addAll(secondList);
			finalPrint.add(firstList);
		}
		//Check if the new matrix is valid for print;
		int totalLen = 0;
		boolean isValid = true;
		for (int i = 0; i < finalPrint.size() - 1; i++) {
			ArrayList<String> line = finalPrint.get(i);
			ArrayList<String> nextLine = finalPrint.get(i + 1);
			totalLen += line.size();
			if (line.size() != nextLine.size()) {
				isValid = false;
			}
		}
		ArrayList<String> lastLine = finalPrint.get(finalPrint.size() - 1);
		totalLen += lastLine.size();
		//Print valid;
		if (isValid) {
			for (int i = 0; i < finalPrint.size(); i++) {
				ArrayList<String> line = finalPrint.get(i);
				System.out.print("[");
				int count = -1;
				int currentCount = 0;
				for (String letter : line) {
					count++;
				}
				for (String letter : line) {
					if (count == currentCount) {
						System.out.printf("%s]\n", letter);
					} else {
						System.out.printf("%s, ", letter);
					}
					currentCount++;
				}
			}
		//Print size;
		} else {
			System.out.printf("The total number of cells is: %d", totalLen);
		}
	}
}
