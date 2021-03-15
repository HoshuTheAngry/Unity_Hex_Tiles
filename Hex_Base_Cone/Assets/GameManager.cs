using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Dictionary<Vector3, Hex_Script> tileList;
    Player_Script[] players;
    Player_Script[] enemies;
    List<KeyValuePair<Player_Script, Hex_Script>> turnorder;

    // Start is called before the first frame update
    void Start()
    {
        //init of tileList
        tileList = new Dictionary<Vector3, Hex_Script>();

        Hex_Script[] startHexes = Object.FindObjectsOfType<Hex_Script>();
        print(startHexes.Length);
        for(int i = 0; i < startHexes.Length - 1; i++)
        {
            Hex_Script curHex = startHexes[i];
            Vector3 pos = curHex.pos;
            //print(pos);
            //print(curHex);
            tileList.Add(pos, curHex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Vector3 key in tileList.Keys)
        {
            tileList[key].hexUpdate();
        }
    }
}
