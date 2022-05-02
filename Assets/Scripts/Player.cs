using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int score = 0; //this will count the number of frogs caught
    public float speed = 2.0f; //making the movement speed public will make it editable in Unity
    public Text scoreAmount;
    public Text youWin;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime , 0, 0);
            //using deltaTime slows the movement so it doesn't just jump to the next location
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        if (score >= 2)
        {
            Destroy(door);
            youWin.text = "Winner!";
        }
    }

    //OnCollision2D will keep the player from running through walls/possibly add other objects here later?
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item") //this will remove items from the screen/game
        {
            score++;
            scoreAmount.text = "Frogs: " + score;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Walls") //this will cause player to bounce off any object tagged "Walls"
        {
            if (Input.GetKey(KeyCode.LeftArrow)) //is there a way to simply these if statements to shorten/clean the code? 
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
                //using deltaTime slows the movement so it doesn't just jump to the next location
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }
    }
}
