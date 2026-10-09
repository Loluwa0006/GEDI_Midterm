Factory:

Player Entity contains the factory system due to time limitations. If I had more time, I would have moved the bubble logic to a separate script.

At start time the factory creates 5 bubbles. This are then stored into an object pool capable of holding an object of any type and returning the last used version, allowing for repeated use of the same object as many times as needed. 
Using the object pool helps to prevent bottlenecking caused by having objects constantly loaded or destroyed at runtime.
Having the object pool class helps to abstract away management of pools away from the factory implementation.

Singleton:

Score Manager is the singleton. When an enemy is defeated, it calls a function OnEnemyDefeated(), adding a value to the current score, which is then displayed to the UI. Having it as a singleton allows for a single source of truth when it comes to requesting for the current score, or for the score to be updated. 


Polymorphism:

The game utilizes a state machine and state system. Each state inherits from a class called Base State, with a virtual function for updates, physics updates, as well as entering and exiting the state.

Player states inherit from a class called Player Base State, with additional functionality for checking if the player is grounded, as well as a variable that allows the state to treat its owner as a PlayerEntity specifically, and not just a generic entity, allowing for requesting input changes.

This allows only player states to have the ability to access input, helping to keep the game scripts coherent by making sure only the states that need input have access to it.

Enclaspulation:

No state is directly tied to each other. Rather then referencing a specific object, the states request for a change to a state of a specific name. If I had more time, I would have added a guard that prevented requests to states that didn't exist in the lookup from throwing errors. Additionally, I would have used a type for transitioning instead of a name, since that would allow for autocomplete, and prevent less human error.

States don't talk to each other because if they did it would create more coupling, preventing s

Extendablity:

Since all states override functions for their functionality, the state machine is capable of working with anything that inherits from BaseState.

Additionally, the object pool class is capable of taking an object of any type.

Abstraction:

Rather then having direct access to the Player Input Component, states access input via an Input Manager wrapper. This helps to make the code more readable by making it clear what input the code is asking for, as well as creating centralized logic that all scripts use, so there is less duplication and thus less human error possible in input reading.

I did not make it a singleton because I assumed any state that would require access to the input reader would require access to the player, so if the input reader had a public getter, then I could simply just pass the Player and the state could grab whatever it needed from the player including input.


