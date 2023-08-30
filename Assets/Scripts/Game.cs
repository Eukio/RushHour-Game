using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text t;
    [SerializeField] Car raceCar;
    [SerializeField] Car c1;
    [SerializeField] Car c2;
    [SerializeField] Car c3;
    [SerializeField] Car c4;
    [SerializeField] Car c5;
    [SerializeField] Car c6;
    [SerializeField] Car c7;
    [SerializeField] Car c8;
    [SerializeField] Car c9;


    void Start()
    {
      t.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (raceCar.GetWin() == true) { 
        t.text = "You Win!";
        c1.setWin(true);
        c2.setWin(true);
        c3.setWin(true);
        c4.setWin(true);
        c5.setWin(true);
        c6.setWin(true);
        c7.setWin(true);
        c8.setWin(true);
        c9.setWin(true);
    }
    }
   
   
}
