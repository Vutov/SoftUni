
import java.util.ArrayList;
import java.util.Scanner;

//import org.apache.commons.lang.time.StopWatch;

public class P3_SelectionSort {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] numbers = scan.nextLine().replace("[", "").replace("]", "").split(", ");
        ArrayList<Integer> numbersArr = new ArrayList<Integer>();

        for (String num : numbers) {
			numbersArr.add(Integer.parseInt(num));
		}

//        StopWatch stopWatch = new StopWatch();
//        stopWatch.start();
        
        int len = numbersArr.size();
        for (int i = len - 1; i > 0; i--) {
        	int min = 0;
			for (int j = 1; j <= i; j++) {
				if (numbersArr.get(j) > numbersArr.get(min)) {
					min = j;
				}
			}
			int swapper = numbersArr.get(min);
			int next = numbersArr.get(i);
			numbersArr.set(min, next);
			numbersArr.set(i, swapper);

		}
     
//        stopWatch.stop();
//        long time = stopWatch.getTime();

        System.out.println(numbersArr);
//        System.out.println(time/1000.0);
    }
}
