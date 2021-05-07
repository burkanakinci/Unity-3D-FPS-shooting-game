using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Image foreground;
    public NavMeshAgent enemyNavMesh;
    private GameManager gameManager;
    private CharacterHealthManager characterHealth;
    public bool saldir;
    private const float maxHealth = 100;
    public float health;
    public int healthReduce;
    public ParticleSystem elecricity;


    void OnEnable()
    {

        characterHealth = FindObjectOfType<CharacterHealthManager>();
        gameManager = FindObjectOfType<GameManager>();

        health = maxHealth;
        saldir = false;
        elecricity.Stop();

        healthReduce = 100 / Random.Range(1, (gameManager.level + 1));

    }

    void Update()
    {

        foreground.fillAmount = health / maxHealth;



        if (health <= 0)
        {

            //enemy ölüm animasyonu çalışsın
            //GetComponent<CapsuleCollider>().enabled=false;
            gameManager.scoreText.text = (++gameManager.score).ToString();
            if (gameManager.score % 5 == 0)
            {
                gameManager.levelText.text = (++gameManager.level).ToString();
            }
            //Destroy(this.gameObject);
            CancelInvoke("ReduceHealth");
            gameManager.objectInScene.Remove(this.gameObject);
            gameManager.objectPool.Add(this.gameObject);
            this.gameObject.SetActive(false);
        }

        float distance = Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position);

        if (distance > 10f && this.gameObject.activeInHierarchy)
        {
            elecricity.Stop();
            //enemy yürüme animasyonu çalışsın
            enemyNavMesh.destination = GameObject.FindWithTag("Player").transform.position;
            //enemyNavMesh.SetDestination(GameObject.FindWithTag("Player").transform.position);
            saldir = false;
            CancelInvoke("ReduceHealth");
        }
        else
        {

            elecricity.Play();
            //saldirma animasyonu çalışsın
            if (saldir == false)
            {

                InvokeRepeating("ReduceHealth", 0.0f, 0.04f);
                saldir = true;
            }
        }
    }
    private void ReduceHealth()
    {
        if (this.gameObject.activeInHierarchy )
        {
            characterHealth.health -= 1;
        }
        //this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
    }
}

