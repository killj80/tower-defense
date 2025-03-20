using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPath : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 destination;
    public GameManager gameManager;
    public Vector3 UntillDestination;

    public int enemyHealth = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    void Start()
    {
        //list met checkpoints, update destination on reaching next point, boolean for reaching a certain checkpoint, set to true after reaching it
        agent.SetDestination(destination);
        UntillDestination = destination - gameObject.transform.position;
    }

    private void Update()
    {
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
            gameManager.waves[gameManager.CurrentGroup].enemiesleft--;
            gameManager.gold = gameManager.gold + 5;
        }
    }

    public void BaseReached()
    {
        gameManager.BaseHealth = gameManager.BaseHealth - enemyHealth;
        gameManager.waves[gameManager.CurrentGroup].enemiesleft--;
        Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            int damage = other.gameObject.GetComponent<CannonTower>().towerDamage;
            //StartCoroutine(TowerShoot(damage));
            StartCoroutine(TowerShoot(damage));
        }
    }

    IEnumerator TowerShoot(int Damage)
    {
        yield return new WaitForSeconds(1);
        enemyHealth = enemyHealth - Damage;
        StopAllCoroutines();
    }
}
