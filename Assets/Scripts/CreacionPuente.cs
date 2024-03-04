using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreacionPuente : MonoBehaviour
{
    public GameObject suelo;
    public GameObject obstaculo;

    private AudioSource audioSource;
    [SerializeField] private AudioClip colectar1;

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {
            
            Destroy(obstaculo.gameObject);

            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(colectar1);

            MeshRenderer meshRenderer = suelo.GetComponent<MeshRenderer>();
            meshRenderer.enabled = true;
            suelo.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            Destroy(gameObject);
        }
    }
}
