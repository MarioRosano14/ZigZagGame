using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruccionSuelo : MonoBehaviour
{
    public GameObject suelo;

    private IEnumerator OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {

            suelo.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            suelo.gameObject.GetComponent<Rigidbody>().useGravity = true;
            yield return new WaitForSeconds(2);
            Destroy(suelo);

        }
        
    }
}
