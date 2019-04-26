using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public float scoreValue = 0; 
    Text score; 
    public bool timer = false;

    // Start is called before the first frame update
    void Start()
    {
       score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == true){
        scoreValue += Mathf.Round(Time.deltaTime + 1);
        score.text = "" + scoreValue;
        }
    }
//GameObject.Find("Player").GetComponent<PlayerController>().Death() //Time.timeScale sänker hastigheten på spelet och används för att spola ner hastigheten på allt 
}