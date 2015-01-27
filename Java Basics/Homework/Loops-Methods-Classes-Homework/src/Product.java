
public class Product {
	private String name;
	private double price;
	
	//Constructors;
	public Product(String name, double price) {
		this.name = name;
		this.price = price;
	}
	
	//Methods;
	public String getName() {
		return this.name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public double getPrice() {
		return this.price;
	}
	
	public void setPrice(double price) {
		this.price = price;
	}
}
