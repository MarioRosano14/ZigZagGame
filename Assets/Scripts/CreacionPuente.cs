using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreacionPuente : MonoBehaviour
{
    public GameObject suelo;

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {

            MeshRenderer meshRenderer = suelo.GetComponent<MeshRenderer>();
            meshRenderer.enabled = true;
            suelo.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            Destroy(gameObject);
        }
    }
}
