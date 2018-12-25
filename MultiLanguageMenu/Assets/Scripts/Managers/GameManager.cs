using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    //THE language manager
    LanguageReader langReader;
    //Game language
    Language lang = Language.English;
    //path of the file that the game is reading from
    string langFilePath = "Resources/menuSentences.xml";

    protected override void Awake()
    {
        base.isDontDestroy = true;
        base.Awake();
        //Initialize and set a default language
        langReader = new LanguageReader(Path.Combine(Application.dataPath, langFilePath), lang.Value, false);
    }

    //Load a scene
    public void LoadScene(string sceneName)
    {
        FindObjectOfType<TransitionManager>().LoadScene(sceneName);
    }

    //Set path of the file with the sentences
    public void SetLanguageFile(string filePath)
    {
        langReader.setLanguage(Path.Combine(Application.dataPath, filePath), lang.Value);
        langFilePath = filePath;
    }

    //Get sentence from file
    //the names of the sentences are defined in the xml file
    public string GetSentence(string sentenceName)
    {
        return langReader.getString(sentenceName);
    }

    //Set game language
    public void SetLanguage(Language _language)
    {
        langReader.setLanguage(Path.Combine(Application.dataPath, langFilePath), _language.Value);
        lang = _language;
    }

    //Get game language
    public Language GetLanguage()
    {
        return lang;
    }
}
