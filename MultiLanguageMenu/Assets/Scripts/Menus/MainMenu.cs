using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu {

    bool isMain; //if current options are from main menu
    public List<GameObject> mainOptions;    //Main menu options
    public List<GameObject> settingsOptions;//Settings options
    public GameObject settingsObject; //Settings gameObject
	//Game Manager will save the language choice
    private GameManager gm;
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
		//It will set the text for the options
		DefineOptionsSenteces();
        settingsObject.SetActive(false);
        isMain = true;
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
        if(isMain){
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
                    SetNewOptions(settingsOptions); //change available options
                    settingsObject.SetActive(true); //enable settings game object
                    currentOption = 0;  //set current option to 0
                    isMain = false;     //not the main options now
                    break;
                case 3:
                    //Here should be the code to quit actually
                    //But i'll go back to language selection menu
                    gm.LoadScene(nextScene);
                    break;
            }
        }
        else{
            Debug.Log(currentOption);
            SetNewOptions(mainOptions); //change available options
            settingsObject.SetActive(false);    //disable setting game object
            currentOption = 2;  //settingsObject current option to 2
            isMain = true;      //main options
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
