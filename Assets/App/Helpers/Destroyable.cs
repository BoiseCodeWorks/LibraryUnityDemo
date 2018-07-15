using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

    //ADDITIONAL CHALLENGE PROVIDE IMMUNITY x SECONDS
    public float Hitpoints;
    public void ApplyDamage(float damage)
    {
        Hitpoints -= damage;
        if(Hitpoints <= 0)
        {
            //I Die
            Destroy(gameObject);
        }
    }
}
