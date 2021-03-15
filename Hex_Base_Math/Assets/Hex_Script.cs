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
        if(object_on_space != null)
        {
            //if (turned == false)
            //{
                checkVis();
            //    turned = true;
            //}
        }
        else
        {
            if(vis.Count > 0)
            {
                HexRender.material.color = new Color(Color.yellow.r, Color.yellow.g, Color.yellow.b, Color.yellow.a);
            }
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

    void checkVis()
    {
        if (object_on_space.viewDist > 0)
        {
            //print(vis.Count);
            int viewDist = object_on_space.viewDist;
            //print("view distance:");
            //print(viewDist);

            int leftAngle = (dir - 1) % 6;
            if(leftAngle < 0)
            {
                leftAngle += 6;
            }
            //print("left angle:");
            //print(leftAngle);
            int rightAngle = (dir + 1) % 6;
            if(rightAngle > 5)
            {
                rightAngle -= 6;
            }
            //print("right angle:");
            //print(rightAngle);
            Hex_Script leftRange = surr_tiles[leftAngle];
            //print("left range: ");
            //print(leftRange);
            if (leftRange != null)
            {
                leftRange.setVis(this);
            }
            Hex_Script rightRange = surr_tiles[rightAngle];
            //print("right range: ");
            //print(rightRange);
            if (rightRange != null)
            {
                rightRange.setVis(this);
            }
            Hex_Script centerRange = surr_tiles[dir];
            //print("center range: ");
            //print(centerRange);
            if (centerRange != null)
            {
                centerRange.setVis(this);
            }
            for(int i = 1; i < viewDist; i++)
            {
                Hex_Script tempLeft = leftRange.surr_tiles[leftAngle];
                leftRange = tempLeft;
                //print("left range: ");
                //print(leftRange);
                if (leftRange != null)
                {
                    leftRange.setVis(this);
                }
                Hex_Script tempRight = rightRange.surr_tiles[rightAngle];
                rightRange = tempRight;
                //print("right range: ");
                //print(rightRange);
                if (rightRange != null)
                {
                    rightRange.setVis(this);
                }
                Hex_Script tempCenter = centerRange.surr_tiles[dir];
                centerRange = tempCenter;
                //print("center range: ");
                //print(centerRange);
                if (centerRange != null)
                {
                    centerRange.setVis(this);
                }
                Hex_Script betweenRight = null;
                Hex_Script betweenLeft = null;
                int betweenDirRight = (dir + 2) % 6; if (betweenDirRight > 5) { betweenDirRight -= 6; }
                int betweenDirLeft = (dir - 2) % 6; if (betweenDirLeft < 0) { betweenDirLeft += 6; }                
                if (centerRange != null)
                {
                    betweenLeft = centerRange.surr_tiles[betweenDirLeft];
                    betweenRight = centerRange.surr_tiles[betweenDirRight];
                }
                                   
                for (int j = 0; j < i; j++)
                {
                    ///betweenRight
                    if (betweenRight != null)
                    {
                        betweenRight.setVis(this);
                    }
                    //print("betweenRight pos = ");
                    //print(betweenRight.pos);  

                    ///betweenLeft
                    if (betweenLeft != null)
                    {
                        betweenLeft.setVis(this);
                    }
                    //print("betweenLeft pos = ");
                    //print(betweenLeft.pos);

                    //set for next loop
                    if (betweenRight != null)
                    {
                        betweenRight = betweenRight.surr_tiles[betweenDirRight];
                    }
                    if (betweenLeft != null)
                    {
                        betweenLeft = betweenLeft.surr_tiles[betweenDirLeft];
                    }
                }
            }
        }
    }
}
