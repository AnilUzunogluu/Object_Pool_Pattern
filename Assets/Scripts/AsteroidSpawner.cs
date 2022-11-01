using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;
    [SerializeField] private float spawnChancePercent;
    void Update()
    {
        if (Random.Range(0,100) < spawnChancePercent)
        {
            GameObject spawnedAsteroid = Pool.instance.Get("Asteroid");
            if (spawnedAsteroid is not null)
            {
                spawnedAsteroid.transform.position = new Vector3(Random.Range(-9f, 9f), 8.5f, 0f);
                spawnedAsteroid.SetActive(true);
            }
        }
    }
}
