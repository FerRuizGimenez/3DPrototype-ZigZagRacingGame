using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject pickUpEffect;
    [SerializeField] float moveSpeed;
    bool movingLeft = true;
    bool firstInput = true;

    private void Update() 
    {
        if(GameManager.instance.gameStarted)
        {
            Move();    
            CheckInput();
        }

        if(transform.position.y <= -1.5f)
        {
            GameManager.instance.GameOver();
        }
    }
    private void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void CheckInput()
    {
        // if first input then ignore
        if(firstInput)
        {
            firstInput = false;
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }
    private void ChangeDirection()
    {
        if(movingLeft)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        } 
        else
        {
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Diamond")
        {
            GameManager.instance.IncrementScore();

            Instantiate(pickUpEffect, other.transform.position, pickUpEffect.transform.rotation);

            other.gameObject.SetActive(false);
        }    
    }
}
