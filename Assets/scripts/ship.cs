using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
#region Singleton
    public static ship instance;
    void Awake()
    {
        if(instance!=null)
        {
            Debug.LogWarning("More than one Invemtory instances");
            return;
        }
        instance=this;
    }
#endregion
    
    gameLogic GameLogic;
    AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound=GetComponent<AudioSource>();
        GameLogic=gameLogic.instance;
        Debug.Log(transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameLogic.state==0)
            sound.mute=true;
        if(GameLogic.state==1)
        {
            transform.rotation=new Quaternion(0,0,0,1);
            sound.mute=true;
        }
        if(GameLogic.state==2)
        {
            transform.Rotate(new Vector3(0,0,-5*GameLogic.wind*Time.deltaTime)); 
            sound.mute=false;
        }
        if(GameLogic.state==3)
            sound.mute=true;
        if(GameLogic.state==4)
            sound.mute=true;
    }
    public void rotateLeft()
    {
        Debug.Log("Left");
        //transform.rotation=new Quaternion(1f,0f,0f,3f);
        if(GameLogic.state==2)
            transform.Rotate(new Vector3(0,0,6));
    }
    public void rotateRight()
    {
        Debug.Log("Right");
        //transform.rotation=new Quaternion(1f,0f,0f,33f);
        if(GameLogic.state==2)
            transform.Rotate(new Vector3(0,0,-6));
    }
    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.CompareTag("LeftSide"))
            {
                Debug.Log("Left");
               gameLogic.instance.crash();
            }
            if (other.CompareTag("RightSide"))
            {
                Debug.Log("Right");
                gameLogic.instance.crash();
            }
           
    }

}
