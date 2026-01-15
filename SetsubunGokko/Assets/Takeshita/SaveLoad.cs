using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    public GameObject T1O;
    public GameObject T2O;
    public GameObject T3O;
    private Text T1T;
    private Text T2T;
    private Text T3T;
    public GameObject header;
    private Header hd;
    private SavaDeta sd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        T1T = T1O.GetComponent<Text>();
        T2T = T2O.GetComponent<Text>();
        T3T = T3O.GetComponent<Text>();
        hd = header.GetComponent<Header>();
        sd = hd.JLoad();
    }

    // Update is called once per frame
    void Update()
    {
        T1T.text = sd.firTime.ToString("f2");
        T2T.text = sd.secTime.ToString("f2");
        T3T.text = sd.thiTime.ToString("f2");
    }
}
