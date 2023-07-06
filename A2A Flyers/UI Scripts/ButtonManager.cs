using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] int numberOfButtons = 4;
    [SerializeField] GameObject[] buttons;
    private int activeButton;
    private bool isSelected = true;
    
    void Start()
    {
        activeButton = 0;
    }

    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            if (!isSelected)
            {
                if (Input.GetAxisRaw("Vertical") < 0)
                {
                    if (activeButton == (buttons.Length - 1))
                    {
                        activeButton = 0;
                    }
                    else
                    {
                        activeButton++;
                    }
                }else if (Input.GetAxisRaw("Vertical") > 0)
                {
                    if (activeButton == 0)
                    {
                        activeButton = buttons.Length - 1;
                    }
                    else
                    {
                        activeButton--;
                    }
                }
                isSelected = true;
            }
        }
        if (Input.GetButtonUp("Vertical"))
        {
            isSelected = false;
        }

    }

    public int CurrentActive()
    {
        return activeButton;
    }

    public void Call(string call)
    {

        switch (call)
        {
            case "EndGame":
                Application.Quit();
                break;
            case "Play":
                SceneManager.LoadScene("SampleScene");
                break;
            case "MainMenu":
                SceneManager.LoadScene("MainMenuScene");
                break;
            case "ReStart":
                SceneManager.LoadScene("SampleScene");
                break;
            default:
                break;
        }

    }

}
