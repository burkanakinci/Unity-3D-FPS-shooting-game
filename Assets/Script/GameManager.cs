using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public enum gameState
    {
        aim,
        fire,
        gameOver
    }

    public GameObject enemyObject;
    public gameState currentState;
    public Camera cameraMain, bulletCamera;
    public GameObject bulletObject, bulletParent;
    public GameObject fpsCharacter;
    public GameObject[] spawnPoints;
    public Text scoreText;
    public Text levelText;
    public int level;
    public int score;

    public List<GameObject> objectInScene;
    public List<GameObject> objectPool;
    void Awake()
    {
        level = 1;
        levelText.text = level.ToString();
        cameraMain.enabled = true;
        bulletCamera.enabled = false;
        bulletObject.SetActive(false);
    }
    void Start()
    {

        currentState = gameState.aim;
        Invoke("SpawnEnemy", 3.0f);
        score = 0;
        scoreText.text = score.ToString();
    }

    void Update()
    {



        switch (currentState)
        {
            case gameState.aim:

                cameraMain.enabled = true;
                bulletCamera.enabled = false;

                break;
            case gameState.fire:
                cameraMain.enabled = false;
                bulletCamera.enabled = true;
                CancelInvoke("SpawnEnemy");
                break;
            case gameState.gameOver:
                cameraMain.enabled = true;
                bulletCamera.enabled = false;
                CancelInvoke("SpawnEnemy");

                break;
            default:
                break;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            bulletObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            UnityEditor.EditorApplication.isPaused = !UnityEditor.EditorApplication.isPaused;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnEnemy();
        }

    }
    public void SpawnEnemy()
    {

        int randomSpawn = Random.Range(0, spawnPoints.Length);


        if (objectPool.Count > 0)
        {

            objectInScene.Add(objectPool[0]);
            objectPool.Remove(objectPool[0]);
        }
        else
        {

            objectInScene.Add(Instantiate(enemyObject, spawnPoints[randomSpawn].transform.position, Quaternion.identity));
        }
        Invoke("SpawnEnemy", 3.0f);
    }

    public void ShootingBullet(){

        bulletObject.SetActive(true);
    }
}
