import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;

public class P4_UserLogs {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		//Read lines;
		String log = input.nextLine();
		TreeMap<String, LinkedHashMap<String, Integer>> user = new TreeMap<>();
		while (!log.equals("end")) {
			String[] data = log.split("[IP= ]+");
			ArrayList<String> clearedData = new ArrayList<>();
			//Validate input for ghosts;
			for (int i = 0; i < data.length; i++) {
				if (!data[i].equals("")) {
					clearedData.add(data[i]);
				} 
			}
			//Fill data;
			String ip = clearedData.get(0);
			String userName = clearedData.get(4);
			if (user.containsKey(userName)) {
				LinkedHashMap<String, Integer> ipCount = user.get(userName);
				int count = 1;
				if (ipCount.containsKey(ip)) {
					count += ipCount.get(ip);
				}
				ipCount.put(ip, count);
				user.put(userName, ipCount);
			}
			else {
				LinkedHashMap<String, Integer> ipCount = new LinkedHashMap<>();
				ipCount.put(ip, 1);
				user.put(userName, ipCount);
			}
			//Get next line;
			log = input.nextLine();
		}
		//Print the data;
		for (Entry<String, LinkedHashMap<String, Integer>> info : user.entrySet()) {
			System.out.printf("%s:\n", info.getKey());
			LinkedHashMap<String, Integer> ipCount = info.getValue();
			int commas = -1;
			int needCommas = 0;
			for (Entry<String, Integer> ip : ipCount.entrySet()) {
				commas++;
			}
			for (Entry<String, Integer> ip : ipCount.entrySet()) {
				if (commas == needCommas) {
					System.out.printf("%s => %d.\n", ip.getKey(), ip.getValue());
				}
				else {
					System.out.printf("%s => %d, ", ip.getKey(), ip.getValue());
				}
				needCommas++;
			}
		}
		
		
		
		
	}

}
// user - treemap, ip - linkedhashmap, integer