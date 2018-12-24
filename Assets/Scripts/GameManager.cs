using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	//Game language
    Language language;

	//Load a scene
    public void LoadScene(string sceneName) { }

	//Set game language
    public void SetLanguage(Language language)
    {
        this.language = language;
    }

	//Get game language
    public Language GetLanguage()
    {
        return language;
    }
}
