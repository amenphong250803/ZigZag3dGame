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
}
