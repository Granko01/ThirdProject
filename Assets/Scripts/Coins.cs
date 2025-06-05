using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{

    public int CoinsAmount;
    public int CoinsWin;

    public Text CoinsAmountText;
    public Text CoinsWinText;

    private const string CoinsAmountKey = "CoinsAmounKey";
    private const string CoinsWinKey = "CoinsKeyWin";


    void Start()
    {
        CoinsAmount = PlayerPrefs.GetInt(CoinsAmountKey, CoinsAmount);
        CoinsWin = PlayerPrefs.GetInt(CoinsWinKey, CoinsWin);
        CoinsAmountText.text = CoinsAmount.ToString();
        CoinsWinText.text = CoinsWin.ToString();
    }

    private void SetCoinsAmount()
    {
        PlayerPrefs.GetInt(CoinsAmountKey, CoinsAmount);
    }

    private void SetCoinsWin()
    {
        PlayerPrefs.GetInt(CoinsWinKey, CoinsWin);
    }

    public void SaveCoinsAmount()
    {
        PlayerPrefs.SetInt(CoinsAmountKey, CoinsAmount);
        PlayerPrefs.Save();
    }

    public void SaveCoinsWin()
    {
        PlayerPrefs.SetInt(CoinsWinKey, CoinsWin);
        PlayerPrefs.Save();
        Debug.Log("SAVED");
    }
    
}
