using System.Collections;
using UnityEngine;

public class PlantSpawning : MonoBehaviour
{
    public Plant[] plants; 
    public float gridSpacing = 1f; 
    public int initialPlantCount = 10; 
    public float spawnInterval = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        SpawnInitialPlants();
        StartCoroutine(SpawnPlantsOverTime());
    }

    void SpawnInitialPlants()
    {
        for (int i = 0; i < initialPlantCount; i++)
        {
            Vector2 randomPosition = GetRandomPositionWithinCameraBounds();
            SpawnPlantAtPosition(randomPosition);
        }
    }

    IEnumerator SpawnPlantsOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            Vector2 randomPosition = GetRandomPositionWithinCameraBounds();
            SpawnPlantAtPosition(randomPosition);
        }
    }

    Vector2 GetRandomPositionWithinCameraBounds()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera == null) return Vector2.zero;

        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        float randomX = Random.Range(mainCamera.transform.position.x - cameraWidth / 2, mainCamera.transform.position.x + cameraWidth / 2);
        float randomY = Random.Range(mainCamera.transform.position.y - cameraHeight / 2, mainCamera.transform.position.y + cameraHeight / 2);

        return new Vector2(randomX, randomY);
    }

    void SpawnPlantAtPosition(Vector2 position)
    {
        float totalSpawnRate = 0f;
        foreach (Plant plant in plants)
        {
            totalSpawnRate += plant.spawnRate;
        }

        float randomValue = Random.Range(0, totalSpawnRate);
        float cumulativeRate = 0f;

        foreach (Plant plant in plants)
        {
            cumulativeRate += plant.spawnRate;
            if (randomValue <= cumulativeRate)
            {
                GameObject plantInstance = Instantiate(plant.plantPrefab, position, Quaternion.identity);
                plantInstance.tag = "Plant";
                plantInstance.AddComponent<CircleCollider2D>().isTrigger = true; 
                break;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
