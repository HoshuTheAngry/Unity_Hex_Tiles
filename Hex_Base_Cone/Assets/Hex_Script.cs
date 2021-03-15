using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex_Script : MonoBehaviour
{
    public Vector3 pos;
    public Hex_Script[] surr_tiles = new Hex_Script[6];
    public Player_Script object_on_space;
    int dir;
    Material mat;
    Renderer HexRender;
    Shader HexShader;
    List<Hex_Script> vis = new List<Hex_Script>();

    // Start is called before the first frame update
    void Start()
    {
        HexRender = GetComponent<Renderer>();
        if(object_on_space != null)
        {
            dir = object_on_space.dir;
            //print(dir);
            //print(HexShader);
            if (HexRender != null)
            {
                HexRender.material.color = new Color(Color.green.r, Color.green.g, Color.green.b, Color.green.a);
            }
        }
    }

    // Update is called once per frame
    bool turned = false;
    public void hexUpdate()
    {

        if (vis.Count > 0)
        {
            HexRender.material.color = new Color(Color.cyan.r, Color.cyan.g, Color.cyan.b, Color.cyan.a);
        }
        
    }

    int setVis(Hex_Script newVis)
    {
        if (this.vis.Contains(newVis) == false)
        {
            this.vis.Add(newVis);
            return 1;
        }
        return 0;
    }
}
