using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using System;

public class gameLogic : MonoBehaviour
{
#region Singleton
    public static gameLogic instance;
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
    public GameObject land;
    public GameObject land1;
    public GameObject land2;
    public GameObject land3;
    public GameObject land4;
    public GameObject land5;
    public GameObject land6;
    public GameObject land7;
    public GameObject land8;
    public GameObject land9;
    public GameObject land10;
    public GameObject land11;
    public GameObject land12;
    public GameObject land13;
    public GameObject land14;
    public GameObject land15;

    public GameObject leftWindA;
    public GameObject leftWindB;
    public GameObject leftWindC;
    public GameObject rightWindA;
    public GameObject rightWindB;
    public GameObject rightWindC;
    public GameObject crashedPanel;
    public GameObject adWatchedPanel;
    public GameObject countDownPanel;
    public GameObject diggedOutPanel;
    public GameObject windPanel;
    public GameObject distansPanel;
    public GameObject newGamePanel;
    public GameObject rulesPanel;
    public GameObject water;
    public GameObject cactus;
    public GameObject cactusFlower;
    public Text restTimeUi;
    public Text passedMeters;
    public Text countDownNumber;
    ship Ship;
    public float currentTime;
    public float randomAmount;
    public int wind=0; 
    public string waitingTime;
    public int Year=1000;
    public int Month=1;
    public int Day=1;
    public int Hour=0;
    public int Minutes=0;
    public int Seconds=0;
    public float meters;
    public float countDownF;
    public int state;
    public float pos;
    public float cactusCountDown;
    Quaternion Brotation;
    AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        if(Advertisement.isSupported)
        {
            Advertisement.Initialize("4073867",false);
        }
        sound=GetComponent<AudioSource>();
        /*land.transform.position=new Vector3(1.109428f,-6f,25.16406f);
        land2.transform.position=new Vector3(1.109428f,-5f,25.16406f);
        land3.transform.position=new Vector3(1.109428f,-4f,25.16406f);
        land4.transform.position=new Vector3(1.109428f,-3f,25.16406f);
        land5.transform.position=new Vector3(1.109428f,-2f,25.16406f);
        land6.transform.position=new Vector3(1.109428f,-1f,25.16406f);
        land7.transform.position=new Vector3(1.109428f,0f,25.16406f);
        land8.transform.position=new Vector3(1.109428f,1f,25.16406f);
        land9.transform.position=new Vector3(1.109428f,2f,25.16406f);
        land10.transform.position=new Vector3(1.109428f,3f,25.16406f);
        land11.transform.position=new Vector3(1.109428f,4f,25.16406f);
        land12.transform.position=new Vector3(1.109428f,5f,25.16406f);
        land13.transform.position=new Vector3(1.109428f,6f,25.16406f);
        land14.transform.position=new Vector3(1.109428f,7f,25.16406f);
        land15.transform.position=new Vector3(1.109428f,8f,25.16406f);*/
        Debug.Log(Application.persistentDataPath);
        Ship=ship.instance;
        string path = Application.persistentDataPath+"/saves.huy";
        if(File.Exists(path))
        {
            gameData data=SaveSystem.Load();
            Year=data.Year;
            Month=data.Month;
            Day=data.Day;
            Hour=data.Hour;
            Minutes=data.Minutes;
            Seconds=data.Seconds;
            meters=data.meters;
            state=data.state;
            passedMeters.text=Math.Floor(meters).ToString();
            if(state==4)
            {
                state=1;
            }
            if(state==2)
            {
                state=1;
            }
            if(state==1)
            {
                countDownF=5;
            }

        }
        else
        {
            state=0;
        }
       


