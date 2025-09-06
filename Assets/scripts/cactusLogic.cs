using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactusLogic : MonoBehaviour
{
    float pos;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(gameLogic.instance.state==2)
        {
            transform.Translate(Vector3.down*1f*Time.deltaTime);
            if(transform.position.y<=-7f)
                GameObject.Destroy(this);
        }
        
    }
}
