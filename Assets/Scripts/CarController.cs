using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed;
    bool movingLeft = true;
    bool fisrtInput = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            Move();
            CheckInput();
        }

        if(transform.position.y < -2)
        {
            GameManager.instance.GameOver();
        }
    }

    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void CheckInput()
    {
        if (fisrtInput)
        {
            fisrtInput = false;
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        if (movingLeft)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            movingLeft = false;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            movingLeft = true;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Diamond"))
        {

            GameManager.instance.AddDiamond();
            other.gameObject.SetActive(false);
        }
    }
}
