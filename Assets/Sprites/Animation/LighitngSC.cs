using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighitngSC : MonoBehaviour
{
    public int min;
    public int max;
    TextMesh text;
    int step = 1;
    void Start()
    {
        text = this.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    float timer = 0;

    void Update()
    {
     
            text.color = text.color - new Color(0, 0, 0, 1/255f * step);

            if (text.color.a >= max / 255f)
            {
                step *= -1;
            }
            if (text.color.a <= min / 255f)
            {
                step *= -1;
            }
        
        

    }
}
