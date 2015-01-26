import java.util.LinkedHashMap;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;


public class P4_Nuts {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int lines = Integer.parseInt(input.nextLine());
		TreeMap<String, LinkedHashMap> companies = new TreeMap<String, LinkedHashMap>();
		for (int i = 0; i < lines; i++) {
			String[] data = input.nextLine().split("\\s+");
			if (companies.containsKey(data[0])) {
				LinkedHashMap<String, Integer> products = companies.get(data[0]);
				if (products.containsKey(data[1])) {
					String[] killos = data[2].split("\\D");
					products.put(data[1], products.get(data[1]) + Integer.parseInt(killos[0]));
					companies.put(data[0], products);
				}
				else {
					String[] killos = data[2].split("\\D");
					products.put(data[1], Integer.parseInt(killos[0]));
					companies.put(data[0], products);
				}
			}
			else {
				LinkedHashMap<String, Integer> products = new LinkedHashMap<String, Integer>();
				String[] killos = data[2].split("\\D");
				products.put(data[1], Integer.parseInt(killos[0]));
				companies.put(data[0], products);
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
				if (currentCommas != neededCommas) {
					System.out.printf("%s-%dkg, ", product.getKey(), product.getValue());
				}
				else {
					System.out.printf("%s-%dkg\n", product.getKey(), product.getValue());
				}
				currentCommas++;
			}
			
		}
		
		
	}

}
//Treemap, value -> linkedhashtree, int