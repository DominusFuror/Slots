using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotStopSC : MonoBehaviour
{
    public GameObject[]  slots1 = new GameObject[4];
    public GameObject[]  slots2 = new GameObject[4];
    public GameObject[]  slots3 = new GameObject[4];
    public GameObject[]  slots4 = new GameObject[4];


    int vova = 5;
    [SerializeField]
    GameObject fon1;
    [SerializeField]
    GameObject fon2;
    [SerializeField]
    GameObject fon3;
    [SerializeField]
    GameObject fon4;


   public  bool firstWinCond;
    bool secondWinCond;
    bool thirdWinCond;
    bool fourthWinCond;

    KeyCode first;
    KeyCode second;
    KeyCode third;
    KeyCode fourth;

    bool BlockFirstKey = false;
    bool BlockSecondKey = false;
    bool BlockThirdKey = false;
    bool BlockFourthKey = false;

    void Start()
    {

        first = (KeyCode)(Enum.Parse(typeof(KeyCode), GameManager.FirstKey));
        second = (KeyCode)(Enum.Parse(typeof(KeyCode), GameManager.SecondKey));
        third = (KeyCode)(Enum.Parse(typeof(KeyCode), GameManager.ThirdKey));
        fourth = (KeyCode)(Enum.Parse(typeof(KeyCode), GameManager.FourthKey));




    }

    
    void Update()
    {

        if (Input.GetKeyDown(first) && !BlockFirstKey )
        {
            BlockFirstKey = true;
            for (int i = 0; i < 4; i++)
            {

               
                StartCoroutine(StopSlots(slots1));
           
            }
           

        }
        if (Input.GetKeyDown(second) && !BlockSecondKey)
        {
            BlockSecondKey = true;
            for (int i = 0; i < 4; i++)
            {


                StartCoroutine(StopSlots(slots2));

            }

        }
        if (Input.GetKeyDown(third) && !BlockThirdKey)
        {
            BlockThirdKey = true;
            for (int i = 0; i < 4; i++)
            {


                StartCoroutine(StopSlots(slots3));

            }

        }
        if (Input.GetKeyDown(fourth) && !BlockFourthKey)
        {
            BlockFourthKey = true;
            for (int i = 0; i < 4; i++)
            {


                StartCoroutine(StopSlots(slots4));

            }

        }

        if (firstWinCond && secondWinCond && thirdWinCond && fourthWinCond)
        {

            StartCoroutine(WinAnimation());
            BlockFirstKey = true;
            BlockSecondKey = true;
            BlockThirdKey = true;
            firstWinCond = false;

        }
    }


    IEnumerator WinAnimation()
    {

        foreach (var item in slots1)
        {
            Destroy(item.GetComponent<SlotMoveSC>());
            if (item.name != "Car")
            {
                StartCoroutine(HideSpriteRender(item));
            }
        }
        foreach (var item in slots2)
        {
            Destroy(item.GetComponent<SlotMoveSC>());
            if (item.name != "Car")
            {
                StartCoroutine(HideSpriteRender(item));
            }
        }
        foreach (var item in slots3)
        {
            Destroy(item.GetComponent<SlotMoveSC>());
            if (item.name != "Car")
            {
                StartCoroutine(HideSpriteRender(item));
            }
        }
        foreach (var item in slots4)
        {
            Destroy(item.GetComponent<SlotMoveSC>());
            if (item.name != "Car")
            {
                StartCoroutine(HideSpriteRender(item));
            }
        }
        var s = GameObject.FindGameObjectsWithTag("Lines");

        foreach (var item in s)
        {
            StartCoroutine(HideSpriteRender(item));
        }
        yield return new WaitForSeconds(5);
        var ss = GameObject.FindGameObjectsWithTag("Car");

        foreach (var item in ss)
        {
            StartCoroutine(MoveToWinPos(item));
        }

    }


    public GameObject winpose;
    public GameObject WinExp;
    IEnumerator MoveToWinPos(GameObject obj)
    {
        bool f = true;
        int i = 0;
        Vector3 moveVector = (winpose.transform.position - obj.transform.position) / 400;
        while (true)
        {

           
          
            i++;
            if (i == 100)
            {
                


                WinExp.SetActive(true);
                
            }
            if (i <= 400)
            {
                obj.transform.position += moveVector;
            }

            print(WinExp.GetComponent<ParticleSystem>().time);
          if (WinExp.GetComponent<ParticleSystem>().time >= 1.5f &&f  )
            {
                winpose.SetActive(true);
                Destroy(obj);
                f = false;
            }
            
            if (WinExp.GetComponent<ParticleSystem>().time >= 2.8f)
            {
             
                yield break;
            
            }

            yield return null;
        }





    }
    public void CheckSlot(string colonName)
    {


        if(colonName == "FirstColon")
        {
           var ray =   GameObject.Find("Ray1");
            RaycastHit raycastHit;
            var hitInfo =  Physics2D.Raycast(ray.transform.position, Vector2.zero);
            if(hitInfo.collider.gameObject.name == "Car")
            {
                StartCoroutine(  VictoryFon(fon1));
                firstWinCond = true;
                StartCoroutine(Win1FlagDelay());
            }
            else
            {
                StartCoroutine(DisableFirstButtonIfIncorrectTime());
                StartCoroutine(DefeatFon(fon1));
            }

        }

        if (colonName == "SecondColon")
        {
            var ray = GameObject.Find("Ray2");
            RaycastHit raycastHit;
            var hitInfo = Physics2D.Raycast(ray.transform.position, Vector2.zero);
            if (hitInfo.collider.gameObject.name == "Car")
            {
                StartCoroutine(VictoryFon(fon2));
                secondWinCond = true;
                StartCoroutine(Win2FlagDelay());
            }
            else
            {
                StartCoroutine(DisableSecondButtonIfIncorrectTime());
                StartCoroutine(DefeatFon(fon2));
            }

        }
        if (colonName == "ThirdColon")
        {
            var ray = GameObject.Find("Ray3");
            RaycastHit raycastHit;
            var hitInfo = Physics2D.Raycast(ray.transform.position, Vector2.zero);
            if (hitInfo.collider.gameObject.name == "Car")
            {
                StartCoroutine(VictoryFon(fon3));
                StartCoroutine(Win3FlagDelay());
                thirdWinCond = true;
            }
            else
            {
                StartCoroutine(DisableThirdButtonIfIncorrectTime());
                StartCoroutine(DefeatFon(fon3));
            }

        }
        if (colonName == "FourthColon")
        {
            var ray = GameObject.Find("Ray4");
            RaycastHit raycastHit;
            var hitInfo = Physics2D.Raycast(ray.transform.position, Vector2.zero);
            if (hitInfo.collider.gameObject.name == "Car")
            {
                StartCoroutine(VictoryFon(fon4));
                StartCoroutine(Win4FlagDelay());
                fourthWinCond = true;
            }
            else
            {
                StartCoroutine(DisableFourthButtonIfIncorrectTime());
                StartCoroutine(DefeatFon(fon4));
            }

        }



    }


     IEnumerator DisableFirstButtonIfIncorrectTime( )
    {
        BlockFirstKey = true;
        yield return new WaitForSeconds(GameManager.IncorrectTimeLocked);
        BlockFirstKey = false;
    }
    IEnumerator DisableSecondButtonIfIncorrectTime()
    {
        BlockSecondKey = true;
        yield return new WaitForSeconds(GameManager.IncorrectTimeLocked);
        BlockSecondKey = false;
    }
    IEnumerator DisableThirdButtonIfIncorrectTime()
    {
        BlockThirdKey = true;
        yield return new WaitForSeconds(GameManager.IncorrectTimeLocked);
        BlockThirdKey = false;
    }
    IEnumerator DisableFourthButtonIfIncorrectTime()
    {
        BlockFourthKey = true;
        yield return new WaitForSeconds(GameManager.IncorrectTimeLocked);
        BlockFourthKey = false;
    }

    IEnumerator HideSpriteRender(GameObject item)
    {

        SpriteRenderer sp = item.GetComponent<SpriteRenderer>();
        while (true)
        {

            sp.color -= (Color.white * (Time.deltaTime))/5;

            if (sp.color.a <= 0)
            {
                Destroy(sp.gameObject);
                yield break;
            }
            yield return null;
            

        }


    }
    IEnumerator VictoryFon(GameObject fon)
    {

        fon.gameObject.SetActive(true);
        fon.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0.75f, 1, 0.1f);

        yield return new WaitForSeconds(GameManager.CorrectTimeLocked);
        fon.gameObject.SetActive(false);
        var s = fon.transform.parent.GetComponentsInChildren<SlotMoveSC>();

        foreach (var item   in s)
        {
            item.enabled = true;
        }

        yield break;




    }
    IEnumerator Defeat1FlagDelay()
    {

        yield return new WaitForSeconds(GameManager.CorrectTimeLocked);
        firstWinCond = false;
        BlockFirstKey = false;

    }
    IEnumerator Win1FlagDelay()
    {

        yield return new WaitForSeconds(GameManager.CorrectTimeLocked);
        firstWinCond = false;
        BlockFirstKey = false;

    }
    IEnumerator Win2FlagDelay()
    {

        yield return new WaitForSeconds(GameManager.CorrectTimeLocked);
        secondWinCond = false;
        BlockSecondKey = false;
    }
    IEnumerator Win3FlagDelay()
    {

        yield return new WaitForSeconds(GameManager.CorrectTimeLocked);
        thirdWinCond = false;
        BlockThirdKey = false;
    }
    IEnumerator Win4FlagDelay()
    {

        yield return new WaitForSeconds(GameManager.CorrectTimeLocked);
        fourthWinCond = false;
        BlockFourthKey = false;
    }
    IEnumerator DefeatFon(GameObject fon)
    {

        fon.gameObject.SetActive(true);
        fon.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,0 , 0, 0.12f);

        yield return new WaitForSeconds(GameManager.IncorrectTimeLocked);
        fon.gameObject.SetActive(false);
        var s = fon.transform.parent.GetComponentsInChildren<SlotMoveSC>();

        foreach (var item in s)
        {
            item.enabled = true;
        }

        yield break;




    }

    IEnumerator StopSlots(GameObject[]  slots)
    {

        while (true)
        {
            for (int i = 0; i < 4; i++)
            {

                if(Math.Abs( slots[i].transform.localPosition.y + 7.05f) < 0.5f)
                {

                    for (int g = 0; g < 4; g++)
                    {
                        slots[g].GetComponent<SlotMoveSC>().enabled = false;
                      
                    }
                    CheckSlot(slots[0].transform.parent.name);
                    yield break;

                }




            }
            yield return null;
        
        }
  

    }
}
