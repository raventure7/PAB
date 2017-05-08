using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour {

    public static DBManager Instance;

    private string PlayerNickname;
    private string URL;
    private string today;
    private float nowScore;

    private void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start()
    {
        PlayerNickname = PlayerPrefs.GetString("nickname");
        URL = "http://raventure77.cafe24.com/poop";
        
    }

    public void AddScore()
    {
        today = System.DateTime.Now.ToString("yyyy-MM-dd");
        nowScore = PlayerPrefs.GetFloat("nowscore");
        WWWForm form = new WWWForm();

        form.AddField("nickname", PlayerNickname);
        form.AddField("nowscore", nowScore.ToString()); //문자열로 넘김
        form.AddField("today", today);
        Debug.Log(PlayerNickname + "/" + nowScore.ToString() + "/" + today);

        resultFunction rf = new resultFunction(DebugLog);
        StartCoroutine( ConnectManager.getInst().SendData(URL+"/addScore.php", form, rf) );
    }

	public void DebugLog()
    {
        Debug.Log(ConnectManager.getInst()._result);
    }

    
}
