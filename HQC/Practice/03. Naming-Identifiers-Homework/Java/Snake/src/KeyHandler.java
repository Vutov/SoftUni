import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class KeyHandler implements KeyListener{
	
	public KeyHandler(Game game){
		game.addKeyListener(this);
	}
	
	public void keyPressed(KeyEvent e) {
		int pressedKey = e.getKeyCode();
		
		if (pressedKey == KeyEvent.VK_W || pressedKey == KeyEvent.VK_UP) {
			if(Game.snake.getY() != 20){
				Game.snake.setX(0);
				Game.snake.setY(-20);
			}
		}
		if (pressedKey == KeyEvent.VK_S || pressedKey == KeyEvent.VK_DOWN) {
			if(Game.snake.getY() != -20){
				Game.snake.setX(0);
				Game.snake.setY(20);
			}
		}
		if (pressedKey == KeyEvent.VK_D || pressedKey == KeyEvent.VK_RIGHT) {
			if(Game.snake.getVelX() != -20){
			Game.snake.setX(20);
			Game.snake.setY(0);
			}
		}
		if (pressedKey == KeyEvent.VK_A || pressedKey == KeyEvent.VK_LEFT) {
			if(Game.snake.getVelX() != 20){
				Game.snake.setX(-20);
				Game.snake.setY(0);
			}
		}
		//Other controls
		if (pressedKey == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}
	
	public void keyReleased(KeyEvent e) {
	}
	
	public void keyTyped(KeyEvent e) {
		
	}

}
