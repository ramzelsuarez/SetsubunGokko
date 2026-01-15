using UnityEngine;
using UnityEngine.UI;
public class Result : MonoBehaviour
{
    public GameObject headerObj;
    private Header hdr;
    public GameObject resultObj;
    private Text resultTxt;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hdr = headerObj.GetComponent<Header>();
        resultTxt = resultObj.GetComponent<Text>();
        if(hdr.Time[0] < hdr.resultTime)
        {
            for(int i = hdr.Time.Length - 1; i > 0; i--)
            {
                if(i == 0)
                {
                    hdr.Time[i] = hdr.resultTime;
                }
                else
                {
                    hdr.Time[i] = hdr.Time[i - 1];
                }
            }
            hdr.JSave(hdr.sd);
        }
    }

    // Update is called once per frame
    void Update()
    {
        resultTxt.text = hdr.resultTime.ToString("f2");
    }
}
