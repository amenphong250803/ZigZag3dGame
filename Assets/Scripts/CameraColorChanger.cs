using System.Collections;
using UnityEngine;

public class CameraColorChanger : MonoBehaviour
{   
    public Color[] colors;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ColorChanger());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ColorChanger()
    {
        while (true)
        {
            int randColor = Random.Range(0, colors.Length);

            Camera.main.backgroundColor = colors[randColor];
            yield return new WaitForSeconds(20f);
        }
    }
}
