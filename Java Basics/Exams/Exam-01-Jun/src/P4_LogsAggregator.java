import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;

public class P4_LogsAggregator {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int lines = Integer.parseInt(input.nextLine());
		TreeMap<String, Integer> names = new TreeMap<String, Integer>();
		TreeMap<String, HashSet> ips = new TreeMap<String, HashSet>();
		for (int i = 0; i < lines; i++) {
			String[] data = input.nextLine().split("\\s+");
			if (names.containsKey(data[1])) {
				names.put(data[1],
						names.get(data[1]) + Integer.parseInt(data[2]));
				HashSet ip = ips.get(data[1]);
				ip.add(data[0]);
				ips.put(data[1], ip);
			} else {
				names.put(data[1], Integer.parseInt(data[2]));
				HashSet<String> ip = new HashSet<String>();
				ip.add(data[0]);
				ips.put(data[1], ip);
			}
		}
		HashMap<String, ArrayList> sortedIps = new HashMap<String, ArrayList>();
		for (Entry<String, HashSet> ipSet : ips.entrySet()) {
			ArrayList<String> sortedIp = new ArrayList<String>(ipSet.getValue());
			Collections.sort(sortedIp);
			sortedIps.put(ipSet.getKey(), sortedIp);
		}

		for (Entry<String, Integer> name : names.entrySet()) {
			System.out.printf("%s: %d ", name.getKey(), name.getValue());
			System.out.printf("%s\n", sortedIps.get(name.getKey()));
		}

	}
}
