using UnityEngine;

public class ZombieGeneratorOffline : MonoBehaviour
{
    public float generationTimeSecondsMin = 1;
    public float generationTimeSecondsMax = 10;
    public GameObject zombiePrefab;

    private GameObject player;
    private float lastGenerationTime;
    private float currentGenerationDelay;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastGenerationTime = Time.time;
        SetNewGenerationDelay();
    }

    void Update()
    {
        if (lastGenerationTime + currentGenerationDelay < Time.time && player != null)
        {
            lastGenerationTime = Time.time;
            SetNewGenerationDelay();

            GenerateNewZombie();
        }
    }

    private void SetNewGenerationDelay()
    {
        currentGenerationDelay = Random.Range(generationTimeSecondsMin,
            generationTimeSecondsMax);
    }

    private void GenerateNewZombie()
    {
        Instantiate(zombiePrefab, transform.position, Quaternion.identity);
    }
}
