# Game Basic Information #

## Summary ##

The Ocean is a puzzle platformer set in a future where robots perform all of society’s labor. Human society has grown complacent and decadent by retreating into virtual worlds of luxury. Play as Jacob Richter, an opponent of this decay seeking to free his brother and all of humanity by infiltrating the underwater base housing the servers and freeing humanity from its virtual shackles. Take control of Jacob’s submarine and harness Jacob’s unique ability to swap himself between realities to reach the center of the base and liberate humanity from its virtual delirium!


## Gameplay explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**

**Features Summary**

*Undersea Exploration:* Brave the dangers of the shadowy depths as you search for a way into the enemy base at the bottom of the ocean!
*Spatial Reasoning:* Give your parietal lobe a workout as you keep track of the two alternate versions of each level!
*Parallel World-based Platforming Puzzles:* Sprint, jump, and switch your way past all the hazards to reach the core of the base!

**Controls**

The player traverses around the level using the W, A, and D keys. The W and D keys control left and right movements, and the A key is used for jumping. 
The X button will be used to control the gravity gun. Pressing X will first pick up and object, and pressing it again will drop the object.

**Switching Realities**

![WorldA](https://cdn.discordapp.com/attachments/156926535356514304/654156482157215747/unknown.png)
![WorldB](https://cdn.discordapp.com/attachments/156926535356514304/654156689104175106/unknown.png)

Some tiles in the level are part of World A, some are part of world B. Some are part of both. The tiles that are part of both worlds will be glowing. 
See the state change table below:

| World Player Is Currently In | What Happens When "Change World" Ability Is Activated                                                               |
|------------------------------|---------------------------------------------------------------------------------------------------------------------|
| A                            | Anything that is in World A AND not in World B is hidden from view, becomes silent, and stops affecting the player. |
| B                            | Anything that is in World B AND not in World A is hidden from view, becomes silent, and stops affecting the player  |

**Gravity Gun**

![GravityGun](https://cdn.discordapp.com/attachments/156926535356514304/654056375025926165/GloveShooting.png)

This will be a pickup. Once the player picks it up, it disappears from the screen and the player gains a new ability. To activate it, press Fire2 and you will be able to grab a crate (or other player-sized object) and move it around. Using “Change World” while you are grabbing a crate brings the crate with you to the other world. If you grab a crate that is above ground level (stacked on another crate), you will hover next to the crate, in midair, and will not be able to move left or right. This is because your legs will be dangling five feet off the ground. Suppose you move left while you have a crate grabbed on your right. You will continue facing right, and the crate will stay to the right of you. It’s just like dragging a heavy object. You can jump while holding a crate, and it moves upwards with you. You cannot grab onto a wall tile, even though a single tile is the size of a crate.

**Buttons**

![ButtonUnpressed](https://cdn.discordapp.com/attachments/156926535356514304/654056711992115220/WorldBFloorButtonUnpressed.png)
![ButtonPressed](https://cdn.discordapp.com/attachments/156926535356514304/654058520102043668/WorldAFloorButtonPressed.png)

Every red button is linked to one latchbox on the ceiling. There is only one of each per level, per World. When the button is pressed, the latchbox opens and drops its contents.

**Boxes**

![BrownBox](https://cdn.discordapp.com/attachments/156926535356514304/654055835961393172/Box.png)
![GreyBox](https://cdn.discordapp.com/attachments/156926535356514304/654058940811968513/SilverBox.png)

The size of one tile, which should be the same as the size of the player character. Can be moved by player if they have the gravity gun. If it falls on the player, it will kill them.

**Spikes**

![Spikes](https://cdn.discordapp.com/attachments/156926535356514304/654058058070229002/Grey_Spikes.png)

Spikes stick up out of the ground, or down from of the ceiling. One set of spikes takes up the width of a tile. Colliding with one from the pointy end kills the player

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface

**Describe your user interface and how it relates to gameplay. This can be done via the template.**

**Title Screen** : The title screen consists of three buttons and a background image. We implemented a [SceneSwitch](https://github.com/libben/the-ocean/blob/1d995eae9d50da6eb35afd6c4b814f74d8cebcbf/Ocean/Assets/Scripts/SceneSwitch.cs#L1) script that is attached to the buttons, with each button leading to its appropriate scene. The "New Game" button leads you to the "PregameScroll" scene which gives the player a bit of backstory to the game. Pressing any button from that scene will lead the player to the scene, "Arc 1", where the player can start playing the game. The "Credits" button will lead to the "Credits" scene. In the "Credits" scene, we listed all of our team members and their roles, as well as the assets and other tutorials we uesd for the project. To achieve the scrolling effect, we recorded an animation using the animator system in Unity. 

**Dialogue Box** :

![DialogueBox](https://cdn.discordapp.com/attachments/156926535356514304/653814216452603934/unknown.png)

The dialogue box consists of the character's picture and the text they are saying. It is controlled through a [DialogueController](https://github.com/libben/the-ocean/blob/66aacc4f3c25e676e954b238f7abf0be0e6bb5a5/Ocean/Assets/Scripts/DialogueController.cs#L1) script. It's primary goal is to hold the actualy dialogue box assets and the characters' dialogue. The script checks which arc the player is currently in and keeps an index of the current line of dialogue in order to display the correct lines to the player.




## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

In *The Ocean*, there are two theaters of gameplay: outside the base where the player rides a submarine, and inside the base where the player directly controls Jacob. These two very different environments required two very different models of physics in the game.

Outside the base, Jacob's submarine uses a [rotation-based, tank-style movement](https://github.com/libben/the-ocean/blob/master/Ocean/Assets/Scripts/PlayerTopDownMovement.cs) where the player's horizontal inputs turn the sub and hitting W accelerates the sub in the direction it's facing. As the whole area is deep under the ocean, we wanted the submarine's motion to feel weighty, with a lot of inertia to simulate the difficulty of moving underwater.

Within the relative safety of the base, Jacob is able to disembark from the sub and move in a more traditional platformer style. Here, the main obstacles are no longer the darkness and the robotic sentry, but spikes, buttons, boxes, and of course walls. After hearing about the sheer size of dedicated physics code bases in games like *Celeste* (5400+ lines!!!), we opted to take advantage of Unity's built-in 2D physics systems. Each object in the game has an attached collider and rigid body, through which Unity's universal physics can take care of the basics like gravity and collision. Taking inspiration from the [2D Platformer Training presentation](https://www.youtube.com/watch?v=j29NgzV8Dw4) from Unite Berlin 2018, we had the player's horizontal inputs add velocity to Jacob's rigid body horizontally. Pressing the jump key adds an upward force to the player independently of the horizontal inputs, and doing a longer press of the jump key leads to a higher jump. This way, the player can control how high they travel vertically, allowing for more precise jumps. 

However, the player character's motion was not the main focus of the gameplay. Rather, we chose to focus on providing the tools the player would need to rely on to advance through the puzzles inside the base. These are the **world switch** and the **gravity gun** (though it's less of a gun and more of a glove).

[World switching](https://github.com/libben/the-ocean/blob/master/Ocean/Assets/Scripts/WorldsController.cs) was one of the core ideas of our game and part of what we think makes our game unique. Jacob can transport himself between two different realities in a flash, though this of course has its limitations. The key supporting pillars of this gameplay dynamic are layers and the [Collision Matrix](https://github.com/libben/the-ocean/blob/eadd4c7de5cc00847adedbe95daac002b129be10/Ocean/ProjectSettings/Physics2DSettings.asset#L56) in the Unity Physics 2D project settings. (Note: it does not look nearly as impressive on Github as it does in the Unity editor.) By changing the values in this matrix, we could enable and disable collisions between objects on any two given layers. For example, we had two layers dedicated solely for the player, `PlayerW1` and `PlayerW2`. By default, the player is in world 1 and shouldn't be blocked by walls in world 2, so we disabled collision between `PlayerW1` and `Platforms2`, the layer we used for the walls and floor of world 2. 

One of the biggest challenges was figuring out how to prevent Jacob from switching from an open space in the first world into a wall in the second world and breaking the game. For this, we had to create a dedicated function, `CollidingInOtherWorld()`, to see if the player should be allowed to switch in the first place. Though I initially attempted to use the `Collider.IsTouchingLayers()` method, this didn't turn out to work well, so instead I opted to place game objects with colliders delineating where the player is not allowed to switch. When the player's position is inside one of these colliders, the switch is blocked. This also allowed us to neatly show the player which wall or other solid object was stopping the player from switching by having the blocking object briefly appear in red. These overlap markers are visible in the scene before running the game, but all have their `SpriteRenderer`s turned off in `WorldsController.cs`. (The player can also switch worlds outside the base, but this leads them into a very dangerous version of the ocean, so they are forced to switch back after a short period.)

- [The gravity gun](https://github.com/libben/the-ocean/blob/eadd4c7de5cc00847adedbe95daac002b129be10/Ocean/Assets/Scripts/PlayerController.cs#L254) was the only equipment upgrade we had planned that survived to the final cut of the game, and a great source of physics-based entertainment. With this tool, Jacob can grab boxes and move them around the levels, enabling him to open new paths deeper into the base. Boxes that used to serve only as obstacles and falling hazards are now usable as stepping stones to jump a bit higher, for example. Just like world switching, this mechanic implementation had a lot of challenges regarding physics. Though it seems as simple as moving the box's transform to keep it in the same position relative to the player, it was actually more complicated. For example, jumping and having the box be blocked by a ceiling while the player isn't should have had the box-player combo stop moving upward. However, without any guards, the player would continue ascending and the box would get dragged inside the ceiling, which was clearly bad. We came up with two approaches to solve this: disabling the box's collider and expanding the player's to encompass the box, and keeping both colliders active but having checks to stop the box from always blindly being moved. Each solution had its own issues, but we decided to go with the second one as it had fewer truly catastrophic game-breaking bugs and worked more generally.

## Animation and Visuals

**List assets**

[Underwater background scene](https://assetstore.unity.com/packages/2d/textures-materials/water/underwater-fantasy-87457) - From Unity Asset Store

[Steampunk Tileset](https://opengameart.org/content/steampunk-level-tileset-mega-pack-level-tileset-16x16); CC-BY 3.0 - Author: KnoblePersona

[Pixel Tiles](https://opengameart.org/content/kenney-16x16); CC0 license- Author: Kenney and surt

[FREE 2D Hand Painted-Background](https://assetstore.unity.com/packages/2d/environments/free-2d-hand-painted-background-110959?fbclid=IwAR3jflg1sO-lnLxg9tVxfw7gZiPYqxJBbo5A67UhBW3xjXI0mNpCXOETYhM) - From Unity Asset Store

[Glow Effect](https://github.com/Elringus/SpriteGlow); MIT license - Author: Elringus

Attempting to make the visuals of our game appealing, we first found the appropriate art for the background. We got the underwater background scene and free 2D hand painted-backgrounds from the Unity asset store. In addition, we found a steampunk tileset and pixel tiles from online; these components allowed us to make platforms and components in the game.

For the rest of the animations, they were all drawn from Adobe Photoshop or from GIMP. The things that were originally created include:

  1) Jacob, our main character
  2) Our main enemy, the older man
  3) Base defender, electric eel
  4) Jacob's brother (in an astronaut suit)
  5) bronze and silver hatch and lid
  6) bronze and silver spike
  7) metal and wooden boxes
  8) gravity gun
  9) submarine porthole
  10) submarine
  11) 2 different torches
  12) World A/B floor button
  13) World A/B Box Dispenser
  14) Title Screen
  15) Cover Page
  16) Ending scene (WIN!)

Art Direction
For building our game world, we used DND storytelling skills to fabricate our story. Inspiration came from a game called The Desolate Hope, where a character flees into a virtual world to escape, and the book Ready Player One. A key idea that lead to our setting was what humans would do when it becomes harder to do something meaningful with their lives. As for the puzzles, Portal was a large inspiration.

We had our protagonist in an old-fashioned diving suit, since he will be arriving to the compound by submarine.
The main antagonist believes that a digital world that can be protected on servers is “more real” or better than the outside world, where everything decays. The villain presents himself to the player as a man with class.
There are two main settings of the game, one which is "outside" and underwater, and the other is Arc 1 and Arc 2 which is "inside" as the player makes their way deeper into the base.

For characters with motions, including our main character Jacob and the electric eel, the animation was made through adobe and each "moving part" of the character was drawn on a separate layer. By drawing them on different layers, when uploading them onto Unity, each body part was able to have its own movement. By giving animations, it definitely added game feel.

In addition to animating the characters, we would draw a scene on paper, along with each component and each functionality; this allowed us to see what needs to interact with what. Because of our careful design plan, what seemed like hard tasks turned out to be manageable. After the design from photoshop, Unity can split up those body parts. From there, searching Unity documents, we learned that we can attach bones to the sprites. For human character movements, by referencing real human bone movements, we were able to fine tuned the character's body motions. Using this aspect the animator tool in Unity, we were able to enhance the graphic design. The characters have sprites displaying transitions of the movements. With all these design elements, it allowed the components of the game to come together.

When the character is outside the base, the goal is to get to the latches in order to go inside and escape from the electronic eel. If the character is  near the latches, the eel will start chasing and will always be faster, meaning the character can never outrun it. This warns the player to get inside as fast as possible (giving the player an intense and nerve-racking feeling, adding game feel)!

There were several things that we wanted to add to the animations and visuals to add game juice to our game; however, because of the time constraint, some were unable to be implemented. With more time we would have added things like shaking effects (when the eel comes in contact with the character) and particle effects.

We used all the skills we learned from class and applied everything we gained from the exercises to tie the visuals and animations together and define our own style for our game.  


## Input

**Describe the default input configuration.**

#### Controllers

#### TopDownMovement
[PlayerTopDownMovement.cs](https://github.com/libben/the-ocean/blob/24e933d6c9ca1aad83f648cd772b27f46d770f8c/Ocean/Assets/Scripts/PlayerTopDownMovement.cs#L7) was used to control the player when they are in the submarine. This includes the execute commands when a key is pressed. 

#### Puzzle Level Scripts

Used [PlayerInput.cs](https://github.com/libben/the-ocean/blob/24e933d6c9ca1aad83f648cd772b27f46d770f8c/Ocean/Assets/Scripts/PlayerInput.cs#L8) and [PlayerController.cs](https://github.com/libben/the-ocean/blob/24e933d6c9ca1aad83f648cd772b27f46d770f8c/Ocean/Assets/Scripts/PlayerController.cs#L8). PlayerInput.cs labeled out the keys used to move the player while PlayerController.cs dealt with the physics system of the player. 

For this project we had two different types of input for our character. 

#### Puzzle Levels

When solving puzzles, we used the arrow keys and WASD keys to move our player. 

* Up arrow and W where used to jump

* Right arrow and D where used to move the character right

* Left arrow and a A were used to move the player left
* Z key was used to change worlds
* X key was used to use the gravity gun

#### Ocean Level

On the other hand we had different inputs when the player is moving in their submarine. For the submarine controls, we wanted to use a top down controls so the user can explore the whole map. Once again we decided to use the arrow keys and WASD keys. 

* Up arrow and W were used to move the submarine forward in the direction that it is facing 
* Right arrow and D key were used to rotate the submarine in a clockwise direction 
* Left arrow and A key were used to rotate the submarine in the counter clockwise direction
* Z key was used to change worlds

#### Main Menu

For the main menu the player can press the new game button to start the game or the credits button to view the credits of the game. 

#### Navigating through text

We used the 'E' key to navigate the player through text boxes when they appear. 

**Add an entry for each platform or input style your project supports.**
Our game currently supports unity games on a Windows, Linux, or Mac machine. Our project can only support keyboard commands. If we had more time, we thought about moving the controls to a PS4 controller or some other handheld controller. 

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**
*World-Switching* - We managed the "world"/universe that the player and each object (box, button, etc) were in. When the player tries to swap worlds, we check whether something at Jacob's position in the other world. If so, we forbid the world-swap. This relates to our mechanics lecture and discussion of the "core" of a game: this, along with movement and jumping, form our core, and it was carefully chosen after testing and abandoning a grappling hook as the player's fundamental tool. [The line that cancels world swapping](https://github.com/libben/the-ocean/blob/b3ba1617428d7c9f0c52d4a9669ca3e3c1935976/Ocean/Assets/Scripts/WorldsController.cs#L78)

*Resetting a Level* - The player can die or force a reset of the current level. We tracked objects' positions and layers when the player starts the level, to reset them later. Layers need to be saved because the player can bring a box to a different world (represented in Unity as a layer). This relates to our class discussion of mechanics: we want the player to be able to finish our game; adding a reset mechanic fixes unsolvable game states such as certain box stacking configurations. [This script was attached to game objects that were containers for boxes; it saves its children's positions and layers](https://github.com/libben/the-ocean/blob/3cc76c55c0a739d330044940dff66d3cb80848aa/Ocean/Assets/Scripts/Level.cs#L36)

*Movement with Box* - While holding a box, a player is allowed to move if and only if Jacob's feet are touching the ground, the box is not blocked, and there is not another box stacked on the held box. We tracked these things with the aid of colliders. This relates to our class discussion of physics systems, as we are making use of Unity's. [GravityGunControl](https://github.com/libben/the-ocean/blob/b3ba1617428d7c9f0c52d4a9669ca3e3c1935976/Ocean/Assets/Scripts/PlayerController.cs#L254)

*Current Level* - Every time a player moves 16 tiles left or right, we consider them to be in a new room/level/puzzle. Several scripts needed to know when a player changed levels: the DialgoueController, the PlayerController, et cetera. We used a notification system - akin to a lightweight, hardcoded PubSub - to inform scripts what level a player was on. Our camera was even subscribed to this script; it is how the camera knows when to change its position. This relates to Exercise 3. [The notification function](https://github.com/libben/the-ocean/blob/b3ba1617428d7c9f0c52d4a9669ca3e3c1935976/Ocean/Assets/Scripts/LevelController.cs#L47)

*Post-dialogue events* - After pressing yellow buttons, the AI talks to Jacob. As soon as the player is done reading dialogue, we need the scene to change to OceanBase again. We implemented this with callbacks: Our ShowDialogue() function took a lambda as a parameter. ShowDialogue() ran this lambda after all dialogue had been shown. [ShowDialogue](https://github.com/libben/the-ocean/blob/b3ba1617428d7c9f0c52d4a9669ca3e3c1935976/Ocean/Assets/Scripts/DialogueController.cs#L181)

*Time scene visited* - The player returns to the game's undersea area several times, appearing in a different position each time. We wanted to reuse the underwater Scene in Unity. To do this, while changing the player's position each time they visit the Scene, we created a static int field to track how many scenes we had visited in the current play session. 1 indicated it was our first time on this scene, 3 our second, and so on. [The counter](https://github.com/libben/the-ocean/blob/b3ba1617428d7c9f0c52d4a9669ca3e3c1935976/Ocean/Assets/Scripts/SceneCounter.cs#L6)

# Sub-Roles

## Audio

**List your assets including their sources and licenses.**
[Switch Game World](https://freesound.org/people/InspectorJ/sounds/403006/#); CC0 license - Author: InspectorJ

[Game-Over](https://freesound.org/people/myfox14/sounds/382310/); CC0 license - Author: myfox14

[Gun](https://freesound.org/people/kretopi/sounds/406754/) ; CC0 license - Author: kretopi

[Continue Dialogue](https://freesound.org/people/harrietniamh/sounds/415083/) ; CC-by 3.0 - Author: harrietniamh

[Title Screen Song](https://github.com/libben/the-ocean/blob/master/Ocean/Assets/Sounds/Project%202%20-%20for%20title%20screen.wav) ; Author - Ben Rausch

[GamePlay Song](https://github.com/libben/the-ocean/blob/master/Ocean/Assets/Sounds/Project%202%20Companion%20Track.ogg) ; Author - Ben Rausch

[Credits Song](https://github.com/libben/the-ocean/blob/master/Ocean/Assets/Sounds/Morning_Mood_by_Grieg.mp3); Author - Edvard Grieg

**Describe the implementation of your audio system.**
For the audio effects of the game, including the switch game world, game-over, gun, and continue dialogue sounds,
it matches with the movements and choices of the main character (or the players actions).
By adding these sound effects to the characters movements, it adds game juice to the game.

We found all the small sound effects through freesound.org.

In adding the sounds to the game, we simply attached an Audio Source to the GameObject. In Unity, we did Add Component, Audio, and Audio Source. Then in the Audio Source slot, we added the sound effect that we downloaded. In the actual script, we added a private AudioSource source, and in the section of the code where we wanted to have the sound effect play, we included the the code source.Play(). Lastly, we un-clicked the Play on Awake button so that it didn't play the sound every time we played the game and only when it was called at the appropriate time.

**Document the sound style.**
Adding sound effects definitely enhances the overall feel of the game. For the overall GamePlay sound, we used a song produced by Ben Rausch.
This song was written to evoke the feeling of traveling through space, only to find that things are more dangerous than expected. The theme of our game is intended to give the player a tense feeling; the feeling of mystery and emptiness, being alone in the unknown. The song evolved into a dialogue between noise and tone, which matched our theme which is why we decided to make it play as the background song when the game was playing.

The song inserted for the credits scene by Edvard Grieg is on the happier side, giving a more cheerful feeling as the main character has FREED HUMANITY. The feeling of inner peace as the great burden has been lifted off his shoulder, feeling a sense of accomplish. 
 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

[Playtest Results](https://docs.google.com/spreadsheets/d/1bntlGgbuPto_3fwz1-TcayCDT3jjdzfVY4g4PuD5tOI/edit?usp=sharing)

* Overall, the feedback from our gameplay testers was that the game was very interesting and fun to play.
*  The biggest problem that most testers faced was that the controls could feel a bit awkward at times. They couldn't exactly pinpoint the reason exactly, but it might have had something to do with how the player moved through the air and certain keybinds for certain actions
  * They also mentioned that the submarine sections of the game could feel a bit disorientating and hard to navigate through
* Other than the issue of the controls, the second most reported thing was that the gravity gun could be a bit glitchy at times. There were times where performing certain actions with the gravity gun would break the level entirely and they would be unable to progress

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.**

*Dialogue boxes* - Most of our narrative is presented with text. We have pre-game and post-game information dumps onboarding the player. During gameplay, textboxes appear onscreen with character dialogue. This relates to our unit on Game Feel. We wanted the game to feel retro, and using dialog boxes emulates how story was conveyed in classic games such as Pokemon Red and Blue. [Dialgoue-showing function](https://github.com/libben/the-ocean/blob/2ea3763dfb494b4577045189933589f544b0881b/Ocean/Assets/Scripts/DialogueController.cs#L190)

*Subversion of expectations* - The metanarrative of the game is that Jacob must open hatches to find a room of servers to destroy. **spoilers ahead**: At the game's climax, the player is as shocked as Jacob is to discover that the third hatch never opened - the station AI only told Jacob that he opened it. So, the narrative of someone actively preventing you from entering their base affects gameplay. [Dialogue when the player is betrayed](https://github.com/libben/the-ocean/blob/2ea3763dfb494b4577045189933589f544b0881b/Ocean/Assets/Scripts/DialogueController.cs#L198)

*Interrupting the player* - At the beginning of the second set of puzzles, the player finds a Mars simulation instead of a puzzle. Once there, Schaden begins lecturing the player on why he should stay. Even the player's puzzles aren't safe from the narrative - the player is interrupted from what they expect. By changing the map, we linked the player's feelings to the character's: both are surprised and disoriented. This links to our Game Feel lession: in Matt Thorson's talk about Celeste's levels, he explains he also endeavored for Celeste and the player to feel the same feelings. [Big lecture from the antagonist](https://github.com/libben/the-ocean/blob/2ea3763dfb494b4577045189933589f544b0881b/Ocean/Assets/Scripts/DialogueController.cs#L96)

*Characters talking about gameplay* - The main gameplay mechanic is that Jacob can change dimensions. Schaden's dialogue interacts with this by progressing from doubt of its existence to fear of what he doesn't understand. This frames Jacob's powers as important and special, and helps the player to feel like they have an important impact on the world. So, this indirectly relates to game feel: we are using narrative to hype gameplay. [Antagonist's shocked dialogue](https://github.com/libben/the-ocean/blob/2ea3763dfb494b4577045189933589f544b0881b/Ocean/Assets/Scripts/DialogueController.cs#L127)

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**
* [Press Kit](https://docs.google.com/document/d/1aqMNFzjgkNZod29HZo7v3B7WtP1A-raiTTXSEkNnwrc/edit?usp=sharing)  
* [Trailer](https://youtu.be/5Yu68m2JVeY)  

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**

For the press kit, I mainly took inspiration on what to include from Yacht Club Games' [Shovel Knight press kit](https://yachtclubgames.com/shovel-knight-treasure-trove/). A quick fact list gives readers quick information about us and our game at a glance. I also wrote a little background information about our team and how we formed. People interested in the game would definitely like to see some art of the characters, so I included the sprites for our hero Jacob, his brother Dillon, and the villainous Schaden. The title screen background art was the closest we had to a logo, so I also included it. 

I chose to cast the trailer as a remote mission briefing from Jacob's mysterious anti-virtual-reality allies. This allowed for a more immersive way to give the viewers exposition about the background behind the game. The text-to-speech narration, a privacy measure by the message's sender, let us describe both the story and a bit of the gameplay. Of course, I definitely wanted to show both of the two main phases of gameplay, so I made sure to show footage from both the submarine and inside the base. The submarine gameplay section shows what the player can expect to see at the bottom of the ocean, and also gives sharp-eyed viewers a brief glimpse at the reason why players don't want to be outside for too long. On the other hand, the inside-base section shows some platforming action, the spike hazards common in the base, and demonstrates a bit of the air control and physics. I also made sure to include the two main mechanics that prospective players could expect to be seeing a lot of: world switching and gravity gun box grabbing. Showing a a level being cleared by switching while carrying a box was a great way to show both of these mechanics in action. However, I also wanted to avoid showing too many of the puzzle solutions and story dialogue boxes.

## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
From the art to the sounds, there were many juice items that were used to improve game feel. 

LIGHTING- For the ocean level, we purposely made the whole screen dark. The only source of light is from the submarine, the eel, and the hatches. This is used again to make the user feel a little bit scared since they are exploring a dark area. There is light around the hatches to give the user a source of hope when finding it. Since the player is in the dark, they don't know where the robotic eel is and it can only be seen when the player gets close to an opening hatch. The light on the eel's head is used to once again frighten the player when they see it for the first time. 
[Link used to learn lighting](https://www.youtube.com/watch?v=nkgGyO9VG54&t=308s)

ART- For art, we decided to go for an aesthetic art style for the ocean level. The ocean level is a slight dark blue with some coral and rocks in the background. Since the level is dark, the user can observe the beauty of it when exploring in their submarine. When the user changes world's in the ocean, they are brought to a volcanic water level. We decided to make the alternate world to be the exact opposite of the regular level. Instead of the calm and beautiful nature, we wanted to put the user in a destructive and uneasy environment. 

Since our theme was connecting the past and future, we wanted our puzzle levels to reflect that. We decided to make the normal levels of our puzzles to look more futuristic while making the altered levels a bit more steampunky. We did this so that the player realizes the connection between each world when solving puzzles. 

AUDIO- For sound we had a sound effect play whenever the player goes through text. That is use make it more engaging and fun since pressing a button and making a sound is more engaging than pressing a button and have no sound happen. We also used two soundtracks that Ben composed. For the ocean level, the music is more ominous to reinforce the creepy feeling that user should be feeling. For the puzzles levels, the music is used to make you feel secluded from the rest of the world much like how most of humanity was secluded from the real world in our game.

MOVEMENT- For movement, we had two different types of movement for the player, one when solving puzzles and one for moving in the submarine. In the submarine, the player is slow and sluggish. We wanted to simulate this as if the player was actual piloting a submarine in real life. This is also used to make the player feel more tense since they are moving in a dark area with little movement. 

For the puzzle levels, we wanted to make the movement as smoothly as possible. We made the character feel more floaty since we thought it was the best way for the player to control their character. One thing that we implemented was the ability to move in the air when jumping. We did this since we wanted to give the user as much control as possible. 
