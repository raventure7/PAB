using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class IndexManager : MonoBehaviour {
    //프레팹
    public GameObject poop;

    //닉네임
    public GameObject nicknameInputField;
    public Text nickname;
    // 생성
    private GameObject Poop;
    // Use this for initialization

    private void Awake()
    {
        if (PlayerPrefs.GetString("nickname") != "")
        {
            Debug.Log("닉네임 있음");
            nicknameInputField.GetComponent<InputField>().text = PlayerPrefs.GetString("nickname");
        }

        if (GameObject.Find("DBManager") == null)
        {
            GameObject DBManager = new GameObject("DBManager");
            DBManager.AddComponent<DBManager>();
            DontDestroyOnLoad(DBManager); //Scene이 변경 되어도 제거 되지 않는다.
        }
        if (GameObject.Find("ConnectManager") == null)
        {
            GameObject ConnectManager = new GameObject("ConnectManager");
            ConnectManager.AddComponent<ConnectManager>();
            DontDestroyOnLoad(ConnectManager); //Scene이 변경 되어도 제거 되지 않는다.
        }
        if (GameObject.Find("ResultManager") == null)
        {
            GameObject ResultManager = new GameObject("ResultManager");
            ResultManager.AddComponent<ResultManager>();
            DontDestroyOnLoad(ResultManager); //Scene이 변경 되어도 제거 되지 않는다.
        }
    }
    void Start () {
        Poop = (GameObject)Instantiate(poop, new Vector3(1.39f, 2.52f, 0f), Quaternion.identity);
        DBManager.Instance.GetTodayRankList(); // 랭킹 점수 가져오기.

    }
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("IndexPoop(Clone)")) { 
                if (Poop.transform.position.y <= -7.0f)
            {
                Destroy(GameObject.Find("IndexPoop(Clone)").gameObject);

                Poop = (GameObject)Instantiate(poop, new Vector3(1.39f, 8.52f, 0f), Quaternion.identity);
                
            }
        }

    }

    // 게임 시작 버튼
    public void GameStart()
    {
        if(nickname.text.ToString() == "")
        {

            nicknameInputField.GetComponent<InputField>().ActivateInputField();
        }
        else {
            PlayerPrefs.SetString("nickname", nickname.text.ToString());
            Debug.Log(nickname.text.ToString());
            SceneManager.LoadScene("Game");
        }
    }
}
