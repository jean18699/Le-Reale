using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroFlecha : MonoBehaviour
{

    Vector3 cambioPosicion = Vector3.zero;
    Vector3 velocidadFinal = Vector3.zero;
    public float velocidad;
    float velXInicial;
    float velYInicial;
    float angulo;
    Global scrGlobales;
    
    // Start is called before the first frame update
    void Start()
    {
        scrGlobales = GameObject.Find("ScriptsGlobales").GetComponent<Global>();
        velXInicial = velocidad * Mathf.Cos(angulo);

        velYInicial = velocidad * Mathf.Sin(angulo);

    }

    // Update is called once per frame
    void Update()
    {
        /*if (scrGlobales.EstadoJugador == Global.eEstadoJugador.Disparo)
        {
        
        }*/

    }

    private void OnTriggerEnter(Collider other)
    {
       // scrGlobales.EstadoJugador = Global.eEstadoJugador.Preparando;
    }

    public void asignarAngulo(float angulo)
    {
        this.angulo = angulo;
    }
}
