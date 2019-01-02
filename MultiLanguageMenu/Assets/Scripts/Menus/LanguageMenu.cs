using UnityEngine;
using UnityEngine.UI;

public class LanguageMenu : Menu
{
    //Game Manager will save the language choice
    private GameManager gm;
    //Name of the scene that will load
    [SerializeField]
    private string nextScene;
    [SerializeField]
    protected Color optionSelected;
    //Color of the word if the option is not selected
    [SerializeField]
    protected Color optionNotSelected;

    protected void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

	//If an option is selected will change color and show flag
    protected override void IsSelected(GameObject gameObj)
    {
        gameObj.transform.Find("Text").GetComponent<Text>().color = optionSelected;
        gameObj.transform.Find("Flag").gameObject.SetActive(true);

    }

	//If an option is not selected will change color and hide flag
    protected override void NotSelected(GameObject gameObj)
    {
        gameObj.transform.Find("Text").GetComponent<Text>().color = optionNotSelected;
		gameObj.transform.Find("Flag").gameObject.SetActive(false);
    }

    /*	Define what will happen if an option was choosed
		Options by order(on inspector):
		0 - Portuguese
		1 - Spanish
		2 - Esglish
		3 - German
		4 - Japanese
	*/
    protected override void OnSubmit()
    {
        switch (currentOption)
        {
            case 0:
                gm.SetLanguage(Language.Portuguese);
                break;
            case 1:
                gm.SetLanguage(Language.Spanish);
                break;
            case 2:
                gm.SetLanguage(Language.English);
                break;
            case 3:
                gm.SetLanguage(Language.German);
                break;
            case 4:
                gm.SetLanguage(Language.Japanese);
                break;
        }

		//Load next scene
        gm.LoadScene(nextScene);
    }
}
