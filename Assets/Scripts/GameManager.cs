using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    //THE language manager
    LanguageManager languageManager;
	//Game language
    Language language = Language.English;
    //path of the file that the game is reading from
    string langFilePath = "Resources/menuSentences.xml";

	protected override void Awake()
    {
        base.isDontDestroy = true;
        base.Awake();
        //Initialize and set a default language
        languageManager = new LanguageManager(Path.Combine(Application.dataPath, langFilePath), language.Value, false);
    }

	//Load a scene
    public void LoadScene(string sceneName) { }

    //Set path of the file with the sentences
    public void SetLanguageFile(string filePath){
        languageManager.setLanguage(Path.Combine(Application.dataPath, filePath), language.Value);
        langFilePath = filePath;
    }

    //Get sentence from file
    public string GetSentence(string sentenceName){
        return languageManager.getString(sentenceName);
    }

	//Set game language
    public void SetLanguage(Language _language)
    {
        languageManager.setLanguage(Path.Combine(Application.dataPath, langFilePath), _language.Value);
        language = _language;
    }

	//Get game language
    public Language GetLanguage()
    {
        return language;
    }
}
