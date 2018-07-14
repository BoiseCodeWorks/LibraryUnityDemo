using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //the enemy hit me now what?????
            var candy = gameObject;
            Destroy(candy);
        }
    }


}
