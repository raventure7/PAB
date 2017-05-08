using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 싱글 톤 */
public class SoundManager : MonoBehaviour {
    public static SoundManager Instance;    
    public AudioClip[] audioClips;
    AudioSource sound;
    // Use this for initialization

    private void Awake()
    {
        Instance = this;
    }

    void Start () {
        sound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    // 충돌시 사운드 처리
    public void HitSound()
    {
        sound.clip = audioClips[0];
        sound.Play();
    }
    // 방향 전환 소리
    public void FlapSound()
    {
        sound.clip = audioClips[1];
        sound.Play();
    }
    // 게임 오버 소리
    public void GameOverSound()
    {
        sound.clip = audioClips[2];
        sound.Play();
    }
    // 스코어 소리
    public void ScoreSound()
    {
        sound.clip = audioClips[3];
        sound.Play();
    }
}
