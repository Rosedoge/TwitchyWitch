using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAsset : MonoBehaviour
{

    public string eventName;
    public float startTime;
    public float timetocomplete;
    public enum timerType { potionPickup, potionBrew, herbGrow, travel };
    public timerType myType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timetocomplete -= Time.deltaTime;   
        if(timetocomplete <= 0)
        {
            GameManager.gm.CompleteTimer(this);
        }
    }

    public static TimerAsset TimerMake(GameObject obj, string eName, timerType type, float starttime, float timetoend)
    {
        TimerAsset ass = obj.AddComponent<TimerAsset>();
        ass.eventName = eName;
        ass.myType = type;
        ass.startTime = starttime;
        ass.timetocomplete = timetoend;
        return ass;
    }

}
