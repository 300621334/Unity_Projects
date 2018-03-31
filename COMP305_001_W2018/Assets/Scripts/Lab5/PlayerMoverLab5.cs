using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMoverLab5 : MonoBehaviour {

    public float speed = 3f;
    public Text txt;
    string scene1 = "Lab_5.1_PickObjs";
    string scene2 = "Lab_5.2_DisplayCount";
    

    Rigidbody2D rb;
    float moveX, moveY;
    Collider2D that;
    int redCount = 0, blueCount = 0, greenCount = 0;
    List<GameObject> listRed, listBlue, listGreen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        that = other;

        if (that.tag == "RED" && that != null)
        {
            redCount++;
            DontDestroyOnLoad(that.gameObject);//that.GetComponent<GameObject>() makes gives a null somehow!!!
            listRed.Add(that.gameObject);
            other.GetComponent<SpriteRenderer>().enabled = false;
        }

        else if (that.tag == "BLUE" && that != null)
        {
            blueCount++;
            DontDestroyOnLoad(that.gameObject);
            listBlue.Add(that.gameObject);
            other.GetComponent<SpriteRenderer>().enabled = false;
        }

        else if (that.tag == "GREEN" && that != null)
        {
            greenCount++;
            DontDestroyOnLoad(that.gameObject);
            listGreen.Add(that.gameObject);
            other.GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    //Obj carried to next scene intact
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);//this yellow dot will be carried over to next scene
        //redCount = blueCount = greenCount = 0;
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();//rb of this
        listRed = new List<GameObject>();//list will contain all objs picked
        listBlue = new List<GameObject>();
        listGreen = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        //Move Player
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(moveX, moveY);
        rb.velocity = move * speed;

        //Pick objs & save their count
        //that = Physics2D.OverlapCircle(transform.position , 0.5f);
        //if(other != null)
        //{
        //    if (other.tag == "RED") redCount++;
        //    if (other.tag == "BLUE") blueCount++;
        //    if (other.tag == "GREEN") greenCount++;
        //}

        //switch scenes
        //if (Input.GetKeyUp("1"))
        //{
        //    SceneManager.LoadScene(scene1);//load next scene
        //}

        if (Input.GetKeyUp("2"))
        {
            SceneManager.LoadScene(scene2);
            txt.text = redCount + " = Red\n" +
                        blueCount + " = Blue\n" +
                        greenCount + " = Green\n"; //show txt
            //foreach (GameObject o in listRed)
            //{
            //    o.GetComponent<SpriteRenderer>().enabled = true;
            //}
        }

        
    }
}
