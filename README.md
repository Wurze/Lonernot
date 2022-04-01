# Lonernot
2D game made in UWP using MonoGame Framework

## How to run

- Clone the repository and open it in `Visual Studio Code`
- If not installed, download `MonoGame Framework 3.8.0` for vsc
- Rebuild the assets using the `MonoGame Pipeline`
- Launch the game
- Enjoy!

## Description
Lonernot is a single player top-down 2D oriented game in which the main goal would be to escape from the labyrinth. The game has have a main hero multiple monsters which will constantly follow the hero. The movement of the player will be possible using W, A, S, D. In order to escape from the labyrinth, the players need to find the exit point. Both starts point and exit points would be predefined. The player will start from a specific chosen location and the monsters will spawn in the same location after every 10 seconds with a different speed. This will give the player the opportunity to move into the labyrinth before the monsters’ spawns. The monsters will constantly focus on following the player for the whole duration of the game. If the monsters gets too close to the player, the game is over and the monsters wins. In order to win the game, the player needs to find the exit before the monsters catches up with him.

## Threading

Asynchronous Task
- For loading and playing sounds and music

Thread Synchronization (Semaphore)
- To control the number of monsters that can exist at the same time.

Thread Synchronization (CountDownEvent)
- The monster will make use of CountDownEvent to signal the method of creating the monster.

Background thread
- We are using background threads to load assests on the user interface

## UML 
![LonernotUMLv 1 1](https://user-images.githubusercontent.com/47572770/161275669-3bb8927c-3937-4f31-84cf-2437bdfd7827.png)
