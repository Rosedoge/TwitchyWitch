using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class SaveManager : MonoBehaviour
{

    public static SaveManager sm = null;
    public List<TimerAsset> curTimers;
    static public List<GameObject> timerBases = new List<GameObject>();


    private void Awake()
    {
        if (sm == null)
        {
            sm = this;

        }
        else if (sm != this)
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



    public void SaveGame(string time, TimerAsset[] assets)
    {
       // string path = "Assets/Resources/test.txt";
        TextAsset level = Resources.Load<TextAsset>("test");
       
        string line = "";
        //Write some text to the test.txt file
        using (StreamReader sr = new StreamReader(new MemoryStream(level.bytes)))
        {

            line = sr.ReadLine();
            sr.Close();
        }
        string[] bad = { };
        if (line != null)
            bad = line.Split(' ');
        


        StreamWriter writer = new StreamWriter(new MemoryStream(level.bytes));
        if (bad.Length<1) {
            writer.WriteLine(time);
        }
          
        foreach (TimerAsset oneAsset in assets)
        {
            writer.WriteLine(oneAsset.eventName + " " + oneAsset.myType.ToString() + " " + oneAsset.startTime + " " + oneAsset.timetocomplete);
        }
       
        
        writer.Close();

        //Re-import the file to update the reference in the editor
        
        TextAsset asset = (TextAsset)Resources.Load("test");

        //Print the text from the file
        Debug.Log(asset.text);
    }

    static void WriteString()
    {
       
    }

    /// <summary>
    /// File Structure Firstline: stop time, Rest is timers to be loaded
    /// Timer Save Structure
    /// Name (?)    
    /// Type
    /// TimeStart
    /// TimetoFinish
    /// </summary>
    public void LoadGame()
    {
        int obligCounter = 0;
        string path = "Assets/Resources/test.txt";
        //string line;
        TextAsset level = Resources.Load<TextAsset>("test");
        //Read the text from directly from the test.txt file
        using (StreamReader sr = new StreamReader(new MemoryStream(level.bytes)))
        {
            for (string line = sr.ReadLine();
                line != null;
                line = sr.ReadLine())
            {

                // Debug.Log("Line = " + line);
                if (obligCounter == 0) //first line = time
                {
                    GameManager.gm.loadedTime = float.Parse(line);
                    obligCounter += 1;
                }
                else
                {
                    string[] segments = line.Split(' ');
                    GameObject newTimer;
                    if (segments.Length >= 2)
                    {
                        // Debug.Log(line);
                        switch (segments[1])
                        {
                            case "potionPickup":
                                newTimer = Instantiate(timerBases[0], transform.position, transform.rotation);
                                newTimer.GetComponent<TimerAsset>().eventName = segments[0];
                                newTimer.GetComponent<TimerAsset>().startTime = float.Parse(segments[2]);
                                newTimer.GetComponent<TimerAsset>().timetocomplete = float.Parse(segments[3]);
                                newTimer.GetComponent<TimerAsset>().myType = TimerAsset.timerType.potionPickup;
                                GameManager.gm.curTimers.Add(newTimer.GetComponent<TimerAsset>());
                                break;
                            case "potionBrew":
                                // Debug.Log("Potion Brew");
                                TimerAsset timer = TimerAsset.TimerMake(GameManager.gm.gameObject, "potionBrew", TimerAsset.timerType.potionBrew,
                                    float.Parse(segments[2]), float.Parse(segments[3]));
                                //newTimer = Instantiate(timerBases[0], transform.position, transform.rotation);
                                //newTimer.GetComponent<TimerAsset>().eventName = segments[0];
                                //newTimer.GetComponent<TimerAsset>().startTime = float.Parse(segments[2]);
                                //newTimer.GetComponent<TimerAsset>().timetocomplete = float.Parse(segments[3]);
                                //newTimer.GetComponent<TimerAsset>().myType = TimerAsset.timerType.potionBrew;
                                GameManager.gm.curTimers.Add(timer);
                                break;
                            case "herbGrow":
                                newTimer = Instantiate(timerBases[0], transform.position, transform.rotation);
                                newTimer.GetComponent<TimerAsset>().eventName = segments[0];
                                newTimer.GetComponent<TimerAsset>().startTime = float.Parse(segments[2]);
                                newTimer.GetComponent<TimerAsset>().timetocomplete = float.Parse(segments[3]);
                                newTimer.GetComponent<TimerAsset>().myType = TimerAsset.timerType.herbGrow;
                                GameManager.gm.curTimers.Add(newTimer.GetComponent<TimerAsset>());
                                break;
                            case "travel":
                                newTimer = Instantiate(timerBases[0], transform.position, transform.rotation);
                                newTimer.GetComponent<TimerAsset>().eventName = segments[0];
                                newTimer.GetComponent<TimerAsset>().startTime = float.Parse(segments[2]);
                                newTimer.GetComponent<TimerAsset>().timetocomplete = float.Parse(segments[3]);
                                newTimer.GetComponent<TimerAsset>().myType = TimerAsset.timerType.travel;
                                GameManager.gm.curTimers.Add(newTimer.GetComponent<TimerAsset>());
                                break;
                            default:

                                break;
                        }
                    }

                }
                // System.Console.WriteLine(line);
                //Debug.Log(line);
            }
           // reader.Close();
        }
       

        // 
        DeleteFile(path);
    }

    void DeleteFile(string path)
    {
        File.WriteAllText(path, "");
        //File.Delete(path);
    }

}
