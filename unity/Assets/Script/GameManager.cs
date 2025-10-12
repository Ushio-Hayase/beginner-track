using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TaskManager talkManager;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction { get; private set; } = false;

    public void Action(GameObject scanObj)
    {
        if (isAction)
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            scanObject = scanObj;
            talkText.text = "This name is " + scanObj.name;
        }
        talkPanel.SetActive(isAction);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
