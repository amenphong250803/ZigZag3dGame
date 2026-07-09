using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    public Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPos;

    bool stop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = lastPlatform.position;
        StartCoroutine(SpawnPlatform());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPlatform()
    {
        while (!stop)
        {
            GeneratePosition();
            Instantiate(platform, newPos, Quaternion.identity);
            lastPosition = newPos;

            yield return new WaitForSeconds(0.1f);
        }
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
