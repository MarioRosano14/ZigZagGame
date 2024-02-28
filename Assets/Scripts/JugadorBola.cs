using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JugadorBola : MonoBehaviour
{

    public Camera camara;
    public GameObject suelo;
    public float velocidad = 5.0f;

    private Vector3 offset;
    private Vector3 DireccionActual;

    public Image leftButton;
    public Image rightButton;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = camara.transform.position;
        DireccionActual = Vector3.forward;
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
                rightButton.gameObject.SetActive(false);
            }
            if(direccion == 2) {
                DireccionActual = Vector3.right;
                leftButton.gameObject.SetActive(false);
            }
        }
        else {
            DireccionActual = Vector3.forward;
            rightButton.gameObject.SetActive(true);
            leftButton.gameObject.SetActive(true);
        }
    }

}
