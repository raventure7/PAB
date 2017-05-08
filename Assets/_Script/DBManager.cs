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
        URL = "http://raventure77.cafe24.com/poop";
    }
    // Use this for initialization
    void Start()
    {
        
    }

    public void AddScore()
    {
        today = System.DateTime.Now.ToString("yyyy-MM-dd"); // 오늘 날짜
        nowScore = PlayerPrefs.GetFloat("nowscore"); // 현재 점수
        PlayerNickname = PlayerPrefs.GetString("nickname"); // 유저 닉네임

        WWWForm form = new WWWForm();

        form.AddField("nickname", PlayerNickname);
        form.AddField("nowscore", nowScore.ToString()); //문자열로 넘김
        form.AddField("today", today);
        Debug.Log(PlayerNickname + "/" + nowScore.ToString() + "/" + today);

        resultFunction rf = new resultFunction(DebugLog);
        StartCoroutine( ConnectManager.getInst().SendData(URL+"/addScore.php", form, rf) );
    }
    public void GetTodayRankList()
    {
        today = System.DateTime.Now.ToString("yyyy-MM-dd"); // 오늘 날짜
        
        WWWForm form = new WWWForm();
        form.AddField("today", today);
        resultFunction rf = new resultFunction(ResultManager.Instance.ResultTodayRankMap);
        StartCoroutine(ConnectManager.getInst().SendData(URL + "/getTodayScoreList.php", form, rf));
    }


	public void DebugLog()
    {
        Debug.Log(ConnectManager.getInst()._result);
    }

    
}
