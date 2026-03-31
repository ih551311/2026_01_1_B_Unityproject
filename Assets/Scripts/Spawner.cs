using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefabs;
    public GameObject MissilePrefabs;

    [Header("스폰 타이밍 설정")]
    public float minSpawnInterval = 0.5f;
    public float manSpawnInterval = 2.0f;

    public float timer = 0.0f;
    public float nextSpawnTime;

    [Range (0 , 100)]
    public int coinSpawnChance = 50;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetNextSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //생성 시간이 되면 오브젝트 생성
        if (timer > nextSpawnTime)
        {
            SpawnObject();
            timer = 0.0f;
            SetNextSpawnTime();
        }
    }
    void SpawnObject()
    {
        Transform spawnTransform = transform;
        if (Random.Range(0, 100) < coinSpawnChance)
        {
            Instantiate(coinPrefabs, spawnTransform.position, spawnTransform.rotation);
        }
        else { Instantiate(MissilePrefabs, spawnTransform.position, spawnTransform.rotation); }
    }
    void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnInterval, manSpawnInterval);
    }
}  
