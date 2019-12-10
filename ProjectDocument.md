# Game Basic Information #

## Summary ##

**A paragraph-length pitch for your game.**

## Gameplay explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**




# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface

**Describe your user interface and how it relates to gameplay. This can be done via the template.**

*Title Screen* - The title screen consists of three buttons and a background image. I implemented a [SceneSwitch](https://github.com/libben/the-ocean/blob/1d995eae9d50da6eb35afd6c4b814f74d8cebcbf/Ocean/Assets/Scripts/SceneSwitch.cs#L1) script that is attached to the buttons, with each button leading to its appropriate scene. The "New Game" button leads you to the "PregameScroll" scene which gives the player a bit of backstory to the game. Pressing any button from that scene will lead the player to the scene, "Arc 1", where the player can start playing the game. The "Credits" button will lead to the "Credits" scene. In the "Credits" scene, I listed all of our team members and their roles, as well as the assets and other tutorials we uesd for the project. To achieve the scrolling effect, I recorded an animation using the animator system in Unity. 

*Dialogue Box* - 

![DialogueBox](https://cdn.discordapp.com/attachments/156926535356514304/653814216452603934/unknown.png)

The dialogue box consists of the character's picture and the text they are saying. It is controlled through a [DialogueController](https://github.com/libben/the-ocean/blob/1d995eae9d50da6eb35afd6c4b814f74d8cebcbf/Ocean/Assets/Scripts/DialogueController.cs#L1) script. It's primary goal is to hold the actualy dialogue box assets. The text that the characters will be saying comes from the [DialogueHolder](https://github.com/libben/the-ocean/blob/1d995eae9d50da6eb35afd6c4b814f74d8cebcbf/Ocean/Assets/Scripts/DialogueHolder.cs#L1) script. The DialogueHolder script will be triggered when the player collides with a trigger.




## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals

**List your assets including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio

**List your assets including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
