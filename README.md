# unity-breakout-clone
A breakout clone demo project in unity

![Screenshot](https://github.com/sinamhdn/unity-breakout-clone/assets/34884156/196a01f3-fd0c-4a2f-a411-28ae156aca74)

## Unity Version
2022.3.2f1 LTS

## Assets Used
Font are from https://www.dafont.com/ 

## Concepts Used
- Import and Export the projects as unitypackage
- Calculate asset sizes and pixel per units based on the unity units
- Rigidbody to apply physics rules to the game object
- Constraint rotation on the rigidbody
- Loading scenes with string references
- Converting mouse position to world units
- Mathf.Clamp to limit position change
- Changing script execution order
- Changing gravity scale on rigidbody
- Changing world gravity of the project
- Prefabs
- Grid Snapping (hold ctrl)
- Pysics material 2d to add friction and bounciness
- Play audio on the game object
- Play audio on the specified point on the scene
- Text Mesh Pro
- Singleton pattern
- Spawn particle effect
- Destroy game object
- Tags to mark game objects in a specific type
- changing sprite of a sprite renderer component from script

## Important Notes
**CHECK "Is Autoplay" ON SESSION.CS TO MAKE THE GAME PLAY ITSELF**
**ADD SCENES TO BUILD SETTINGS IN THIS ORDER "Start Menu" > "Levels" > "Game Over"**
