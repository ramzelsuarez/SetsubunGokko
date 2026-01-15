using UnityEngine;
using UnityEngine.UI;


public class TimeCou : MonoBehaviour
{
    public GameObject timeObj;
    private Text timeTxt;
    public GameObject headerObj;
    private Header hdr;
    private float time;
    private bool isGame;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeTxt = timeObj.GetComponent<Text>();
        hdr = headerObj.GetComponent<Header>();
        isGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGame)
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("f2");
            if(Input.GetKeyDown(KeyCode.E))
            {
                isGame = false;
            }
        }
        if(!isGame)
        {
            hdr.resultTime = time;
            hdr.ChangeScene("ResultSamp");
        }
    }
}
