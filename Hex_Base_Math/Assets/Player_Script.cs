using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public int viewDist = 1;
    public int moveDist = 5;
    public int dir = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.Rotate(0.0f, 0.0f, (float)dir * -60.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
