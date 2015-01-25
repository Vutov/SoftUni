import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;

public class P4_ActivityTracker {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int lines = Integer.parseInt(input.nextLine());
		TreeMap<Integer, TreeMap> monthLog = new TreeMap<Integer, TreeMap>();
		for (int i = 0; i < lines; i++) {
			String[] data = input.nextLine().split("\\s+"); 
			String monthStr = data[0].substring(3, 5);
			int month = Integer.parseInt(monthStr);
			if (monthLog.containsKey(month)) {
				TreeMap<String, Integer> name = monthLog.get(month);
				if (name.containsKey(data[1])) {
					name.put(data[1], name.get(data[1]) +Integer.parseInt(data[2]));
					monthLog.put(month, name);
				}
				else {
					name.put(data[1], Integer.parseInt(data[2]));
					monthLog.put(month, name);
				}
			}
			else {
				TreeMap<String, Integer> name = new TreeMap<String, Integer>();
				name.put(data[1], Integer.parseInt(data[2]));
				monthLog.put(month, name);
			}
		}
		for (Entry<Integer, TreeMap> entry : monthLog.entrySet()) {
			int key = entry.getKey();
			System.out.printf("%d: ", key);
			TreeMap<String, Integer> value = entry.getValue();
			int neededCommas = 0;
			int currentCommas = 0;
			for (Entry<String, Integer> name  : value.entrySet()) {
				neededCommas++;
			}
			for (Entry<String, Integer> name  : value.entrySet()) {
				currentCommas++;
				if (currentCommas < neededCommas) {
					System.out.printf("%s(%d), ", name.getKey(), name.getValue());
				} else {
					System.out.printf("%s(%d)", name.getKey(), name.getValue());
				}
			}
			System.out.printf("\n");
		}
	}

}
//TreeHash key month, value new treehash key name , value int