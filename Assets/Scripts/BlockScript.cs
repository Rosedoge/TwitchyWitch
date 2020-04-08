using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BlockScript : MonoBehaviour
{
    public int hash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MyClick(Sprite[] blockImgs, int val)
    {
         //GetComponent<Image>().sprite = blockImgs[val];
        if (val == 0 && hash != 1)
        {
            hash = 1;
            GetComponent<Image>().sprite = blockImgs[val];
        }


        if (val == 1 && hash != 0)
        {
            hash = 0;
            GetComponent<Image>().sprite = blockImgs[val];
        }

        if (val == 2 && hash!=2)
        {
            hash = 2;
            GetComponent<Image>().sprite = blockImgs[val];
        }

    }
}
