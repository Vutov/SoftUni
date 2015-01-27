import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map.Entry;

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
		HashMap<String, Double> order = new HashMap<String, Double>();
		try (BufferedReader br = new BufferedReader(new FileReader(
				"Order.txt"))) {
			String currentLine;
			while ((currentLine = br.readLine()) != null) {
				String[] data = currentLine.split("\\s");
				if (order.containsKey(data[1])) {
					order.put(data[1], order.get(data[1]) + Double.parseDouble(data[0]));
				}
				else {
					order.put(data[1], Double.parseDouble(data[0]));
				}
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
		//Sum total cost;
		double sum = 0d;
		for (Entry<String, Double> couple : order.entrySet()) {
			for (Product product : products) {
				if (product.getName().equals(couple.getKey())) {
					sum += product.getPrice() * couple.getValue();
				}
			}
		}
		
		//Write Output;
		PrintWriter writer;
		try {
			writer = new PrintWriter("Output.txt", "UTF-8");
			writer.println(sum);
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
