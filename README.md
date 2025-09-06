**Space Explorer**

**#Link Demo**: https://play.unity.com/en/games/13e46027-e1f3-40e0-8bc6-2c92635c1225/space-explorer-hoanpche170404
**#Link report**: https://docs.google.com/document/d/1lTLj6kOsmpqhUjJdxCIrITWwEyc8bD6YMp_ueJSLMKw/edit?usp=sharing


Overview
Space Explorer is a 2D game developed in Unity as part of the PRU212 course (Lab 1) to reinforce concepts such as Unity Interface, Navigation, Basic Game Object Manipulation, Transformations, Unity's Component System, Scene Creation and Management, and Introduction to Physics and Colliders. The game challenges players to pilot a spaceship through a dangerous asteroid field, avoiding collisions while collecting hearts to maintain health and earn points.
Game Concept
In Space Explorer, players control a spaceship navigating through space, dodging asteroids and collecting hearts dropped by defeated enemies to increase health. The game features multiple scenes (Main Menu, Gameplay, and End Game) and dynamic difficulty scaling based on the player's score.
Features

Gameplay:
Player Controls: Move the spaceship in all directions using arrow keys and shoot lasers with the Spacebar.
Asteroids: Randomly spawn and move across the screen. Colliding with an asteroid deducts 1 health point.
Hearts: Dropped by defeated asteroids, collecting hearts increases health by 1 (max 5 health points).
Dynamic Difficulty: Asteroid spawn speed increases, and player damage and speed scale up at score thresholds (10, 20, 30, or 40+).
Scoring: Earn points by defeating asteroids.


UI Design:
Main Menu: Includes Play, Instructions, and Exit buttons.
Gameplay UI: Displays score, health, and developer information.
End Game Screen: Shows final score with options to replay or return to the Main Menu.


Scene Transitions: Smooth transitions between Main Menu, Gameplay, and End Game scenes.
Physics and Colliders: Uses Unity’s physics engine for realistic asteroid movement and collision detection.
Assets:
Sprites: 2D Space Kit.
Audio: Sourced from AudioJungle.



Team
Developed by:

Phạm Công Hoan (HE170404)

Installation

Clone the repository:git clone [insert repository URL]


Open the project in Unity (version 2021.3 or later recommended, please confirm specific version if known).
Import required assets from the 2D Space Kit.
Build and run the game from the Unity Editor.

Requirements

Unity Editor: Version 2021.3 or later (please confirm).
Operating System: Windows, macOS, or Linux (compatible with Unity Editor).
Hardware: Standard PC capable of running Unity Editor and 2D games.

How to Play

Controls:
Move: Arrow keys.
Shoot: Spacebar.
<img width="1470" height="772" alt="image" src="https://github.com/user-attachments/assets/e8694cc7-268e-4d5e-b853-6ae2a090bc91" />
<img width="1460" height="771" alt="image" src="https://github.com/user-attachments/assets/362fc058-1213-4858-bd74-f3070799f5ed" />


Objective: Navigate the spaceship to avoid asteroids, shoot enemies to earn points, and collect hearts to increase health (max 5). The game ends when health reaches 0.
Game Flow:
Start from the Main Menu by clicking Play.
Survive in the Gameplay scene by avoiding asteroids and collecting hearts.
View final score in the End Game scene and choose to replay or return to the Main Menu.



Testing
The game has been tested with the following scenarios, all of which passed:

Player movement using arrow keys.
Shooting bullets with the Spacebar.
Health deduction on asteroid collision.
Health increase on collecting hearts.
Game over when health reaches 0.
Replay functionality to restart the game.

Project Status
This project is a completed prototype for Lab 1 of the PRU212 course, demonstrating core Unity concepts and 2D game mechanics.
Contributing
Contributions are welcome! Fork the repository, make changes, and submit a pull request. Ensure code adheres to the project’s coding standards.
License
This project is unlicensed. Contact the developer for permission to use or modify.
Contact
For questions or feedback, reach out via [insert contact method, e.g., GitHub issues or email].
References

Sprites: 2D Space Kit.
Audio: AudioJungle Game Sounds.
Tutorials: [YouTube Playlist](*please provide specific link if available*).
