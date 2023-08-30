using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Rigidbody2D rb;
    [SerializeField] int movement;
    int LR = 0;
   int UD = 1;
    bool moving, release;
    float mouseDisplacement;
    bool win;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        mouseDisplacement = 0;
        win = false;
    }

    // Update is called once per frame
    void Update()
    {




        

        //         gameObject.transform.localPosition = gameObject.transform.localPosition - Input.mousePosition;

    }
    private void OnMouseDown()
    {
        Debug.Log("clicked");
        moving = true;
        release = false;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (movement == LR)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
            mouseDisplacement = transform.position.x - mousePos.x;
        }
        if (movement == UD) {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
            mouseDisplacement = transform.position.y - mousePos.y;
    }

    }

    private void FixedUpdate()
    {
        if (moving && !win)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (movement == LR)
            {
                Vector3 goal = new Vector3(mousePos.x + mouseDisplacement, 0, 0);
                rb.velocity = new Vector3((goal.x - transform.position.x) / Time.deltaTime, 0);
            }
            if (movement == UD)
            {
                Vector3 goal = new Vector3(0,mousePos.y + mouseDisplacement, 0);
                rb.velocity = new Vector3(0,(goal.y - transform.position.y) / Time.deltaTime, 0);
            }
        }
   
        if (release)
        {
            moving = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.velocity = Vector3.zero;
        }

    }
    private void OnMouseUp()
    {
        release = true;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Hit Wall");
        if (collision.gameObject.name.Equals("Finish") && gameObject.name.Equals("RaceCar"))
        {
            win = true;
        }
    }
    public bool GetWin()
    {
        return win;
    }

    public void setWin(bool win)
    {
        this.win = win;
    }


}
