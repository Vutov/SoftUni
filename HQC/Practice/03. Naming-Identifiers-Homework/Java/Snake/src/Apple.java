import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;


public class Apple {
	public static Random rng;
	private Point apple;
	private Color snakeColor;
	
	public Apple(Snake snake) {
		apple = createApple(snake);
		snakeColor = Color.RED;		
	}
	
	private Point createApple(Snake snake) {
		rng = new Random();
		int x = rng.nextInt(30) * 20; 
		int y = rng.nextInt(30) * 20;
		for (Point snakePoint : snake.body) {
			if (x == snakePoint.getX() || y == snakePoint.getY()) {
				return createApple(snake);				
			}
		}
		return new Point(x, y);
	}
	
	public void drawApple(Graphics g){
		apple.draw(g, snakeColor);
	}	
	
	public Point getPoint(){
		return apple;
	}
}
