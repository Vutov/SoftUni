import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;

public class P9_OrderOfProducts {

	public static void main(String[] args) {
		ArrayList<Product> products = new ArrayList<Product>();
		// Read file input;
		try (BufferedReader br = new BufferedReader(new FileReader(
				"Products.txt"))) {
			String currentLine;
			while ((currentLine = br.readLine()) != null) {
				String[] data = currentLine.split("\\s");
				products.add(new Product(data[0], Double.parseDouble(data[1])));
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
		// Read order;
		try (BufferedReader br = new BufferedReader(new FileReader(
				"Products.txt"))) {
			String currentLine;
			while ((currentLine = br.readLine()) != null) {
				String[] data = currentLine.split("\\s");
				
				//Get Data
				
				
				
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
		//Sum total cost;
		double sum = 0d;
		
		
		
		//Write Output;
		PrintWriter writer;
		try {
			writer = new PrintWriter("Output.txt", "UTF-8");
			
			//for to write file;'
			
			writer.close();
		} catch (FileNotFoundException e) {
			System.out.println("File not found");
			e.printStackTrace();
		} catch (UnsupportedEncodingException e) {
			System.out.println("Unsupported encoding");
			e.printStackTrace();
		}
		System.out.println("Done!");
		
	}

}
