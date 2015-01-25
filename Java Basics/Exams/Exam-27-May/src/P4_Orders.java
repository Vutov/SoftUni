import java.util.LinkedHashMap;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;

public class P4_Orders {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int lines = Integer.parseInt(input.nextLine());
		LinkedHashMap<String, TreeMap> products = new LinkedHashMap<String, TreeMap>();
		for (int i = 0; i < lines; i++) {
			String[] data = input.nextLine().split("\\s+");
			if (products.containsKey(data[2])) {
				TreeMap<String, Integer> names = products.get(data[2]);
				if (names.containsKey(data[0])) {
					names.put(data[0],
							names.get(data[0]) + Integer.parseInt(data[1]));
				} else {
					names.put(data[0], Integer.parseInt(data[1]));
				}
			} else {
				TreeMap<String, Integer> names = new TreeMap<String, Integer>();
				names.put(data[0], Integer.parseInt(data[1]));
				products.put(data[2], names);
			}
		}
		for (Entry<String, TreeMap> product : products.entrySet()) {
			System.out.printf("%s: ", product.getKey());
			TreeMap<String, Integer> names = product.getValue();
			int neededCommas = -1;
			for (Entry<String, Integer> name : names.entrySet()) {
				neededCommas++;
			}
			int currentCommas = 0;
			for (Entry<String, Integer> name : names.entrySet()) {
				if (currentCommas != neededCommas) {
					System.out.printf("%s %d, ", name.getKey(), name.getValue());
				}
				else {
					System.out.printf("%s %d", name.getKey(), name.getValue());
				}
				
				currentCommas++;
			}
			System.out.printf("\n");
		}
	}

}