        /*for(int i=-6; i<12; i++)
        {
            GameObject lands=GameObject.Instantiate(land);
            
            lands.transform.position=new Vector3(-2.3f,i,25.16406f);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if(wind==0)
        {
            leftWindA.SetActive(false);
            leftWindB.SetActive(false);
            leftWindC.SetActive(false);
            rightWindA.SetActive(false);
            rightWindB.SetActive(false);
            rightWindC.SetActive(false);
        }
        if(state==0)
        {
            sound.mute=false;
            windPanel.SetActive(false);
            distansPanel.SetActive(false);
            newGamePanel.SetActive(true);
        }
        if(state==1)
        {
            sound.mute=false;
            wind=0;
            if(countDownPanel.activeSelf==false)
                countDownPanel.SetActive(true);
            if(countDownF>0)
                countDownF-=1*Time.deltaTime;
            if(countDownF>2)
                countDownNumber.text=(Math.Floor(countDownF)-1.0f).ToString();
            else if(countDownF>0)
                countDownNumber.text="GO!";
            else
            {
                currentTime=4;
                wind=0;
                state=2;
            }
        }
        else
            countDownPanel.SetActive(false);
        if(state==2)
        {
            if(cactusCountDown<1)
                cactusCountDown+=1f*Time.deltaTime;
            else
            {
                cactusCountDown=0;
                Brotation=new Quaternion(0,0,0,1);
                pos=UnityEngine.Random.Range(-8f,15f);
                if(pos<1.5f | pos>5f)
                {
                    Instantiate(cactus,new Vector3(pos,8,1),Brotation);
                    Debug.Log("ok");
                }
                pos=UnityEngine.Random.Range(-8f,15f);
                if(pos<1.5f | pos>5f)
                {
                    Instantiate(cactusFlower,new Vector3(pos,8,1),Brotation);
                    Debug.Log("ok");
                }
            }
            /*if(currentTime==0 | currentTime==1 | currentTime==2 | currentTime==3 | currentTime==4 | currentTime==5)
            {
                pos=UnityEngine.Random.Range(-8,15);
                Brotation=new Quaternion(0,0,0,1);
                if(pos<1.5 & pos>5)
                    Instantiate(cactus,new Vector3(pos,8,1),Brotation);
            }*/
            sound.mute=false;
            meters+=1*Time.deltaTime;
            passedMeters.text=Math.Floor(meters).ToString();
            if(wind==-1)
            {
                leftWindA.SetActive(true);
                leftWindB.SetActive(false);
                leftWindC.SetActive(false);
                rightWindA.SetActive(false);
                rightWindB.SetActive(false);
                rightWindC.SetActive(false);
            }
            else if(wind==-2)
            {
                leftWindA.SetActive(false);
                leftWindB.SetActive(true);
                leftWindC.SetActive(false);
                rightWindA.SetActive(false);
                rightWindB.SetActive(false);
                rightWindC.SetActive(false);
            }
            else if(wind==-3)
            {
                leftWindA.SetActive(false);
                leftWindB.SetActive(false);
                leftWindC.SetActive(true);
                rightWindA.SetActive(false);
                rightWindB.SetActive(false);
                rightWindC.SetActive(false);
            }
            else if(wind==1)
            {
                leftWindA.SetActive(false);
                leftWindB.SetActive(false);
                leftWindC.SetActive(false);
                rightWindA.SetActive(true);
                rightWindB.SetActive(false);
                rightWindC.SetActive(false);
            }
            else if(wind==2)
            {
                leftWindA.SetActive(false);
                leftWindB.SetActive(false);
                leftWindC.SetActive(false);
                rightWindA.SetActive(false);
                rightWindB.SetActive(true);
                rightWindC.SetActive(false);
            }
            else if(wind==3)
            {
                leftWindA.SetActive(false);
                leftWindB.SetActive(false);
                leftWindC.SetActive(false);
                rightWindA.SetActive(false);
                rightWindB.SetActive(false);
                rightWindC.SetActive(true);
            }


