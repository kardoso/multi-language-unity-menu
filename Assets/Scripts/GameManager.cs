using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
	//Game language
    Language language;

	protected override void Awake()
    {
        base.isDontDestroy = true;
        base.Awake();
    }

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
