using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUi : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject gameWonMenu;
    [SerializeField] GameObject score;
    [SerializeField] GameObject mainMenu;
    GameObject[] Menus;
    [SerializeField ]GameObject activeMenu;

    private void Start()
    {
        Menus = new GameObject[4];
        Menus[0] = gameOverMenu;
        Menus[1] = gameWonMenu;
        Menus[2] = score;
        Menus[3] = mainMenu;

    }
    private void Update()
    {
        for (var i = 0; i < 4; i++)
        {
            if (Menus[i] == activeMenu)
            {
                Menus[i].SetActive(true);
            }
            else
            {
                Menus[i].SetActive(false);
            }
        }
    }

public void GameOver()
    {
        activeMenu = gameOverMenu;
    }
public void Gamewon()
    {
        activeMenu = gameWonMenu;
    }

}
