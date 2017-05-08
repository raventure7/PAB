using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    public Transform Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // X 만 캐릭터 따라 이동
        if(this.transform.position.x >= -13.8 && this.transform.position.x <= 18.2f)
        {
            this.transform.position = new Vector3(Player.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.x >= 18.2f)
        {
            this.transform.position = new Vector3(18.19f, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.x <= -13.8f)
        {
            this.transform.position = new Vector3(-13.79f, this.transform.position.y, this.transform.position.z);
        }

    }
}
