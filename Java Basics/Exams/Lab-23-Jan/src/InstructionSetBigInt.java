
import java.math.BigInteger;
import java.util.Scanner;

public class InstructionSetBigInt {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String opCode = input.nextLine();

		while (opCode.compareTo("END") != 0) {
			//Incomplete regex was used
			String[] codeArgs = opCode.split("[,\\s]+");
			
			//Need biginteger for *
			BigInteger result = new BigInteger("0");
			switch (codeArgs[0]) {
			case "INC": {
				int operandOne = Integer.parseInt(codeArgs[1]);
				//new syntax
				result = result.add(new BigInteger("1")).add(BigInteger.valueOf(operandOne));
				break;
			}
			case "DEC": {
				int operandOne = Integer.parseInt(codeArgs[1]);
				//new syntax
				result = result.subtract(new BigInteger("1")).add(BigInteger.valueOf(operandOne));
				break;
			}
			case "ADD": {
				int operandOne = Integer.parseInt(codeArgs[1]);
				int operandTwo = Integer.parseInt(codeArgs[2]);
				//new syntax
				result = result.add(BigInteger.valueOf(operandOne).add(BigInteger.valueOf(operandTwo)));
				break;
			}
			case "MLA": {
				int operandOne = Integer.parseInt(codeArgs[1]);
				int operandTwo = Integer.parseInt(codeArgs[2]);
				//New syntax
				BigInteger multiplied = new BigInteger("0");
				multiplied = multiplied.add(BigInteger.valueOf(operandOne));
				multiplied = multiplied.multiply(BigInteger.valueOf(operandTwo));
				result = multiplied;
				break;
			}
			default:
				break;
			}

			System.out.println(result);
			//Need to read the input again;
			opCode = input.nextLine();
		}
	}
}