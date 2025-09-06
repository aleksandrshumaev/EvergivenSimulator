using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landLogic : MonoBehaviour
{
    gameLogic GameLogic;
    public GameObject prevLand;
    public GameObject leftBeach1;
    public GameObject leftBeach2;
    public GameObject rightBeach1;
    public GameObject rightBeach2;
    public bool canMove=true;
    public float currentTime;
    void Start()
    {
        GameLogic=gameLogic.instance;
        currentTime=0;
    }
    void Update()
    {
        if(currentTime<1)
            currentTime+=1f*Time.deltaTime;
        else
        {
            currentTime=0;
            leftBeach1.SetActive(!leftBeach1.activeSelf);
            leftBeach2.SetActive(!leftBeach2.activeSelf);
            rightBeach1.SetActive(!rightBeach1.activeSelf);
            rightBeach2.SetActive(!rightBeach2.activeSelf);
        }
        if(GameLogic.state==2|GameLogic.state==0)
            transform.Translate(Vector3.down*1f*Time.deltaTime);
        if(transform.position.y<=-7f)
            transform.position=new Vector3(1.109428f,prevLand.transform.position.y+1f,25.16406f);
    }
    
}
