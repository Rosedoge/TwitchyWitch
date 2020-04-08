using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] float speed = 5;
    public float inputDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 pos = transform.position;
        float horizontal = Input.GetAxis("Horizontal");
        pos.x += speed * inputDir * Time.deltaTime;
        transform.position = pos;
    }

    public void SetDirLeft()
    {
        inputDir = -1;
    }
    public void SetDirRight()
    {
        inputDir = 1;
    }
    public void StopDir()
    {
        inputDir = 0;
    }
}
