using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;


using Dialogue;
public class TextController : MonoBehaviour
{

    public DialogueGraph curDGraph;
    [SerializeField] Image charFace;
    [SerializeField] Button answer1, answer2, answer3;
    [SerializeField] GameObject textbox;
    public static TextController tc = null;
    bool writing = false;
    List<string> textsToDisplay;
    [SerializeField] int DisplayTime = 10;
    string curStr = "";
    

    void Awake()
    {
        if(tc == null)
        {
            tc = this;
        }
        else if (tc != this)
        {

            //Then destroy this. This enforces our singleton pattern, 
            // meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        }
        //Sets this to not be destroyed when reloading scene / Switching scenes
        DontDestroyOnLoad(gameObject); // VERY IMPORTANT
        //textbox = GameObject.FindGameObjectWithTag("TCText");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadTheFirstChatOnTheGraph()
    {
        curDGraph.Restart();
        Chat chatNode = curDGraph.current;
        textbox.GetComponent<Text>().text = chatNode.text;
        foreach(Chat.Answer ans in chatNode.answers)
        {
            
        }
        charFace.sprite = chatNode.charFace;
    }

    public void TextInsert(string str)
    {
        textbox.GetComponent<Text>().text = str;
    }
    public void TextInsert(string[] texts)
    {
        if (!writing)
        {
            textbox.SetActive(true);
            writing = true;
            textsToDisplay = texts.ToList();
            Debug.Log("Line 1 " + textsToDisplay[0]);
            StartCoroutine(AnimateText(textsToDisplay[0]));
        }
    }

    IEnumerator AnimateText(string strComplete)
    {
        int i = 0;
        curStr = "";
        while (i < strComplete.Length)
        {
            curStr += strComplete[i++];
            textbox.GetComponent<Text>().text = curStr;
            yield return new WaitForSeconds(0.15F);
        }
        //Invoke("NextLine", 2.5f);
    }

    public void NextLine()
    {
        
        //GameObject but = EventSystem.current.currentSelectedGameObject;
        if(textbox.GetComponent<Text>().text == textsToDisplay[0])
        {
            if (textsToDisplay.Count > 1)
            {
                textsToDisplay.RemoveAt(0);
                StartCoroutine(AnimateText(textsToDisplay[0]));
            }
            else
            {
                textbox.GetComponent<Text>().text = "";
                textbox.SetActive(false);
                writing = false;
            }
        }
        else
        {
            StopCoroutine("AnimateText");
            textbox.GetComponent<Text>().text = textsToDisplay[0];
        }

    }

}
