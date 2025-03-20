using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int WaveCount = 0;
    [SerializeField]
    public int CurrentGroup = 0;
    [SerializeField]
    private float CountDown;
    [SerializeField]
    private GameObject spawnpoint;
    [SerializeField]
    private TextMeshProUGUI goldCounter;

    [SerializeField]
    private float waveCountdown;

    public Wave[] waves;

    private bool readyToCountDown;

    public int BaseHealth = 100;

    public int gold;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        readyToCountDown = true;

        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesleft = waves[i].enemies.Length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToCountDown == true)
        {
            CountDown -= Time.deltaTime;
        }
        //starts the coroutine
        if (CountDown <= 0)
        {
            readyToCountDown = false;

            CountDown = waves[CurrentGroup].timeToNextWave;

            StartCoroutine(SpawnWave());
        }
        //check if theres enemies left and increases either the wave or group based on the current group
        if (waves[CurrentGroup].enemiesleft == 0)
        {
            readyToCountDown = true;
            if (CurrentGroup >= waves.Length - 1)
            {
                for (int i = 0; i < waves.Length; i++)
                {
                    waves[i].enemiesleft = waves[i].enemies.Length;
                }
                WaveCount++;
            }
            else
            {
                CurrentGroup++;
            }
        }

        goldCounter.text = gold.ToString();
    }

    private IEnumerator SpawnWave()
    {
        if (CurrentGroup < waves.Length)
        {
            for (int i = 0; i < waves[CurrentGroup].enemies.Length; i++)
            {
                EnemyPath enemy = Instantiate(waves[CurrentGroup].enemies[i], spawnpoint.transform);

                enemy.transform.SetParent(spawnpoint.transform);

                yield return new WaitForSeconds(waves[CurrentGroup].timeToNextEnemy);
            }
        }
    }

}

[System.Serializable]
public class Wave
{
    public EnemyPath[] enemies;
    public float timeToNextEnemy;

    public float timeToNextWave;
    public int enemiesleft;
}