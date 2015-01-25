import java.util.Scanner;

public class InstructionSet {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String opCode = input.nextLine();

		while (!opCode.equals("END")) {
			//Fixd Regex
			String[] codeArgs = opCode.split("[,\\s]+");

			long result = 0; //All inputs fixed to long;
			switch (codeArgs[0]) {
			case "INC": {
				long operandOne = Long.parseLong(codeArgs[1]);
				//Fixed +1
				result = ++operandOne;
				break;
			}
			case "DEC": {
				long operandOne = Long.parseLong(codeArgs[1]);
				//Fixed -1
				result = --operandOne;
				break;
			}
			case "ADD": {
				//fixed
				long operandOne = Long.parseLong(codeArgs[1]);
				long operandTwo = Long.parseLong(codeArgs[2]);
				result = operandOne + operandTwo;
				break;
			}
			case "MLA": {
				long operandOne = Long.parseLong(codeArgs[1]);
				long operandTwo = Long.parseLong(codeArgs[2]);
				result = operandOne * operandTwo;
				break;
			}
			default:
				break;
			}

			System.out.println(result);

			// Need to read the input again;
			opCode = input.nextLine();
		}
	}
}