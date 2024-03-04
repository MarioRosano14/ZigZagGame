using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruccionSuelo : MonoBehaviour
{
    public GameObject suelo;

    private AudioSource audioSource;
    [SerializeField] private AudioClip colectar1;

    private IEnumerator OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {

            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(colectar1);

            suelo.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            suelo.gameObject.GetComponent<Rigidbody>().useGravity = true;
            yield return new WaitForSeconds(1);
            Destroy(suelo);

        }
        
    }
}
