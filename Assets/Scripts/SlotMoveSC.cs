using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMoveSC : MonoBehaviour
{
   
    void Start()
    {
        
    }

    Vector3 dir = new Vector2(0, -1);
    public int numOfSlot;
    void Update()
    {
        if (numOfSlot == 1)
        {
            this.transform.position += dir * Time.deltaTime * GameManager.firstColonSpeed;
        }
        if (numOfSlot == 2)
        {
            this.transform.position += dir * Time.deltaTime * GameManager.secondColonSpeed;
        }
        if (numOfSlot == 3)
        {
            this.transform.position += dir * Time.deltaTime * GameManager.thirdColonSpeed;
        }
        if (numOfSlot == 4)
        {
            this.transform.position += dir * Time.deltaTime * GameManager.fourthColonSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.transform.position += new Vector3(0, 42, 0);

    }
}
