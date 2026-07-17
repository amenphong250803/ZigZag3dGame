using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Platform : MonoBehaviour
{
    public GameObject diamond;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int randDiamond = Random.Range(0, 7);
        
        Vector3 diamondPos = transform.position;
        diamondPos.y += 1f;

        if(randDiamond == 0)
        {
            GameObject diamondInstance = Instantiate(diamond, diamondPos, Quaternion.identity);
            diamondInstance.transform.SetParent(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("Fall", 0.1f);
        }
    }

    void Fall()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.isKinematic = false;
        rb.linearVelocity = Vector3.down * 10f;

        Destroy(gameObject, 1f);
    }
}
