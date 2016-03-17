# GameManager class
 This class manages the functions needed for scoring and for transitioning through levels.

## Void Start()
 Initializes all references.

## Void Update()
 Keeps time for the stopwatch.

## Public void MainMenuToLevelOne()
 Deprecated

## Public void BackToMainMenu()
 Used to transition from the End Scene back to the MainMenu scene on request.

## Public void CompleteLevel()
 Called when the player has touched the finish line trigger. It pauses all time AI, the Stopwatch, and all other things that are not necessary to the scoring of the player. It then checks to see if the player beat their high score, saves the exact time in seconds, and saves the number of deaths the player has during their playthrough of the level. The latter two are overwritten when the player finishes another level. It will then change the startGrading value to true to initilize grading process. The grading process is described in the *LevelGrading class*section of the documentation.
