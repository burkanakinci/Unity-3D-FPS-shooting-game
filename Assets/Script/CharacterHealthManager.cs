using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealthManager : MonoBehaviour
{
    public GameObject endGamePanel;
    private GameManager gameManager;
    public int health;
    void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
        endGamePanel.SetActive(false);
        health = 100;
    }

    void Update()
    {

        Debug.Log("Character Health  :  " + health);

        if(health<=0){

            GameOver();
        }

    }

    public void RestartGame()
    {

        SceneManager.LoadScene(1);
    }

    private void GameOver()
    {

        for (int i = 0; i < gameManager.objectInScene.Count;i++)
        {
                
            gameManager.objectInScene[i].SetActive(false);
        }
        endGamePanel.SetActive(true);
        
    }
}
