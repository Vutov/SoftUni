import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.Map.Entry;
import java.util.TreeMap;


public class P8_ListOfProducts {

	public static void main(String[] args) {
		ArrayList<Product> products = new ArrayList<Product>();
		//Read file;
		try (BufferedReader br = new BufferedReader(new FileReader("Input.txt")))
		{
			String currentLine;
			while ((currentLine = br.readLine()) != null) {
				String[] data = currentLine.split("\\s");
				products.add(new Product(data[0], Double.parseDouble(data[1])));
			}
		} catch (IOException e) {
			e.printStackTrace();
		} 
		//Sort;
		TreeMap<Double, String> sortedList = new TreeMap<Double, String>();
		for (Product product : products) {
			sortedList.put(product.getPrice(), product.getName());
		}
		//Write file;
		PrintWriter writer;
		try {
			writer = new PrintWriter("Output.txt", "UTF-8");
			for (Entry<Double, String> product : sortedList.entrySet()) {
				writer.printf("%.2f %s", product.getKey(), product.getValue());
				writer.println();
			}
			writer.close();
		} catch (FileNotFoundException e) {
			System.out.println("File not found");
			e.printStackTrace();
		} catch (UnsupportedEncodingException e) {
			System.out.println("Unsupported encoding");
			e.printStackTrace();
		}
		System.out.println("Done! Check the folder for Output.txt");
	}

}
