# DesignPatternsAssignment

Name: Daniel Turunen Eserberg
About game: It's not really a game but rather a collection of systems.

Pattern: Singleton: in PlayerProfile and inventory scripts. Used the singleton to make one instance that holds player data like health and mana and two other static singletons to make the potions that are held in the inventory. I currently don't need more than one instance of each to keep track of if I can use the potions or not and wether the players health or mana changes at any point.

Pattern: Observer: Used in the UIWithDelegates script. in the UiWithDelegates class , ItemCollisions script, in the ItemCollisions class and StatemachineMovement script, in Update in the GetKeyDown Q and E button press checks. I used it to keep track of wether my potion amount(health or mana potions) or if my health or mana change at any point. I also use the observer pattern to update the UI.

Pattern: Dirty flag: Used in the PlayerMovement script, in the player movement class and in the Update method.

Pattern: Builder: Used in the PotionBuilder script in the PotionBuilder class(I think).

Pattern: Factory: used in the PotionFactory script in the potion factory class.

Pattern: Object Pool: used in the ParticleObjectPool script in the ParticleObjectPool class.

Pattern: State machine/Concurrent state machine: Used in the StateMachineMovement script, in the StateMachineMovement class, in Update, OnCollisionEnter and OnCollisionExit methods.
