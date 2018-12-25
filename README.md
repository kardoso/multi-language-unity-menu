# Multi Language Menu for Unity
This is a setup for multi language menu(and maybe simple dialogues) for unity, reading XML files.

It was made on Unity 2017.4.17f1 LTS. It may be working in more recent versions, you can try it.

[The Menu class](#The-menu-class)<br>
[The LanguageReader class](#The-LanguageReader-class)<br>
[The XML file](#The-XML-file)<br>
[The GameManager class](#The-GameManager-class)<br>
[The Language "enum"](#The-Language-enum)<br>
[The Scene](#The-scene)<br>
[Run the project](#Run-the-project)<br>
[Used resources](#Used-resources)

## The menu class
The script `Menu.cs` is the base script for menus, it's an abstract class.<br>
The classes that inherit this class must define this variables(in inspector):
* ```C#
  string axisName = "name of the axis that will control menu flow";
  ```
* ```C#
  string submitButton = "submit button name";
  ```
* ```C#
  GameObject[] availableOptions = game objects of the options availables to choose;
  ```
And must implement:
* ``` C#
  protected override void IsSelected(GameObject gameObj){
    //The behaviour of the game object when it's selected
  }
  ```
  * GameObject parameter refers to the option game object in the scene hierarchy.
* ``` C#
  protected override void NotSelected(GameObject gameObj){
    //The behaviour of the game object when it's not selected
  }
  ```
* ``` C#
  protected override void OnSubmit(){
    //What happens when the player choose that option.
  }
  ```
  * Menu has a variable that stores the current selected option named `currentOption`(integer), 
  according to the position of the option in `availableOptions`.<br>
  Let's say we have 3 options in a menu: Start, Settings and Exit. 
  Its positions are 0, 1 and 2 respectively in the `availableOptions` array, then we should implement ```OnSubmit()``` like that:
  ``` C#
      protected override void OnSubmit()
      {
        switch (currentOption)
        {
          case 0:
            //Starts the game
            break;
          case 1:
            //Go to options
            break;
          case 2:
            //Exit game
            break;
          }
      }
   ```
   * Menu also has a boolean variable named `pressed` that stops player to press submit multiple times.<br>
   You can set it to false if the option is something you can press multiple times(e.g. muting and unmuting game sound). e.g.
   ``` C#
      case 1:
        mute = !mute;
        pressed = false;
        break;
    ```
The class of the new created menu must be placed in a non singleton game object.
It must stay in the scene and be destroyed when scene changes.

## The LanguageReader class
This class loads the XML files with language content.
It can read XML files locally or from web(really cool).
Create a new LanguageReader by giving the path of the XML file it will read, the language name in the XML file, and if it's from web.
``` C#
  LanguageReader ( string path, string language, bool web)
```
Set language it will read(Locally) by giving the file path and the language name.
``` C#
  setLanguage ( string path, string language)
```
If the XML resource is stored on the web rather than on the local system use give a string containing all XML nodes, and the language name.
``` C#
  setLanguageWeb ( string xmlText, string language)
```
And load strings from XML file using get String and the name of the string in the XML file
```C#
  getString (string name)
```
You won't need to put `LanguageReader.cs` anywhere, [GameManager](#The-GameManager-class) will manage this class.(The less gameobject the better)

## The XML file
This is just an example of the XML file
``` XML
  <languages>
      <English>
          <string name="app_name">Unity Multiple Language Support</string>
          <string name="description">This script provides convenient multiple language support.</string>
      </English>
      <French>
          <string name="app_name">Unité Langue Soutien Multiple</string>
          <string name="description">Ce script fournit un soutien multilingue pratique.</string>
      </French>
  </languages>
```
The tag names must be the same, but the value will change according to the language.

## The GameManager class
This class will mostly set, store and get things.
You must load scenes using
``` C#
  GameManager.LoadScene(string sceneName)
 ```
It will load a new scene with a fade effect from `TransitionManager.cs`.

While the class `LanguageReader.cs` manages the set/load from language files the `GameManager` makes it easier to get and set.
You can use the following functions:
``` C#
    //To set the current file the LanguageReader will read
    //Path as "Resources/file.xml" if file name is "file" and in the "Resources" folder
    GameManager.SetLanguageFile(string filePath)
    //To set current language to read
    GameManager.SetLanguage(Language _language)
    //To get strings from XML file
    GameManager.GetSentence(string sentenceName)
    //To get the actual language of the game
    GameManager.GetLanguage()
```
_I just use local XML files in GameManager._

## The Language enum
Use `Language.cs` as a enum for language names(strings).<br>
It prevents from using "EnGLisH" or "english" instead of "English", using a Language type.<br>
So when you want to set the game language call
``` C#
  GameManager.SetLanguage(Language.English);
  //or
  GameManager.SetLanguage(Language.Japanese);
```
And then the GameManager sets the language by calling `setLanguage()` from `LanguageReader` and passing `Language.English.Value` as parameter.

## The Scene
Two game objects are needed in scene, one with `GameManager.cs` and another with `TransitionManager.cs`_(besides the one which manages the menu, the menu canvas and the camera)_.<br>
Since they're [singleton](https://en.wikipedia.org/wiki/Singleton_pattern) and not destroyable in scene change you can put they only in the first scene, 
but for run each scene separately you can put they in every scene.

## Run the project
1. Download the zip or clone this repo and open it with unity.<br>
2. Open the `LanguageSelection` scene and hit the play button.<br>
3. Use it in your project if you want to.<br>

## Used resources
[Multiple Language Support with XML](https://forum.unity.com/threads/add-multiple-language-support-to-your-unity-projects.206271/)
from a unity forum.<br>
Created by Adam T. Ryder and C# version by O. Glorieux.

[TransitionManager](https://github.com/LightGive/TransitionManager) by LightGive to change scene with cool fade effect.




