# WordBoggle
For the Word Boggle game, I adopted the Model-View-Controller (MVC) architectural pattern, with a strong emphasis on modularity and the Single Responsibility Principle. Each component—Controller, Model, and View—has a clearly defined role, making the architecture clean, scalable, and easy to extend for additional game modes in the future. My primary focus for this project was on designing a robust and maintainable architecture rather than the UI or animations.

GameManager
The GameManager serves as the entry point of the game. It utilizes the Factory Pattern to instantiate the appropriate GameplayController based on the selected game mode. It also handles the injection of views and the InputManager into the controller.

InputManager
The InputManager abstracts player interactions, handling both mouse and mobile touch inputs. It ensures that the GameplayController remains platform-agnostic by only communicating relevant world positions, thereby simplifying the controller’s responsibilities.

GameplayController
Following the MVC architecture, the GameplayController is responsible for updating both the model and the views. Views are solely responsible for visual updates and remain unaware of the underlying data, while models encapsulate all game-related logic. This separation of concerns results in a clean and maintainable codebase.

Game Modes
To support multiple game modes, I created:

EndlessModeGameplayController and LevelModeGameplayController

EndlessGridModel and LevelGridModel

EndlessGameModel and LevelGameModel

These classes are designed using solid OOP principles, encapsulating logic specific to each mode while maintaining a consistent architecture.

Progress Summary
I successfully implemented the Endless Mode with complete functionality. Due to the 6–8 hour time constraint, I wasn’t able to fully implement the Level Mode objectives and the optional bonus features. However, the architectural groundwork for Level Mode is in place, and extending the system would now be straightforward.

Given more time, I would have completed the Level Mode objectives, added the bonus functionality, and refined the user interface to enhance the overall polish of the game.
