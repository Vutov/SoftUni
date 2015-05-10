import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

public class Snake{
	LinkedList<Point> body = new LinkedList<Point>();
	private Color snakeColor;
	private int velocityX, velocityY;
	
	public Snake() {
		snakeColor = Color.GREEN;
		body.add(new Point(300, 100)); 
		body.add(new Point(280, 100)); 
		body.add(new Point(260, 100)); 
		body.add(new Point(240, 100)); 
		body.add(new Point(220, 100)); 
		body.add(new Point(200, 100)); 
		body.add(new Point(180, 100));
		body.add(new Point(160, 100));
		body.add(new Point(140, 100));
		body.add(new Point(120, 100));

		velocityX = 20;
		velocityY = 0;
	}
	
	public void draw(Graphics g) {		
		for (Point point : this.body) {
			point.draw(g, snakeColor);
		}
	}
	
	public void tick() {
		Point newPossition = new Point((body.get(0).getX() + velocityX), (body.get(0).getY() + velocityY));
		
		if (newPossition.getX() > Game.WIDTH - 20) {
		 	Game.gameRunning = false;
		} else if (newPossition.getX() < 0) {
			Game.gameRunning = false;
		} else if (newPossition.getY() < 0) {
			Game.gameRunning = false;
		} else if (newPossition.getY() > Game.height - 20) {
			Game.gameRunning = false;
		} else if (Game.apple.getPoint().equals(newPossition)) {
			body.add(Game.apple.getPoint());
			Game.apple = new Qbalkata(this);
			Game.points += 50;
		} else if (body.contains(newPossition)) {
			Game.gameRunning = false;
			System.out.println("You ate yourself");
		}	
		
		for (int i = body.size()-1; i > 0; i--) {
			body.set(i, new Point(body.get(i-1)));
		}	
		body.set(0, newPossition);
	}

	public int getVelX() {
		return velocityX;
	}

	public void setX(int velX) {
		this.velocityX = velX;
	}

	public int getY() {
		return velocityY;
	}

	public void setY(int velY) {
		this.velocityY = velY;
	}
}
