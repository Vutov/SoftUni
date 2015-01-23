
public class AverageSum {
	
	public static void main(String[] args) {
		
		double[] grades = new double[] {5, 3.5, 4.44, 6.00, 2.20, 3.11};
		double average = GetAverage(grades);
		
		System.out.println(average);
	}
	
	private static double GetAverage(double[] array) {
		double sum = 0;
		for (int i = 0; i < array.length; i++) {
			sum += array[i];
		}
		
		return sum / array.length;
	}
}