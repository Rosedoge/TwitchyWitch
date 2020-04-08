using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxObject : MonoBehaviour
{
    public float objHeight, objWidth;
    bool testing = false, making = false;
    Vector3[] array;
    float halfWidth, halfHeight;
    // Start is called before the first frame update
    void Start()
    {
        Sprite sp = GetComponent<SpriteRenderer>().sprite;
        array = SpriteLocalToWorld(sp);
        objHeight = GetComponent<SpriteRenderer>().size.y;
        objWidth = GetComponent<SpriteRenderer>().size.x;
        halfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 4;
        halfHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 witchLoc = FlyToCameraScript.fly.gameObject.transform.position;
        Debug.Log("Witch pos " + witchLoc.x + "    halfWidth = " + halfWidth);
        if (testing && !making)
        {

            
            if (witchLoc.x > transform.position.x - halfWidth*3)
            {
                ParallaxController.pax.SpawnNewArea(gameObject, false);
                making = true;
            }
            if (witchLoc.x < transform.position.x +halfWidth)
            {
                ParallaxController.pax.SpawnNewArea(gameObject, true);
                making = true;
            }
            
        }
        else // we need the witch in front of us
        {
           
            if(witchLoc.x >= array[0].x && witchLoc.x <= array[1].x)
            {
                testing = true;
            }
        }
    }
    Vector3[] SpriteLocalToWorld(Sprite sp)
    {
        Vector3 pos = transform.position;
        Vector3[] array = new Vector3[2];
        //top left
        array[0] = pos + sp.bounds.min;
        // Bottom right
        array[1] = pos + sp.bounds.max;
        return array;
    }
}
