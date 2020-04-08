using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public static ParallaxController pax = null;

    private void Awake()
    {
        if(pax == null)
        {
            pax = this;

        }
        else if (pax != this)
        {

            //Then destroy this. This enforces our singleton pattern, 
            // meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        }
        //Sets this to not be destroyed when reloading scene / Switching scenes
        DontDestroyOnLoad(gameObject); // VERY IMPORTANT
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// LR = false is left, true is right
    /// </summary>
    /// <param name="MapPart"></param>
    /// <param name="LR"></param>
    public void SpawnNewArea(GameObject MapPart, bool LR)
    {
        GameObject temp = Instantiate(MapPart, MapPart.transform.position, MapPart.transform.rotation);
        if (temp.gameObject.name.Contains("ground"))
        {
            if (LR == false)
            {
                Vector2 meep = MapPart.transform.position; // + 19x
                meep.x -= 19;
                temp.transform.position = meep;
            }
            else if (LR == true)
            {
                Vector2 meep = MapPart.transform.position; // + 19x
                meep.x += 19;
                temp.transform.position = meep;
            }

        }
        if (temp.gameObject.name.Contains("trees"))
        {
            if (LR == false)
            {
                Vector2 meep = MapPart.transform.position; // + 19x
                meep.x -= 38;
                temp.transform.position = meep;
            }
            else if (LR == true)
            {
                Vector2 meep = MapPart.transform.position; // + 19x
                meep.x += 38;
                temp.transform.position = meep;
            }
           
        }
        if (temp.gameObject.name.Contains("mountain"))
        {
            if (LR == false)
            {
                Vector2 meep = MapPart.transform.position; // + 19x
                meep.x -= 38;
                temp.transform.position = meep;
            }
            else if (LR == true)
            {
                Vector2 meep = MapPart.transform.position; // + 19x
                meep.x += 38;
                temp.transform.position = meep;
            }

        }
        if (temp.gameObject.name.Contains("cloud"))
        {
            if (LR == false)
            {
                Vector2 meep = MapPart.transform.position; // + 19x
                meep.x -= 81;
                temp.transform.position = meep;
            }
            else if (LR == true)
            {
                Vector2 meep = MapPart.transform.position; // + 19x
                meep.x += 81;
                temp.transform.position = meep;
            }

        }
        if (temp.gameObject.name.Contains("sky"))
        {
            if (LR == false)
            {
                Vector2 meep = MapPart.transform.position; // + 19x
                meep.x -= 95;
                temp.transform.position = meep;
            }
            else if (LR == true)
            {
                Vector2 meep = MapPart.transform.position; // + 19x
                meep.x += 95;
                temp.transform.position = meep;
            }

        }
    }
}
