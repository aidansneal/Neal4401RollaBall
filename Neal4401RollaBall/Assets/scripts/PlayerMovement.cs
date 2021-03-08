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
    public bool gameOver = false;
    public GameObject winTextObject;
    public GameObject loseTextObject;

    // Start is called before the first frame update
    void Start()
    {
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
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
        //score collision
        if (other.gameObject.CompareTag("score"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Score!");
            winTextObject.SetActive(true);
        }

        if (other.gameObject.CompareTag("enemy")) 
        {
            loseTextObject.SetActive(true);
        }
     
    }
}
