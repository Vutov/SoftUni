import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;


public class P4_OfficeStuff {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int lines = Integer.parseInt(input.nextLine());
		TreeMap<String, LinkedHashMap> companies = new TreeMap<String, LinkedHashMap>();
		for (int i = 0; i < lines; i++) {
			String[] data = input.nextLine().split("[\\s-|]+");
			ArrayList<String> clearedData = new ArrayList<String>();
			for (String string : data) {
				if (!string.equals("")) {
					clearedData.add(string);
				}
			}
			if (companies.containsKey(clearedData.get(0))) {
				LinkedHashMap<String, Integer> products = companies.get(clearedData.get(0));
				if (products.containsKey(clearedData.get(2))) {
					int value = Integer.parseInt(clearedData.get(1));
					products.put(clearedData.get(2), products.get(clearedData.get(2)) + value);
					companies.put(clearedData.get(0), products);
				}
				else {
					products.put(clearedData.get(2), Integer.parseInt(clearedData.get(1)));
					companies.put(clearedData.get(0), products);
				}
			}
			else {
				LinkedHashMap<String, Integer> products = new LinkedHashMap<String, Integer>();
				products.put(clearedData.get(2), Integer.parseInt(clearedData.get(1)));
				companies.put(clearedData.get(0), products);
			}
			
		}
		for (Entry<String, LinkedHashMap> company : companies.entrySet()) {
			System.out.printf("%s: ", company.getKey());
			LinkedHashMap<String, Integer> products = company.getValue();
			int neededCommas = -1;
			int currentCommas = 0;
			for (Entry<String, Integer> product : products.entrySet()) {
				neededCommas++;
			}
			for (Entry<String, Integer> product : products.entrySet()) {
				if (neededCommas != currentCommas) {
					System.out.printf("%s-%d, ", product.getKey(), product.getValue());
				}
				else {
					System.out.printf("%s-%d\n", product.getKey(), product.getValue());
				}
				currentCommas++;
			}
		}
	}

}
//TreeMap -> LinkedHashMap