using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject boss; 



    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f };

    [SerializeField]
    private float spawnInterval = 1.5f;

    void Start()
    {
        if (enemies == null || enemies.Length == 0)
        {
            Debug.LogError("EnemySpawner needs at least one enemy prefab.");
            enabled = false;
            return;
        }

        StartCoroutine(EnemyRoutine());
    }

    public void StopEnemyRoutine()
    {
        StopCoroutine(nameof(EnemyRoutine));
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);

        float moveSpeed = 5f;
        int spawnCount = 0;
        int enemyIndex = 0;

        while (true)
        {
            foreach (float posX in arrPosX)
            {
                SpawnEnemy(posX, enemyIndex, moveSpeed);
            }

            spawnCount += 1;

            if (spawnCount % 10 == 0)
            {
                enemyIndex += 1;
                moveSpeed += 2;
            }

            if (enemyIndex >= enemies.Length)
            {
                SpawnBoss();
                enemyIndex = 0; 
                moveSpeed = 5f; 
                
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(float posX, int index, float moveSpeed)
    {
        Vector3 spawnPos = new Vector3(
            posX,
            transform.position.y,
            transform.position.z
        );

        if (Random.Range(0, 5) == 0)
        {
            index += 1;
        }

        if (index >= enemies.Length)
        {
            index = enemies.Length - 1;
        }

        GameObject enemyObject = Instantiate(
            enemies[index],
            spawnPos,
            Quaternion.identity
        );

        Enemy enemy = enemyObject.GetComponent<Enemy>();

        enemy.SetMoveSpeed(moveSpeed);
    }

    void SpawnBoss()
    {
        if (boss == null)
        {
            Debug.LogError("EnemySpawner needs a boss prefab.");
            return;
        }

        Instantiate(boss, transform.position, Quaternion.identity);
    }
}
