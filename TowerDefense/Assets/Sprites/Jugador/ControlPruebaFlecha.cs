using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPruebaFlecha : MonoBehaviour
{
    public Vector3 Velocidad;
    Vector3 movimientoFlecha;
    ControlEnemigo enemigo;
    public float dmgFlechaCuerpo = 0.4f;
    public float dmgFlechaPies = 0.2f;
    Global scrGlobales;
    
    void Awake()
    {
        scrGlobales = GameObject.Find("ScriptsGlobales").GetComponent<Global>();

    }
    void Start()
    {
    }

    void Update()
    {
        if (scrGlobales.EstadoJugador == Global.eEstadoJugador.Disparo)
        {
           
            movimientoFlecha.x = Mathf.Abs(Velocidad.x * Time.deltaTime + (Physics.gravity.x * (Mathf.Pow(Time.deltaTime, 2) / 2)));

            movimientoFlecha.y = Velocidad.y * Time.deltaTime + (Physics.gravity.y * (Mathf.Pow(Time.deltaTime, 2) / 2));

            gameObject.transform.Translate(movimientoFlecha);

            Velocidad += Physics.gravity * Time.deltaTime;

        }
            
    }

   
    //Cuando la flecha choca con una parte del cuerpo
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            if (other.GetType() == typeof(SphereCollider))
            {
                other.gameObject.GetComponent<ControlEnemigo>().danoCabeza(true);
            }
            if (other.GetType() == typeof(BoxCollider))

                other.gameObject.GetComponent<ControlEnemigo>().danoCuerpo(true, dmgFlechaCuerpo);

            if (other.GetType() == typeof(CapsuleCollider))
            {

                other.gameObject.GetComponent<ControlEnemigo>().danoCuerpo(true, dmgFlechaPies);
            }

        }
        Destroy(transform.gameObject);
        scrGlobales.EstadoJugador = Global.eEstadoJugador.Preparando;

    }

}
       

    


