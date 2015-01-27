import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;


public class P7_SumNumsTextFile {

	public static void main(String[] args) {
		ArrayList<Integer> numbers = new ArrayList<Integer>();
		try (BufferedReader br = new BufferedReader(new FileReader("data.txt")))
		{
			String currentLine;
			while ((currentLine = br.readLine()) != null) {
				try {
				numbers.add(Integer.parseInt(currentLine));
				} catch (NumberFormatException nfe) {
					System.out.println("Error");
				}
			}
 
		} catch (IOException e) {
			e.printStackTrace();
		} 
		int sum = 0;
		for (Integer number : numbers) {
			sum +=number;
		}
		System.out.println(sum);
		
	}

}