            if(currentTime<5)
                currentTime+=1f*Time.deltaTime;
            else
            {
                
                currentTime=0;
                randomAmount=UnityEngine.Random.Range(0.0f,1.0f);
                /*if (wind==0)
                {
                    if(randomAmount<0.5)
                        wind-=1;
                    else
                        wind+=1;
                }
                else if(wind==3)
                {
                    if(randomAmount<0.5)
                        wind-=1;
                    else
                        wind-=0;
                } 
                else if(wind==-3)
                {
                    if(randomAmount<0.5)
                        wind+=0;
                    else
                        wind+=1;
                }
                else if(wind==1)
                {
                    if(randomAmount<0.5)
                        wind-=2;
                    else
                        wind+=1;
                }
                else if(wind==-1)
                {
                    if(randomAmount<0.5)
                        wind-=1;
                    else
                        wind+=2;
                }       
                else
                {
                    if(randomAmount<0.33)
                        wind-=1;
                    else if(randomAmount>0.66)
                        wind+=1;
                    else
                        wind+=0;
                }*/
                if(randomAmount<1.0f/6 & randomAmount>0.0f)
                {
                    wind=-3;
                }
                else if(randomAmount<2*1.0f/6 & randomAmount>1.0f/6)
                {
                    wind=-2;
                }
                else if(randomAmount<3*1.0f/6 & randomAmount>2*1.0f/6)
                {
                    wind=-1;
                }
                else if(randomAmount<4*1.0f/6 & randomAmount>+3*1.0f/6)
                {
                    wind=1;
                }
                else if(randomAmount<5*1.0f/6 & randomAmount>4*1.0f/6)
                {
                    wind=2;
                }
                else if(randomAmount<1.0f & randomAmount>5*1.0f/6)
                {
                    wind=3;
                }
                else
                {
                    wind=0;
                }
            }
        }
        if(state==3)
        {
            sound.mute=false;
            if(crashedPanel.activeSelf==false)
            {
                crashedPanel.SetActive(true);
                if(Year==1000)
                {
                    Year=System.DateTime.Now.AddDays(6).Year;
                    Month=System.DateTime.Now.AddDays(6).Month;
                    Day=System.DateTime.Now.AddDays(6).Day;
                    Hour=System.DateTime.Now.AddDays(6).Hour;
                    Minutes=System.DateTime.Now.AddDays(6).Minute;
                    Seconds=System.DateTime.Now.AddDays(6).Second;
                    var dateOfRescue=new System.DateTime(Year,Month,Day,Hour,Minutes,Seconds);
                }
                SaveSystem.Save(this);
            }
            var rescueDate=new System.DateTime(Year,Month,Day,Hour,Minutes,Seconds);
            if(rescueDate.CompareTo(System.DateTime.Now)>0)
            {
                var restTime=rescueDate.Subtract(System.DateTime.Now);
                waitingTime=restTime.Days+"D:"+restTime.Hours+"H:"+restTime.Minutes+"M:"+restTime.Seconds+"S";
                restTimeUi.text=waitingTime;
            }
            else
            {
                state=4;
                Year=1000;
                Month=1;
                Day=1;
                Hour=0;
                Minutes=0;
                Seconds=0;
                crashedPanel.SetActive(false);
                diggedOutPanel.SetActive(true);
            }
        }
        
        //Debug.Log(rescueDate.CompareTo(System.DateTime.Now));
        
        
        //waitingTime=restTime
        //Debug.Log(waitingTime);
        
    }
    public void crash()
    {
        state=3;          
    }
    public void adsWatching()
    {

        if(Advertisement.IsReady())
        {
            Advertisement.Show("Rewarded_Android");
        }
        state=4;
        crashedPanel.SetActive(false);
        adWatchedPanel.SetActive(true);
        Year=1000;
        Month=1;
        Day=1;
        Hour=0;
        Minutes=0;
        Seconds=0;
    }
    public void adsWatched()
    {
        adWatchedPanel.SetActive(false);
        countDownF=5;
        state=1;
    }
    public void diggedOut()
    {
        diggedOutPanel.SetActive(false);
        countDownF=5;
        state=1;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void newGame()
    {    
        rulesPanel.SetActive(true);
        newGamePanel.SetActive(false);
    }
    public void rulesRead()
    {
        newGamePanel.SetActive(false);
        windPanel.SetActive(true);
        distansPanel.SetActive(true);
        rulesPanel.SetActive(false);
        meters=0;
        wind=0;
        state=1;
        countDownF=5;
        passedMeters.text=meters.ToString();
    }
    void OnApplicationQuit()
    {
        if(state!=0)
            SaveSystem.Save(this);
    }
}
