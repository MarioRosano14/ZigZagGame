using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JugadorBola : MonoBehaviour
{

    public Camera camara;
    public float velocidad = 5.0f;

    private Vector3 offset;
    private Vector3 DireccionActual;

    private int totalEstrellas = 0;
    public Text contadorEstrellas;

    [SerializeField] private AudioClip colectar1;
    [SerializeField] private AudioClip colectar2;
    [SerializeField] private AudioClip colectar3;

    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = camara.transform.position - transform.position;
        DireccionActual = Vector3.forward;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        camara.transform.position = transform.position + offset;

        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            CambiarDireccion(1);
        } else if(Input.GetKeyUp(KeyCode.RightArrow)) {
            CambiarDireccion(2);    
        }

        transform.Translate(DireccionActual * velocidad * Time.deltaTime);
    }

    private void CambiarDireccion(int direccion) {

        if (DireccionActual == Vector3.forward) {
            if(direccion == 1) {
                DireccionActual = Vector3.left;
            }
            if(direccion == 2) {
                DireccionActual = Vector3.right;
            }
        }
        else {
            DireccionActual = Vector3.forward;
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Obstaculo") {
            audioSource.PlayOneShot(colectar1);
            SceneManager.LoadScene("DeadEnd");
        }

        if (other.gameObject.tag == "Premio") {
            audioSource.PlayOneShot(colectar2);
            totalEstrellas++;
            contadorEstrellas.text = "Puntuacion: " + totalEstrellas;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "LineaMeta") {
            audioSource.PlayOneShot(colectar3);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
