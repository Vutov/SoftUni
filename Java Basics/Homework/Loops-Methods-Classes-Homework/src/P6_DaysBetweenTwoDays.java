import java.text.ParseException;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.time.temporal.ChronoUnit;
import java.util.Scanner;

public class P6_DaysBetweenTwoDays {

	public static void main(String[] args) throws ParseException {
		Scanner sc = new Scanner(System.in);
		String firstDate = sc.nextLine();
		String secondDate = sc.nextLine();

		LocalDate d1 = LocalDate.parse(firstDate, DateTimeFormatter.ofPattern("d-MM-yyyy"));
		LocalDate d2 = LocalDate.parse(secondDate, DateTimeFormatter.ofPattern("d-MM-yyyy"));

		System.out.println(ChronoUnit.DAYS.between(d1, d2));
	}
}
