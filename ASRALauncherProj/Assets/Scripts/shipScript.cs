using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipScript : MonoBehaviour
{
    public float rotationSpeed;
    public float speed;
    public int fuel;
    private Rigidbody2D playerRB;
    private float xComponent;
    private float yComponent;
    private bool landable;
    private bool gameOver = false;
    private float timerScore = 10;
    private int finalScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        xComponent = 0.0f;
        yComponent = 0.0f;
        landable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == false)
        {
        if(timerScore > 0)
            timerScore -= Time.deltaTime;
        handleInputs();
        canLandSafely();
        scoreCalculator();
        }
    }


    void handleInputs(){
        if(Input.GetKey(KeyCode.A)){
         playerRB.rotation += Time.deltaTime * rotationSpeed;
        }
        else if(Input.GetKey(KeyCode.D)){
        playerRB.rotation -= Time.deltaTime * rotationSpeed;
        }

     if(Input.GetKey(KeyCode.W) && fuel > 0)
     {  
        fuel -= 1;

        xComponent = -Mathf.Sin(playerRB.rotation * Mathf.Deg2Rad) * speed * Time.deltaTime;
        yComponent = Mathf.Cos(playerRB.rotation * Mathf.Deg2Rad) * speed * Time.deltaTime;

        if(playerRB.velocity.x < 5)
            playerRB.velocity += new Vector2(xComponent * 0.6f, 0);
        if(playerRB.velocity.y < 5)
         playerRB.velocity += new Vector2(0, yComponent);
     }
    }

    void canLandSafely()
    {
        if(playerRB.rotation < 5 && playerRB.rotation > -5 && playerRB.velocity.y > -10.0f){
            landable = true;
        }
        else{
            landable = false;
        }
    }

    void scoreCalculator()
    {
        finalScore = (1000 * (int)(timerScore)/10) + fuel;
    }

    public int getScore()
    {
        return finalScore;   
    }

    public bool hasLanded()
    {
        if(gameOver)
            return true;
        else return false;
    }

    public int getFuel()
    {
        return fuel;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (landable == true && other.collider.tag == "Land")
            {
            scoreCalculator();
            Debug.Log("YOU WIN\nFinal Score: " + finalScore);
            }
        else
            Debug.Log("YOU LOSE");
        gameOver = true;
    }
}
