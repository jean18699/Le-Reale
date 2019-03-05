using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public GameObject FlechaPrefab;
    GameObject _flecha;
    Vector3 mousePos;
    float angle;
    ControlPruebaFlecha controlFlecha;
    Global scrGlobales;

    void Start()
    {
        scrGlobales = GameObject.Find("ScriptsGlobales").GetComponent<Global>();
        //controlFlecha = GameObject.FindGameObjectWithTag("Flecha").GetComponent<ControlPruebaFlecha>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (mousePos.x <= 4.45f)
        {
            mousePos.x = 4.45f;
        }
        if (mousePos.y <= -5.60f)
        {
            mousePos.y = -5.60f;
        }
        if (mousePos.y >= 4.45f)
        {
            mousePos.y = 4.45f;
        }

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

      

        if(scrGlobales.EstadoJugador == Global.eEstadoJugador.Preparando)
        {
            _flecha = Instantiate(FlechaPrefab);
            _flecha.transform.SetParent(transform);
            _flecha.transform.localPosition = new Vector3(0, 0, 0);
            _flecha.transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z - 90f); 
            scrGlobales.EstadoJugador = Global.eEstadoJugador.Esperando;

        }

        
        if (Input.GetMouseButtonDown(0) && scrGlobales.EstadoJugador == Global.eEstadoJugador.Esperando)
        {

            _flecha.transform.SetParent(null);
           

            if (mousePos.x < 0)
            {
                mousePos.x = mousePos.x * -1f;
            }

            _flecha.GetComponent<ControlPruebaFlecha>().posInicial = mousePos;
            _flecha.GetComponent<ControlPruebaFlecha>().angle = angle;
            // controlFlecha.setPosInicial(mousePos, angle);
            scrGlobales.EstadoJugador = Global.eEstadoJugador.Disparo;



        }
    }
}
