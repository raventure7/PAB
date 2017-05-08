using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public PlayerController Player;
    public Text Timer;
    public Text nowRank;

    public float timer;
    public GameObject Popup_GameOver;
    public Dictionary<int, Rank> TempRankMap;

    float tempRank;
    // Use this for initialization
    public enum State
    {
        Ready,
        Play,
        GameOver
    }
    public State state;

    private void Awake()
    {
        TempRankMap = ResultManager.Instance.rankMap;
    }
    void Start () {
        timer = 0;
        state = State.Ready;
        
        nowRank.text = (ResultManager.Instance.rankMap.Count +1).ToString();
        StartCoroutine("ScoreCheck");
        


    }
	
	// Update is called once per frame
	void Update () {
        
        if (state != State.GameOver)
        { 
            timer += Time.deltaTime;
            Timer.text = string.Format("{0:N0}", timer);
        }
        
        // 5초 뒤 
        if (state == State.Ready && timer >= 5)
        {
            Player.ShieldDestory();
            state = State.Play;
        }

    }
    private void LateUpdate()
    {
        switch (state)
        {
            case State.Ready:
                
                break;
            case State.Play:
                Player.isPlay = true;
                if (Player.IsDead()) GameOver();

                // 지속 체크
                if(TempRankMap.Count >= 1)
                { 
                    foreach (KeyValuePair<int, Rank> pair in TempRankMap)
                    {
                        int ranking = pair.Key;
                        Rank rank = pair.Value;
                        if (timer >= rank.score)
                        {
                            tempRank = (ranking);
                            if(tempRank < float.Parse(nowRank.text))
                            {
                                nowRank.text = tempRank.ToString();
                            }
                            TempRankMap.Remove(ranking);
                            break;
                        }
                    }
                }
                break;
            case State.GameOver:
                Popup_GameOver.SetActive(true);
                break;
        }
    }
    void GameOver()
    {
        state = State.GameOver;
        Debug.Log("Game Over");
        PlayerPrefs.SetFloat("nowscore", float.Parse(Timer.text));
        DBManager.Instance.AddScore();
    }
    IEnumerator ScoreCheck()
    {
        while(state != State.GameOver)
        {
            yield return new WaitForSeconds(1.0f);
            SoundManager.Instance.ScoreSound();
           
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }
    public void Index()
    {
        SceneManager.LoadScene("Index");
    }
}
