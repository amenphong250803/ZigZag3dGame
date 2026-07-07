using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    public Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = lastPlatform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SpawnPlatforms();
        }
    }

    void SpawnPlatforms()
    {
        GeneratePosition();

        Instantiate(platform, newPos, Quaternion.identity);
        
        lastPosition = newPos;
    }

    void GeneratePosition()
    {
        newPos = lastPosition;

        int rand = Random.Range(0, 3);
        if(rand > 0)
        {
            newPos.z += 2.5f;
        }
        else
        {
            newPos.x += 2.5f;
        }
    }
}
