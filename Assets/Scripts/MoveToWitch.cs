using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float step = 15 * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, FlyToCameraScript.fly.transform.position, step);
        Vector3 temp = transform.position;
        temp.z = -10f;
        temp.y = 0;
        transform.position = temp;
    }
}
