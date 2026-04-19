using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("Pipe Settings")]
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnRate = 1.5f; // час між спавнами
    [SerializeField] private float heightOffset = 2f; // рандом по висоті

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    void SpawnPipe()
    {
        float randomY = Random.Range(-heightOffset, heightOffset);

        Vector3 spawnPos = new Vector3(
            transform.position.x,
            transform.position.y + randomY,
            0
        );

        Instantiate(pipePrefab, spawnPos, Quaternion.identity);
    }
}