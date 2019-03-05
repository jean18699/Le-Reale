using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPruebaFlecha : MonoBehaviour
{
    public float velocidad;
    Vector3 vectorVelocidad;
    public float angle;
    Vector3 movimientoFlecha;
    public Vector3 posInicial;
    ControlEnemigo enemigo;
    public float dmgFlechaCuerpo = 0.4f;
    public float dmgFlechaPies = 0.2f;
    Global scrGlobales;
    bool Arraque = true;
    // Start is called before the first frame update
    void Start()
    {
        Arraque = true;
        scrGlobales = GameObject.Find("ScriptsGlobales").GetComponent<Global>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Arraque == true)
        {


            float velX = velocidad * Mathf.Cos(angle);
            float velY = velocidad * Mathf.Sin(angle);
            vectorVelocidad = new Vector3(velX, velY, 0);
            Arraque = false;
        }
        if (scrGlobales.EstadoJugador == Global.eEstadoJugador.Disparo)
        {
            
            movimientoFlecha.x = (vectorVelocidad.x * Time.deltaTime);

            movimientoFlecha.y = (vectorVelocidad.y * Time.deltaTime) + (Physics.gravity.y) * (Mathf.Pow(Time.deltaTime, 2) / 2);

            vectorVelocidad += Time.deltaTime * Physics.gravity;
            

            transform.Translate(movimientoFlecha);
        }
            
    }

    public void setPosInicial(Vector3 posInicial,float angulo)
    {
        this.posInicial = posInicial;
        this.angle = angulo;
        

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
       

    


