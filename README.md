# Left Field Labs: Unity Engineer Take Home

## Pumpkin Shooter

## ChangeLog:
- Removed the unnecessary Update() method from MainMenu.cs since it is being called every frame and it does nothing.
- Removed unnecessary class Cannonball.cs since it’s attached to a prefab and it’s only consuming resources when calling the Start() and Update() method.
- Switched to CompareTag since it's faster than having a script with empty methods, and it's 5x faster than the C# .Equals() method.
- Added DataToUpload.cs class that sets and gets the data in/from a JSON file to be manipulated.
- Instead of bringing the Data from the PlayerPrefs, we bring it from a JSON file that can be edited later by the design/backend team.
- Separated the MainMenu into two canvases, one with the static elements and one for the dynamic elements, thus preventing the dirtying up of the canvas.
- Refactored code to make the scripts more readable, reuse code instead of having the same operation more than once and with less lines of code to avoid cluttering.
- Created a Score Manager.
- Added an input field to put your name when you surpass the current high score.
- We added the option to put your name to display  in the main menu if your score is greater than the current high score.
- Added an object pool to manage Enemies and Cannon balls.

