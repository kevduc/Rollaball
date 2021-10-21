using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    public TextMeshProUGUI scoreText;
    public GameObject winText;
    public GameObject loseText;

    private int score;
    private bool hasLost = false;
    private bool hasWon = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;

        UpdateScoreText();

        winText.SetActive(false);
        loseText.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        if (hasLost) return;

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void UpdateScoreText()
    {
        scoreText.text ="Score: " + score.ToString();
    }

    void CheckWin()
    {
        if (score >= 13)
        {
            Win();
            return;
        }
    }

    void Win()
    {
        winText.SetActive(true);
        hasWon = true;
    }

    void Lose()
    {
        loseText.SetActive(true);
        hasLost = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasLost || hasWon) return;

        if (!other.CompareTag("PickUp")) return;

        other.gameObject.SetActive(false);
        score += 1;
        UpdateScoreText();
        CheckWin();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasLost || hasWon) return;

        if (collision.gameObject.CompareTag("Wall"))
        {
            Lose();
            return;
        }

    }

}
