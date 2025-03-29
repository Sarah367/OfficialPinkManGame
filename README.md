# Pink Man
**Source code can be found in Assets/Scripts**

![image](https://github.com/user-attachments/assets/fd180373-9734-4a37-8cca-c153b45ee1a6)

Pink Man is an engaging 2D game in which players navigate through eight main levels filled with various obstacles, traps, collectibles, and enemies. The main goal is to save the princess in order to win the game successfully. Players will play as a character in a pink suit - or “Pink Man” - as they traverse throughout the game. The player is allowed to use their keyboard’s arrow keys to navigate throughout the game levels. They can also use the spacebar to jump over obstacles and continue further into each level. The goal of this game is to complete all eight levels as well as collect 30 oranges, 30 kiwis, 30 strawberries, and all four of the princess’s precious items in order to finally save the princess and win the game!
![Screenshot 2025-03-28 220305](https://github.com/user-attachments/assets/661d942b-1f3e-4c66-952b-b4fc47341d1c)
![Screenshot 2025-03-28 220853](https://github.com/user-attachments/assets/5ff18b09-444c-4099-a1ae-4c8f8edaf686)
![Screenshot 2025-03-28 221018](https://github.com/user-attachments/assets/5dacd43e-7287-49e6-9111-0de8b4e1a0a8)
![Screenshot 2025-03-28 221235](https://github.com/user-attachments/assets/8419ab75-1621-4455-9103-457a142ff73f)

## Features
  - 8 playable levels with smooth game mechanics and increasing difficulty.
  - Collectibles and level progression.
  - Pause menu and sound effects.
  - Engaging obstacles such as spikes, moving platforms, and enemies.
  - 2D side scroller
    
## Project Structure
  - Assets/Scripts : All game logic and behavior scripts
  - Assets/Scenes : Main game levels and UI scenes
  - Assets/Prefabs : Reusable game objects (Enemies, traps, etc.)
  - Assets/Animations : Contains animation controllers and clips for key gameplay elements such as player movement.
  - Assets/Sprites : Holds all of the 2D art assets used throughout the game.

## Development Guide 
  ★ All sprites, sound effects, animations, prefabs, and much more can be found at the Unity Asset Store. ★
### Adding a new enemy type
  - Create/import a new enemy sprite into Assets/Sprites/.
  - Slice the sprite in the Sprite Editor if it's a sprite sheet.
  - Create a new prefab by dragging the enemy sprite into the desired scene.
  - Add a **Rigidbody2D** and a **BoxCollider2D** for basic enemy mechanics.
    - Rigidbody2D: Allows the enemy to respond to physics forces such as gravity and velocity. It is needed for collision       
      detection.
    - BoxCollider2D: Defines rectangle-shaped hitbox around object; allows collisions to be detected.
  - Create a new script and include enemy behavior/movement logic.
  - If you want to reuse the enemy throughout different scenes, make the enemy a **prefab**.
    - Drag the enemy into Assets/Prefabs.
    - You can now drag the prefab into any scene you like.
### Adding a new level
  - Go to File in the top left corner and click "New Scene."
  - Open the new scene and design your preferred layout via Tilemaps, objects, and prefabs.
  - Add desired characters and enemies, as well as scripts to manipulate behavior/movement.
  - Add the new scene to Build Settings by clicking on **File --> Build Settings --> Add Open Scenes**.
### Adding a new item
  - Import your new item into Assets/Sprites.
  - Drag the sprite into your desired scene in order to create it as a GameObject.
  - Implement scripts (if needed) that define the item's purpose.
  - Remember to add Collider Components such as a Collider2D. 
## Feature Ideas
  - Implement a diverse set of enemies and new characters.
  - More engaging graphical elements such as an animated background.
  - Soundtrack integration and improved audio mechanics.
  - Add Mobile/Touchscreen compatibility.
  - Design levels that reward smart/strategic movement and punish rushing through.
  - Introduce new mechanics such as limited health.
  - Build a shop that allows the player to buy powerups and other resources.



 



