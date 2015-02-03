
public class Hero {
	private String name;
	private int maximumHealthPoints;
	private int maximumAbilityPower;
	private int healthPoints;
	private int basicAttack;
	private int abilityPower;
	private int mazeX;
	private int mazeY;

	//Constructor
	public Hero(String name, int HP, int basicAttack, int abilityPower){
		this.name = name;
		this.maximumHealthPoints = HP;
		this.healthPoints = HP;
		this.basicAttack = basicAttack;
		this.abilityPower = abilityPower;
		this.maximumAbilityPower = abilityPower;
		this.mazeX = 1;
		this.mazeY = 1;
	}
	
	//Methods
	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}
	
	public int GetMaxHP() {
		return maximumHealthPoints;
	}
	
	public int getHP() {
		return healthPoints;
	}

	public void setHP(int healthPoints) {
		this.healthPoints = healthPoints;
	}

	public int getBasicAttack() {
		return basicAttack;
	}

	public void setBasicAttack(int basicAttack) {
		this.basicAttack = basicAttack;
	}

	public int getAbilityPower() {
		return abilityPower;
	}

	public void setAbilityPower(int abilityPower) {
		this.abilityPower = abilityPower;
	}
	
	public int getMaximumAbilityPower() {
		return maximumAbilityPower;
	}
	
	public int getMazeX() {
		return mazeX;
	}

	public void setMazeX(int mazeX) {
		this.mazeX = mazeX;
	}

	public int getMazeY() {
		return mazeY;
	}

	public void setMazeY(int mazeY) {
		this.mazeY = mazeY;
	}
	
	public void addHP(int value) {
		this.healthPoints += value;
	}
	
	public void removeHP(int value) {
		this.healthPoints -= value;
	}
	
	public void resetHP() {
		this.healthPoints = this.maximumHealthPoints;
	}
	
	public void addBasicAttack(int value) {
		this.basicAttack += value;
	}
	
	public void removeBasicAttack(int value) {
		this.basicAttack -= value;
		if (this.basicAttack < 30) {
			this.basicAttack = 30;
		}
	}
	
	public void resetAbilityPower() {
		this.abilityPower = this.maximumAbilityPower;
	}
	
	public boolean isDead() {
		if (this.healthPoints <= 0) {
			return true;
		}
		return false;
	}
	
}
