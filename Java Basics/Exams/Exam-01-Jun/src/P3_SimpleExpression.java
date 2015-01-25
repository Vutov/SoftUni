import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Scanner;


public class P3_SimpleExpression {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String data = input.nextLine();
		String[] num = data.split("[\\s+-]+");
		String[] comm = data.split("[^+-]+");
		ArrayList<BigDecimal> numbers = new ArrayList<BigDecimal>();
		ArrayList<String> commands = new ArrayList<String>();
		for (String number : num) {
			if (!number.equals("")) {
				numbers.add(new BigDecimal(number));
			}
		}
		for (String command : comm) {
			if (!command.equals("")) {
				commands.add(command);
			}
		}
		BigDecimal sum = new BigDecimal("0");
		sum = sum.add(numbers.get(0));
		for (int i = 1; i < numbers.size(); i++) {
			if (commands.get(i - 1).equals("-")) {
				sum = sum.subtract(numbers.get(i));
			}
			else {
				sum = sum.add(numbers.get(i));
			}
		}
		System.out.println(sum);
	}

}
// if ""
