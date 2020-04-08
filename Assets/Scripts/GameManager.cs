using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
public class GameManager : MonoBehaviour
{

    DateTime currentDate;
    DateTime oldDate;

    public float loadedTime = 0;

    public static GameManager gm = null;
    public List<TimerAsset> curTimers;
    [SerializeField] TimeableObject nono;

    [SerializeField] GameObject nonoCanvas;
    private void Awake()
    {
        if (gm == null)
        {
            gm = this;

        }
        else if (gm != this)
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
        //Store the current time when it starts
        currentDate = System.DateTime.Now;
        string line1 = "0";
        TextAsset level = Resources.Load<TextAsset>("test");
        using (StreamReader sr = new StreamReader(new MemoryStream(level.bytes))) { 
            line1 = sr.ReadLine(); // gets the first line from file.
            sr.Close();
        }
        //Grab the old time from the player prefs as a long
        long temp = Convert.ToInt64(line1);

        //Convert the old time from binary to a DataTime variable
        DateTime oldDate = DateTime.FromBinary(temp);
        print("oldDate: " + oldDate);

        //Use the Subtract method and store the result as a timespan variable
        TimeSpan difference = currentDate.Subtract(oldDate);
        print("Difference: " + difference);

       // SaveManager.sm.LoadGame();
        TextController.tc.TextInsert("Loadgame");
      //  StartCoroutine(BadFunc());
    }

    private IEnumerator BadFunc()
    {
        yield return new WaitForSeconds(2);

        bool text = BlockController.bc.GenerateTotalNono(nono);
        //TextController.tc.ReadTheFirstChatOnTheGraph();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            // TimerAsset asset = TimerAsset.TimerMake(gameObject, "potionBrew", TimerAsset.timerType.potionBrew, Time.time, 15);
            // CreateTimerAsset(asset);
            //string[] beepboop = { "Hello Witch!!!", "How are you?", " I am Fine!" };
            TextController.tc.ReadTheFirstChatOnTheGraph();

        }
    }

    public void CreateTimerAsset(TimerAsset asset)
    {
        curTimers.Add(asset);

    }

    void OnApplicationQuit()
    {
        ////Savee the current system time as a string in the player prefs class
        ////PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());
        SaveManager.sm.SaveGame(DateTime.Now.ToBinary().ToString(), curTimers.ToArray());
        ////print("Saving this date to prefs: " + System.DateTime.Now);
    }

    public void CompleteTimer(TimerAsset timer)
    {
        
        curTimers.Remove(timer);
        Destroy(timer);
    }
}
