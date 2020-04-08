using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BlockController : MonoBehaviour
{

    public static BlockController bc = null;
    private float _currentScale = InitScale;
    private const float TargetScale = 1;
    private const float InitScale = 0.1f;
    private const int FramesCount = 100;
    private const float AnimationTimeSeconds = 2;
    private float _deltaTime = AnimationTimeSeconds / FramesCount;
    private float _dx = (TargetScale - InitScale) / FramesCount;

    //components
    [SerializeField] Texture tex;
    [SerializeField] Image winImage;
    [SerializeField] Sprite[] buttonImg;
    [SerializeField] Button blackButton, SafeButton;
    [SerializeField] GameObject nonoBlock, columnP, rowP;
    [SerializeField] Sprite[] blockImgs;
    [SerializeField] GameObject[,] blocks;
    [SerializeField] GameObject[] blocksrow0, blocksrow1, blocksrow2, blocksrow3, blocksrow4, blocksrow5, blocksrow6, blocksrow7, blocksrow8, blocksrow9;
    [SerializeField] public  List<TimeableObject> nonoImages;

    [SerializeField] GameObject[] rows, columns;
    [SerializeField] GameObject selected;
    [SerializeField] GameObject buttonHolder;
    int[,] answerkey;
    void Awake()
    {

        if (bc == null)
        {
            bc = this;

        }
        else if (bc != this)
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
        answerkey = new int[10, 10];
        blocks = new GameObject[10, 10];
        GameObject[] blockz = new GameObject[110];
        //GenerateNonogramLayout();
        blockz = GameObject.FindGameObjectsWithTag("Nonoblock");
        int counter = 0;
        int i = 0;
        blocks[i, 0] = blocksrow0[0];
        blocks[i, 1] = blocksrow0[1];
        blocks[i, 2] = blocksrow0[2];
        blocks[i, 3] = blocksrow0[3];
        blocks[i, 4] = blocksrow0[4];
        blocks[i, 5] = blocksrow0[5];
        blocks[i, 6] = blocksrow0[6];
        blocks[i, 7] = blocksrow0[7];
        blocks[i, 8] = blocksrow0[8];
        blocks[i, 9] = blocksrow0[9];
        i = 1;
        blocks[i, 0] = blocksrow1[0];
        blocks[i, 1] = blocksrow1[1];
        blocks[i, 2] = blocksrow1[2];
        blocks[i, 3] = blocksrow1[3];
        blocks[i, 4] = blocksrow1[4];
        blocks[i, 5] = blocksrow1[5];
        blocks[i, 6] = blocksrow1[6];
        blocks[i, 7] = blocksrow1[7];
        blocks[i, 8] = blocksrow1[8];
        blocks[i, 9] = blocksrow1[9];
        i = 2;
        blocks[i, 0] = blocksrow2[0];
        blocks[i, 1] = blocksrow2[1];
        blocks[i, 2] = blocksrow2[2];
        blocks[i, 3] = blocksrow2[3];
        blocks[i, 4] = blocksrow2[4];
        blocks[i, 5] = blocksrow2[5];
        blocks[i, 6] = blocksrow2[6];
        blocks[i, 7] = blocksrow2[7];
        blocks[i, 8] = blocksrow2[8];
        blocks[i, 9] = blocksrow2[9];
        i = 3;
        blocks[i, 0] = blocksrow3[0];
        blocks[i, 1] = blocksrow3[1];
        blocks[i, 2] = blocksrow3[2];
        blocks[i, 3] = blocksrow3[3];
        blocks[i, 4] = blocksrow3[4];
        blocks[i, 5] = blocksrow3[5];
        blocks[i, 6] = blocksrow3[6];
        blocks[i, 7] = blocksrow3[7];
        blocks[i, 8] = blocksrow3[8];
        blocks[i, 9] = blocksrow3[9];
        i = 4;
        blocks[i, 0] = blocksrow4[0];
        blocks[i, 1] = blocksrow4[1];
        blocks[i, 2] = blocksrow4[2];
        blocks[i, 3] = blocksrow4[3];
        blocks[i, 4] = blocksrow4[4];
        blocks[i, 5] = blocksrow4[5];
        blocks[i, 6] = blocksrow4[6];
        blocks[i, 7] = blocksrow4[7];
        blocks[i, 8] = blocksrow4[8];
        blocks[i, 9] = blocksrow4[9];
        i = 5;
        blocks[i, 0] = blocksrow5[0];
        blocks[i, 1] = blocksrow5[1];
        blocks[i, 2] = blocksrow5[2];
        blocks[i, 3] = blocksrow5[3];
        blocks[i, 4] = blocksrow5[4];
        blocks[i, 5] = blocksrow5[5];
        blocks[i, 6] = blocksrow5[6];
        blocks[i, 7] = blocksrow5[7];
        blocks[i, 8] = blocksrow5[8];
        blocks[i, 9] = blocksrow5[9];
        i = 6;
        blocks[i, 0] = blocksrow6[0];
        blocks[i, 1] = blocksrow6[1];
        blocks[i, 2] = blocksrow6[2];
        blocks[i, 3] = blocksrow6[3];
        blocks[i, 4] = blocksrow6[4];
        blocks[i, 5] = blocksrow6[5];
        blocks[i, 6] = blocksrow6[6];
        blocks[i, 7] = blocksrow6[7];
        blocks[i, 8] = blocksrow6[8];
        blocks[i, 9] = blocksrow6[9];
        i = 7;
        blocks[i, 0] = blocksrow7[0];
        blocks[i, 1] = blocksrow7[1];
        blocks[i, 2] = blocksrow7[2];
        blocks[i, 3] = blocksrow7[3];
        blocks[i, 4] = blocksrow7[4];
        blocks[i, 5] = blocksrow7[5];
        blocks[i, 6] = blocksrow7[6];
        blocks[i, 7] = blocksrow7[7];
        blocks[i, 8] = blocksrow7[8];
        blocks[i, 9] = blocksrow7[9];
        i = 8;
        blocks[i, 0] = blocksrow8[0];
        blocks[i, 1] = blocksrow8[1];
        blocks[i, 2] = blocksrow8[2];
        blocks[i, 3] = blocksrow8[3];
        blocks[i, 4] = blocksrow8[4];
        blocks[i, 5] = blocksrow8[5];
        blocks[i, 6] = blocksrow8[6];
        blocks[i, 7] = blocksrow8[7];
        blocks[i, 8] = blocksrow8[8];
        blocks[i, 9] = blocksrow8[9];
        i = 9;
        blocks[i, 0] = blocksrow9[0];
        blocks[i, 1] = blocksrow9[1];
        blocks[i, 2] = blocksrow9[2];
        blocks[i, 3] = blocksrow9[3];
        blocks[i, 4] = blocksrow9[4];
        blocks[i, 5] = blocksrow9[5];
        blocks[i, 6] = blocksrow9[6];
        blocks[i, 7] = blocksrow9[7];
        blocks[i, 8] = blocksrow9[8];
        blocks[i, 9] = blocksrow9[9];
        //for (int j = 0; j <= 9; j++)
        //{
        //    blocks[j, i] = blockz[counter];
        //    //Debug.Log("Name " + blockz[counter].name);
        //    //Debug.Log(" Actual Name " + blocks[j,i].gameObject.name);
        //    blocks[j, i].transform.GetChild(0).gameObject.GetComponent<Text>().text = counter.ToString();
        //    counter += 1;
        //}

        //rows = GameObject.FindGameObjectsWithTag("Row");
        //column = GameObject.FindGameObjectsWithTag("Column");
        // GenerateNonogram(nonoImages[0]);
        // GenerateClues();
        for (int j = 0; j < answerkey.GetLength(0); j++)
        {
            for (i = 0; i < answerkey.GetLength(1); i++)
            {
               // var msg = "[" + i.ToString() + ", " + j.ToString() + "] = " + answerkey[i, j].ToString();
              //  Debug.Log(msg);
            }
        }

    }

    public bool GenerateTotalNono(TimeableObject asset)
    {
        try
        {
            GenerateNonogram(asset);
            GenerateClues();
            return true;
        }catch(Exception e)
        {
            Debug.Log("Exception " + e);
            return false;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    void GenerateNonogramLayout()
    {
        Rect nonoImage = new Rect(-(Screen.width / 4), -(Screen.height / 4), Screen.width / 4, Screen.height / 4); // half screen in the center of it?
        //Debug.Log("nono x " + nonoImage.x + " nono y " + nonoImage.y);  
        float nonoHTenth = nonoImage.height / 10;
        //Debug.Log("Nono Height Tenth " + nonoHTenth);
        float nonoWTenth = nonoImage.width / 10;
       // Debug.Log("Nono width Tenth " + nonoWTenth);
        for (int i =0; i <=9; i++)
        {
            for(int j = 0; j<=9; j++)
            {
                Vector2 tomp = new Vector3(nonoImage.x + nonoWTenth * i, nonoImage.y + nonoHTenth * j);
                GameObject temp = Instantiate(nonoBlock, tomp, transform.rotation);
                temp.transform.SetParent(gameObject.transform, false);
                //temp.GetComponent<RectTransform>().position = tomp;
                blocks[i, j] = temp;
            }
        }
        

    }

    bool CheckWin()
    {
       
        for (int j = 0; j < answerkey.GetLength(0); j++)
        {
            for (int i = 0; i < answerkey.GetLength(1); i++)
            {
               // Debug.Log("Answer key = " + answerkey[i,j] + " block is " + blocks[i, j].gameObject.GetComponent<BlockScript>().hash);
                if (answerkey[i, j] != blocks[i, j].gameObject.GetComponent<BlockScript>().hash/* && blocks[i,j].gameObject.GetComponent<BlockScript>().hash != 2*/)
                {
                    
                    return false;
                }
            }
        }
       // Debug.Log("WIN");
        WinNonoGram();
        return true;
    }

    void WinNonoGram()
    {
        buttonHolder.SetActive(false);
        winImage.gameObject.SetActive(true);
        winImage.sprite = nonoImages[0].itemImage;
        StartCoroutine(Breath());
    }

    private IEnumerator Breath()
    {
        while (true)
        {

            _currentScale += _dx;
            if (_currentScale > TargetScale)
            {
              
                _currentScale = TargetScale;
            }
            winImage.transform.localScale = Vector3.one * _currentScale;
            yield return new WaitForSeconds(_deltaTime);
            

            
        }
    }
    void GenerateNonogram(TimeableObject asset)
    {
        Texture2D image = asset.nonoImage;
        var whitePixels = 0;
        var blackPixels = 0;
        for (int j = 0; j < image.height; j++)
            for (int i = 0; i < image.width; i++)
            {
                Color pixel = image.GetPixel(9-j,9-i);

                // if it's a white color then just debug...
                if (pixel == Color.white)
                {
                    whitePixels++;
                    answerkey[i,j] = 1;
                    blocks[i, j].GetComponent<BlockScript>().hash = 1;
                    blocks[i, j].transform.GetChild(0).gameObject.GetComponent<Text>().text = "1";
                }
                else
                {
                    blackPixels++;
                    answerkey[i,j] = 0;
                    blocks[i, j].GetComponent<BlockScript>().hash =1    ;
                    //blocks[i, j].GetComponent<Image>().sprite = blockImgs[1];
                    blocks[i, j].transform.GetChild(0).gameObject.GetComponent<Text>().text = "0";
                }
            }
        //Debug.Log(answerkey);
        //Debug.Log(string.Format("White pixels {0}, black pixels {1}", whitePixels, blackPixels));
    }

    void GenerateClues()
    {
        string clueLine;
        List<int> black;
        int count = 0;

        for (int i = 0; i < answerkey.GetLength(1); i++)
        { // row
            black = new List<int>();

            for (int j = 0; j < answerkey.GetLength(0); j++) // column
            {

                if (answerkey[i, j] == 0)// it's black we need to count it.
                {
                    count += 1;
                    //blocks[i,j].GetComponent<Image>().sprite = blockImgs[1];
                    try
                    {
                        if (answerkey[i, j + 1] == 0) // next one is black
                        {

                        }
                        else
                        {
                            black.Add(count);
                            count = 0;
                            
                        }
                    }
                    catch (System.Exception e)
                    {
                        Debug.Log(e); //OOBE
                        black.Add(count);
                        count = 0;
                    }
                }
                rows[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = ConvertListToString(black);
                //Debug.Log(black.ToString());
            }
           
        }
        for (int i = 0; i < answerkey.GetLength(0); i++)
        { // row
            black = new List<int>();

            for (int j = 0; j < answerkey.GetLength(1); j++) // column
            {
                if (answerkey[j,i] == 0)// it's black we need to count it.
                {
                    count += 1;
                    try
                    {
                        if (answerkey[j+1, i] == 0) // next one is black
                        {

                        }
                        else
                        {
                            
                            black.Add(count);
                            count = 0;
                        }
                    }
                    catch (System.Exception e)
                    {
                        Debug.Log(e); //OOBE
                        black.Add(count);
                        count = 0;
                    }
                }
                columns[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = ConvertListToString(black);
                //Debug.Log(black.ToString());
            }
        }

    }

    string ConvertListToString(List<int> ints)
    {
        string duh = "";
        foreach (var item in ints)
        {
            duh = duh + item.ToString() + " ";
        }
        return duh;
    }
    public void ToggleBx()
    {
        selected = EventSystem.current.currentSelectedGameObject;

        //GameObject but = EventSystem.current.currentSelectedGameObject;
        //but.GetComponent<BlockScript>().MyClick(blockImgs);
        Debug.Log("but = " + selected.name);
       
    }

    public void ButtonCheck()
    {
        BlockScript temp = selected.GetComponent<BlockScript>();
        switch (temp.hash)
        {
            case 0:
                SafeButton.GetComponent<Image>().sprite = buttonImg[3];
                blackButton.GetComponent<Image>().sprite = buttonImg[0];
                break;
            case 1:
                SafeButton.GetComponent<Image>().sprite = buttonImg[3];
                blackButton.GetComponent<Image>().sprite = buttonImg[1];
                break;
            case 2:
                SafeButton.GetComponent<Image>().sprite = buttonImg[2];
                blackButton.GetComponent<Image>().sprite = buttonImg[1];
                break;
        }
    }
    public void ToggleSafe()
    {
        if (selected.GetComponent<BlockScript>().hash != 2)
        {
            selected.GetComponent<BlockScript>().MyClick(blockImgs, 2);
        }
        else
        {
            selected.GetComponent<BlockScript>().MyClick(blockImgs, 0);
        }
      
        ButtonCheck();
        //CheckWin();
    }

    public void ToggleBlack()
    {
       // selected.GetComponent<BlockScript>().MyClick(blockImgs, 1);
        if (selected.GetComponent<BlockScript>().hash != 0)
        {
            selected.GetComponent<BlockScript>().MyClick(blockImgs, 1);
        }
        else
        {
            selected.GetComponent<BlockScript>().MyClick(blockImgs, 0);
        }
        CheckWin();
        ButtonCheck();
    }
    public void ToggleWhite()
    {
        selected.GetComponent<BlockScript>().MyClick(blockImgs, 0);
        CheckWin();
        ButtonCheck();
    }
}
