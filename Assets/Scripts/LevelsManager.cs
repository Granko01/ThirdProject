using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    public GameObject FirstPanel;
    public GameObject SecondPanel;
    public GameObject GameUI;
    public GameObject[] GamePanels;

    public void OpenFirstPanel()
    {
        if (FirstPanel.activeSelf)
        {
            FirstPanel.gameObject.SetActive(false);
        }
        FirstPanel.gameObject.SetActive(true);
    }

    public void OpenSecondPanel()
    {
        if (SecondPanel.activeSelf)
        {
            SecondPanel.gameObject.SetActive(false);
        }
        SecondPanel.gameObject.SetActive(true);
        FirstPanel.gameObject.SetActive(false);
    }

    public void OpenGamesLevel()
    {
        GameUI.gameObject.SetActive(true);
        GamePanels[0].gameObject.SetActive(true);
        SecondPanel.gameObject.SetActive(false);
    }


    
}
