using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public float AttackDamage = 1;
    public float CoolDownTime = 1;
    bool ready = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!ready) { return; } //if not ready stop
        if(other.tag == gameObject.tag) { return; } // you hit a friend stop

        var destroyable = other.GetComponent<Destroyable>();
        if (destroyable)
        {
            destroyable.ApplyDamage(AttackDamage);
            StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {
        ready = false;
        yield return new WaitForSeconds(CoolDownTime);
        ready = true;
    }
}
