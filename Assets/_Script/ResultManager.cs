using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour {

    public static ResultManager Instance;
    public Dictionary<int, Rank> rankMap;

    private void Awake()
    {
        Instance = this;
    }

    //랭킹 정보 가져오기
    public void ResultTodayRankMap()
    {
        
        rankMap = new Dictionary<int, Rank>();
        //Debug.Log(ConnectManager.getInst()._result);
        string[] lines = ConnectManager.getInst()._result.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i< lines.Length; i++)
        {
            string[] _parts = lines[i].Split(',');
            string _nickname = _parts[0];
            float _score = float.Parse(_parts[1]);
            rankMap.Add(i + 1, new Rank(_nickname, _score));    
        }
        // 그리고 뿌려주기
        foreach(KeyValuePair<int, Rank> pair in rankMap)
        {
            int ranking = pair.Key;
            Rank rank = pair.Value;
            //Debug.Log(ranking + "/" + rank.nickname);
            
            // 생성
            GameObject FP_rankBox = Resources.Load("RankBox") as GameObject;
            GameObject rankBox = Instantiate(FP_rankBox) as GameObject;
            rankBox.transform.FindChild("rank").GetComponent<Text>().text = ranking.ToString();
            rankBox.transform.FindChild("nickname").GetComponent<Text>().text = rank.nickname;
            rankBox.transform.FindChild("score").GetComponent<Text>().text = (rank.score).ToString();

            rankBox.transform.SetParent(GameObject.Find("Canvas/Tab_TotalRank/Scroll View/Viewport/Content").transform);
        }

    }
    // Game 씬에서 랭킹정보 가져오기 , UI 뿌려주기 기능 없음.
    public void ResultTodayRankMapUINone()
    {
        rankMap = new Dictionary<int, Rank>();
        //Debug.Log(ConnectManager.getInst()._result);
        string[] lines = ConnectManager.getInst()._result.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < lines.Length; i++)
        {
            string[] _parts = lines[i].Split(',');
            string _nickname = _parts[0];
            float _score = float.Parse(_parts[1]);
            rankMap.Add(i + 1, new Rank(_nickname, _score));
        }
    }

}
