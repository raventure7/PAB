using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopManager : MonoBehaviour {
    public GameObject poop;
    int randomNumber;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(poop.GetComponent<PoopInfo>().count() <= 230)
        { 
            GameObject Poop = (GameObject)Instantiate(poop, new Vector3(Random.Range(-17.0f, 22.0f), 0f, 0f), Quaternion.identity);
            randomNumber = Random.Range(0, 2147483646);
            Poop.GetComponent<PoopInfo>().poopID = randomNumber;
            Poop.GetComponent<PoopInfo>().Register();
            Poop.GetComponent<Rigidbody2D>().gravityScale= Random.Range(0.01f, 0.05f);
        }

    }

}
