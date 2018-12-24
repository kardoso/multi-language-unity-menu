using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu {

	//Game Manager will save the language choice
    private GameManager gm;
    [SerializeField]
    protected Color optionSelected;
    //Color of the word if the option is not selected
    [SerializeField]
    protected Color optionNotSelected;

    protected override void Start()
    {
        base.Start();
        gm = FindObjectOfType<GameManager>();
    }

	//If an option is selected will change color and show arrow
    protected override void IsSelected(GameObject gameObj)
    {
        gameObj.transform.Find("Text").GetComponent<Text>().color = optionSelected;
        gameObj.transform.Find("Arrow").gameObject.SetActive(true);

    }

	//If an option is not selected will change color and hide arrow
    protected override void NotSelected(GameObject gameObj)
    {
        gameObj.transform.Find("Text").GetComponent<Text>().color = optionNotSelected;
		gameObj.transform.Find("Arrow").gameObject.SetActive(false);
    }

    /*	Define what will happen if an option was choosed
		Options by order(on inspector):
		0 - Start Game
		1 - Load Game
		2 - Settings
		3 - Quit
	*/
    protected override void OnSubmit()
    {
        switch (currentOption)
        {
			//Since I don't have another scene do load
			//I just set pressed to false to not freeze the menu
            case 0:
                Debug.Log("Start Game");
				pressed = false;
                break;
            case 1:
                Debug.Log("Load Game");
				pressed = false;
                break;
            case 2:
                Debug.Log("Settings");
				pressed = false;
                break;
            case 3:
                Debug.Log("Quit Game");
				pressed = false;
                break;
        }
	}

	//Load sentences to options text
	//the names of the sentences are defined in the xml file
	private void DefineOptionsSenteces(){
		availableOptions[0].transform.Find("Text").GetComponent<Text>().text = gm.GetSentence("start_new");
		availableOptions[1].transform.Find("Text").GetComponent<Text>().text = gm.GetSentence("load");
		availableOptions[2].transform.Find("Text").GetComponent<Text>().text = gm.GetSentence("settings");
		availableOptions[3].transform.Find("Text").GetComponent<Text>().text = gm.GetSentence("exit");
	}
}
