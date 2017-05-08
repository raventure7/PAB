using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public PlayerController Player;
    public Text Timer;
    public float timer;
    public GameObject Popup_GameOver;

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
        
    }
    void Start () {
        timer = 0;
        state = State.Ready;
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
