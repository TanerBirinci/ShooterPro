using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab,enemyContainer,astroidFirst;
    [SerializeField] private GameObject[] powerups;

    private bool stopSpawning,stopTriplePowerup= false;
    private bool stopAstroid = false;
    private bool enemyHave = false;
    void Start()
    {
        StartCoroutine(CreateAstroidRoutine());
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnTriplePowerUpRoutine());
    }

    
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (stopSpawning==false)
        {
            Vector3 newEnemyPosition = new Vector3(Random.Range(-7.5f, 7.5f), 7, 0);
            GameObject newEnemy=Instantiate(enemyPrefab,newEnemyPosition,Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(2f);
        }
        
    }

    IEnumerator SpawnTriplePowerUpRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (stopTriplePowerup==false)
        {
            Vector3 newPowerUpPosition = new Vector3(Random.Range(-7.5f, 7.5f), 7, 0);
            int randomPowerup = Random.Range(0, 3);
            GameObject powerUp = Instantiate(powerups[randomPowerup], newPowerUpPosition, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5,8)); 
        }
    }

    IEnumerator CreateAstroidRoutine()
    {
        while (stopAstroid==false)
        {
            Instantiate(astroidFirst, new Vector3(-0.4f, 4, 0), Quaternion.identity);
            stopAstroid = true;
            yield break;
        }
        
    }

    public void OnPlayerDead()
    {
        stopSpawning = true;
        stopTriplePowerup = true;
    }
    
    
    
    
}
