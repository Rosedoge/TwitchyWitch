using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToCameraScript : MonoBehaviour
{
    public static FlyToCameraScript fly = null;
    [SerializeField] Camera mainCamera;
    Vector2 previousPosition;
    [SerializeField] float speed = 5;

    //Vector3 m_centerPosition;
    //float m_degrees;

    //[SerializeField]
    //float m_speed = 1.0f;

    //[SerializeField]
    //float m_amplitude = 1.0f;

    //[SerializeField]
    //float m_period = 1.0f;

    private void Awake()
    {
        if (fly == null)
        {
            fly = this;

        }
        else if (fly != this)
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
        
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        //// Update degrees
        //float degreesPerSecond = 360.0f / m_period;
        //m_degrees = Mathf.Repeat(m_degrees + (Time.deltaTime * degreesPerSecond), 360.0f);
        //float radians = m_degrees * Mathf.Deg2Rad;

        //// Offset by sin wave
        //Vector3 offset = new Vector3(0.0f, m_amplitude * Mathf.Sin(radians), 0.0f);
        //transform.position = m_centerPosition + offset;

        //float step = speed * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(transform.position, mainCamera.gameObject.transform.position, step);
        //m_centerPosition = transform.position;

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButton(0))
        {
            Debug.Log("Touch");
            Ray ray;
            // create ray from the camera and passing through the touch position
            try
            {
                 ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                // and perpendicular to world Y:
                Plane plane = new Plane(Vector3.up, transform.position);
                float distance = 0; // this will return the distance from the camera
                if (plane.Raycast(ray, out distance))
                { // if plane hit...
                    Vector3 pos = ray.GetPoint(distance); // get the point
                                                          // pos has the position in the plane you've touched
                    transform.position = Vector2.MoveTowards(transform.position, pos, speed);
                }
            }
            catch(Exception e)
            {
                transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), speed*Time.deltaTime);
                Vector2 lockHeight = transform.position;
                lockHeight.y = -2.46f;
                transform.position = lockHeight;    
            }
            // create a logical plane at this object's position

           
        }

        if (previousPosition.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (previousPosition.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        previousPosition = transform.position;
    }
}
