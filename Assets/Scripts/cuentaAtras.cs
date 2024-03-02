using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cuentaAtras : MonoBehaviour
{

    // PÚBLICAS
    private Button boton;
    public Image num;
    public Text texto;
    public Sprite[] numeros;

    // Start is called before the first frame update
    void Start()
    {
        //boton = GameObject.findAnyObjectByType<Button>();
        boton = GameObject.FindWithTag("startButton").GetComponent<Button>();
        boton.onClick.AddListener(Empezar);

    }


    void Empezar()
    {
        texto.gameObject.SetActive(false);
        num.gameObject.SetActive(true);
        boton.gameObject.SetActive(false);
        
        StartCoroutine(PonerNumeros());
    }

    IEnumerator PonerNumeros()
    {
        for(int i=0;i<numeros.Length;i++)
        {
            num.sprite = numeros[i];
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   
}
