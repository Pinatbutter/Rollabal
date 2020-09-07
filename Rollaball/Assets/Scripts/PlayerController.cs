using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using System.Diagnostics;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public int TotalPickups = 13;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private bool gameOver = false;
    private GameObject[] pickups;

    public void youLost(bool timeUp)
    {
        gameOver = timeUp;
        loseTextObject.SetActive(true);
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");
        foreach (GameObject pick in pickups)
        {
            pick.SetActive(false);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();

        SetCountText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        gameOver = false;

    }

    void OnMove(InputValue movementValue)
    {
        if (gameOver == false)
        {
            Vector2 movementVector = movementValue.Get<Vector2>();
            movementX = movementVector.x;
            movementY = movementVector.y;
        }
    }

    void SetCountText()
    {
        if (gameOver == false)
        {
            countText.text = "Count: " + count.ToString();
            if (count >= TotalPickups)
            {
                gameOver = true;
                winTextObject.SetActive(true);
                GetComponent<TimerCode>().youWon(gameOver);
            }
        }
    }

    void FixedUpdate()
    {
        if (gameOver == false)
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * speed);
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log(other.gameObject.tag);

        if (other.gameObject.CompareTag("Pickup")) ;
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
}
