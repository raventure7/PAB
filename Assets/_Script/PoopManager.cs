using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopManager : MonoBehaviour {

    public static PoopManager Instance;

    
    public GameObject poop;
    public int randomNumber;
    public int poopCount;
    public float poopScale;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        poopCount = 150;
        poopScale = 0.15f;
    }
	
	// Update is called once per frame
	void Update () {

        if(poop.GetComponent<PoopInfo>().count() <= poopCount)
        { 
            GameObject Poop = (GameObject)Instantiate(poop, new Vector3(Random.Range(-17.0f, 22.0f), 0f, 0f), Quaternion.identity);
            randomNumber = Random.Range(0, 2147483646);
            Poop.transform.localScale = new Vector3(poopScale, poopScale, poopScale);
            Poop.GetComponent<PoopInfo>().poopID = randomNumber;
            Poop.GetComponent<PoopInfo>().Register();
            Poop.GetComponent<Rigidbody2D>().gravityScale= Random.Range(0.01f, 0.05f);
        }

    }

}
