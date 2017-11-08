using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesCommandManager : MonoBehaviour {

    public static LinesCommandManager instance;

    //lines
    public GameObject linesGirl;
    public GameObject linesGhost;

    //text UI in the lines
    public GameObject textGirl;
    public GameObject textGhost;

    private List<LinesCommand> commands = new List<LinesCommand>();
    private int nowIndex = 0;   //current lines index
    public bool isDialogueMode = true; //display mode flag

    //cache transform
    [SerializeField]
    public List<string> startObj = new List<string>();
    public Dictionary<string, Transform> allObj = new Dictionary<string, Transform>();

    void Awake()
    {
        instance = this;
    }

    IEnumerator WaitAndPrint(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        
        Next();
    }

    public void LineContainer(float waitTime)
    {

        StartCoroutine(WaitAndPrint(waitTime));
    }


    // Use this for initialization
    void Start () {
        isDialogueMode = true;
        //set up game lines environment.
        for (int i=0; i<startObj.Capacity; i++)
        {
            allObj.Add(startObj[i], GameObject.Find(startObj[i]).transform);
        }
        
        commands.Add(new CommandDialogue("where is my brother?", textGirl, linesGirl));
        
        commands.Add(new CommandDialogue("i am here! my sister!", textGhost, linesGhost));
        
        commands.Add(new CommandDialogue("don`t go ahead!", textGhost, linesGhost));
        

    }
	
	// Update is called once per frame
	void Update () {
        //FIXME: text display is not smooth, size exceeds the range.

        //let lines follow character

        //convert the UI text position to its position in the main camera
        Vector2 girlPos = Camera.main.WorldToScreenPoint(linesGirl.transform.position);
        Vector2 ghostPos = Camera.main.WorldToScreenPoint(linesGhost.transform.position);

        textGirl.GetComponent<RectTransform>().transform.position = girlPos;
        textGhost.GetComponent<RectTransform>().transform.position = ghostPos;
        

        if (Input.GetKeyDown(KeyCode.A) && commands.Count!= 0)
        {

            Debug.Log("A: " + nowIndex);
            //isDialogueMode = false;
            commands[nowIndex].Execute();
            //isDialogueMode = false;

        }
        
	}

    //excute next lines
    public void Next()
    {
        
        Debug.Log("NEXT: " + nowIndex);

        nowIndex++;
        if(nowIndex < commands.Count)
        {
            
            commands[nowIndex].Execute();   //TODO: xxx.SetActive(false/true);
            
        } else
        {
            //clear lines
            nowIndex = 0;
            commands.Clear();
        }
    }

    //
    public void Next2()
    {
        Debug.Log(isDialogueMode);
        if (isDialogueMode)
        {
            isDialogueMode = false;
            Debug.Log("NEXT2: " + nowIndex);
            return;
        }
            
        else
        {
            isDialogueMode = true;
            Next();
        }
            
        
    }

}
