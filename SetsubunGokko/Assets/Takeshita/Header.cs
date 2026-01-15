using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

[System.Serializable]
public class SavaDeta
{
    public float firTime;
    public float secTime;
    public float thiTime;
}

public class Header : MonoBehaviour
{
    public float[] Time;
    public float resultTime;
    public SavaDeta sd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sd = new SavaDeta();
        Time = new float[3] { sd.firTime, sd.secTime, sd.thiTime };
        DontDestroyOnLoad(this);
        resultTime = PlayerPrefs.GetFloat("resultTime", 0);
        if(!File.Exists(Application.dataPath + "/savedata.json"))
        {
            JSave(sd);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void ChangeScene(string sceneName)
    {
        PlayerPrefs.SetFloat("resultTime", resultTime);
        PlayerPrefs.Save();
        SceneManager.LoadScene(sceneName);
    }

    public void JSave(SavaDeta savaDeta)
    {
        
        StreamWriter sw;
        string jsonStr = JsonUtility.ToJson(savaDeta);
        sw = new StreamWriter(Application.dataPath + "/savedata.json", false);
        sw.Write(jsonStr);
        sw.Flush();
        sw.Close();
    }
    public SavaDeta JLoad()
    {
        string dataStr;
        StreamReader sr;
        sr = new StreamReader(Application.dataPath + "/savedata.json");
        dataStr = sr.ReadToEnd();
        sr.Close();

        return JsonUtility.FromJson<SavaDeta>(dataStr);
    }
}
