using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0;
    private float movementX;
    private float movementY;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("score"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Score!");
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("You lose");
        }
    }
}
