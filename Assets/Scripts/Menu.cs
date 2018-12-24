using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;

public abstract class Menu : MonoBehaviour
{
    //The name of the axis that will control de flow
    [SerializeField]
    protected string axisName;
    //Submit button name
    [SerializeField]
    protected string submitButton;
    //Options availables to choose
    [SerializeField]
    protected GameObject[] availableOptions;
    //The option that is selected
    protected int currentOption;
    //If the submit button was pressed
    protected bool pressed;
    //Manage the axis velocity, it will prevent the selector to go crazy
    private float inptVel;
    //Color of the word if the option is selected

    protected virtual void Start()
    {
        currentOption = 0;
        pressed = false;
    }

    protected virtual void Update()
    {
        SelectedBehaviour();
        KeyboardInput();
        CheckSubmit();
        inptVel = Input.GetAxisRaw(axisName);
    }

    //What will happen 
    //depending on whether or not the option is currently selected
    private void SelectedBehaviour()
    {
        for (int i = 0; i < availableOptions.Length; i++)
        {
            if (availableOptions[i] == availableOptions[currentOption])
            {
                IsSelected(availableOptions[i]);
            }
            else
            {
                NotSelected(availableOptions[i]);
            }
        }
    }

    //what will happen to an option game object if it is selected
    protected abstract void IsSelected(GameObject gameObj);
    //what will happen to an option game object if it is not selected
    protected abstract void NotSelected(GameObject gameObj);

    //Check if the submit button was pressed
    protected void CheckSubmit()
    {
        if (Input.GetButtonDown(submitButton))
        {
            pressed = true;
            OnSubmit();
        }
    }

    //What the program will do if player press submit
    protected abstract void OnSubmit();

    //This allows to change the current available options
    protected IEnumerator SetNewOptions(GameObject[] options)
    {
        // Not developed yet.
        throw new NotImplementedException();
    }

    //Get input and run the functions
    protected void KeyboardInput()
    {
        if (!pressed)
        {
            if (Input.GetAxisRaw(axisName) > 0 && inptVel < 1)
            {
                PreviousOption();
            }

            if (Input.GetAxisRaw(axisName) < 0 && inptVel > -1)
            {
                NextOption();
            }
        }
    }

    //select previous option available
    void PreviousOption()
    {
        if (currentOption == 0)
        {
            currentOption = availableOptions.Length - 1;
        }
        else
        {
            currentOption -= 1;
        }
    }

    //select next option available
    void NextOption()
    {
        if (currentOption == availableOptions.Length - 1)
        {
            currentOption = 0;
        }
        else
        {
            currentOption += 1;
        }
    }
}