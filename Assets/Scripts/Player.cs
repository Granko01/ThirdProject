using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Transform[] orbitCenters;
    public float[] orbitRadii;     
    public float speed = 50f;        
    public int currentOrbit = 0;

    private float angle = 0f;
    private bool isSwitching = false;

    public int CollectedCoins = 0;

    public Coins coins;
    public LevelsManager levelsManager;
    public CoinsManager coinsManager;

    void Update()
    {
        MoveAroundOrbit();
        HandleInput();
    }

    void MoveAroundOrbit()
    {
        angle += speed * Time.deltaTime;
        angle %= 360f;

        Vector3 center = orbitCenters[currentOrbit].position;
        float radius = orbitRadii[currentOrbit];
        float radian = angle * Mathf.Deg2Rad;
        Vector3 newPosition = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * radius + center;

        transform.position = newPosition;
    }

    void HandleInput()
    {
        if (isSwitching) return;

        if (Input.GetKeyDown(KeyCode.UpArrow) && currentOrbit > 0)
        {
            currentOrbit--;
            StartCoroutine(SwitchCooldown());
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && currentOrbit < orbitRadii.Length - 1)
        {
            currentOrbit++;
            StartCoroutine(SwitchCooldown());
        }
    }

    System.Collections.IEnumerator SwitchCooldown()
    {
        isSwitching = true;
        yield return new WaitForSeconds(0.2f); // Prevents rapid switching
        isSwitching = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("Obstacle"))
        //{
        //    Debug.Log("Hit Obstacle!");
            
        //}

        if (other.CompareTag("Coins"))
        {
            Debug.Log("Coin Collected!");
            Destroy(other.gameObject);
            coins.CoinsWin += 10;
            coins.CoinsWinText.text = coins.CoinsWin.ToString();
            coins.SaveCoinsWin();
            coins.CoinsAmount += coins.CoinsWin;
            coins.CoinsWin = 0;
            coins.CoinsWinText.text = coins.CoinsAmount.ToString();
            coins.SaveCoinsAmount();
            CollectedCoins++;
            coinsManager.SpawnCoins();
            if (CollectedCoins == 3)
            {
                levelsManager.GamePanels[1].gameObject.SetActive(true);
                levelsManager.GamePanels[0].gameObject.SetActive(false);
            }
        }
    }
}
