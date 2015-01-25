import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class P3_Biggest3PrimeNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] numbers = input.nextLine().split("[()\\s]+");
		Set<Integer> primes = new HashSet<Integer>();
		for (String num : numbers) {
			if (!num.equals("")) {
				int number = Integer.parseInt(num);
				if (isPrime(number)) {
					primes.add(number);
				}
			}
		}
		ArrayList<Integer> primesList = new ArrayList<Integer>(primes);
		Collections.sort(primesList);
		Collections.reverse(primesList);
		if (primesList.size() > 2) {
			int sum = primesList.get(0) + primesList.get(1) + primesList.get(2);
			System.out.println(sum);
		}
		else {
			System.out.println("No");
		}
	}

	// Algorithm from:
	// http://www.mkyong.com/java/how-to-determine-a-prime-number-in-java/
	private static boolean isPrime(int number) {
		//Added for this problem!;
		if (number == 2) {
			return true;
		}
		// check if n is a multiple of 2
		else if(number == 1){
			return false;
		}
		else if (number % 2 == 0)
			return false;
		// if not, then just check the odds
		for (int i = 3; i * i <= number; i += 2) {
			if (number % i == 0)
				return false;
		}
		return true;
	}
}
