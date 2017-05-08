using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopInfo : MonoBehaviour {

    public static Dictionary<int, PoopInfo> poopMap = new Dictionary<int, PoopInfo>();

    public Sprite poop2;
    public GameObject hitEffect; // 응가와 충돌 시

    public int  poopID;


    public  void Register()
    {
        poopMap.Add(this.poopID, this);
    }
    private void OnDestroy()
    {
        poopMap.Remove(this.poopID);
    }
    public int count()
    {
        return poopMap.Count;
    }
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Ground")
        {

        }
        switch (collider.tag)
        {
            // 바닥과 충돌 시
            case "Ground":
                this.gameObject.GetComponent<SpriteRenderer>().sprite = poop2;
                this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                OnDestroy();
                Destroy(gameObject, 0.5f);
                break;

            // 쉴드와 충돌 시 
            case "Shield":
                SoundManager.Instance.HitSound();
                Destroy(gameObject);
                GameObject Hit = (GameObject)Instantiate(hitEffect, gameObject.transform.position, Quaternion.identity);
                Destroy(Hit, 0.2f);
                OnDestroy();
                break;
            // 플레이어와 충돌 시
            case "Player":
                SoundManager.Instance.HitSound();
                Destroy(gameObject);
                GameObject PlayerHit = (GameObject)Instantiate(hitEffect, gameObject.transform.position, Quaternion.identity);
                PlayerHit.transform.localScale = new Vector3(2, 2, 2);
                Destroy(PlayerHit, 1.0f);
                OnDestroy();
                break;
        }
    }

}
