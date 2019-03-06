using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public float velocidadDisparo;
    public GameObject FlechaPrefab;
    GameObject _flecha;
    ControlPruebaFlecha controlFlecha;
    Vector3 mousePos;
    
    Global scrGlobales;
    double _alto, _ancho, _angulo;


    void Awake()
    {
        controlFlecha = gameObject.GetComponent<ControlPruebaFlecha>();

    }

    void Start()
    {
        scrGlobales = GameObject.Find("ScriptsGlobales").GetComponent<Global>();
       
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos.x +" "+ mousePos.y);

      /*  if (mousePos.x <= 4.45f)
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
        */
        _alto = mousePos.y - transform.position.y;
        _ancho = mousePos.x - transform.position.x;
        _angulo = Mathf.Atan((float)_alto / (float)_ancho);
        
        

        gameObject.transform.rotation = Quaternion.AngleAxis((float)_angulo * Mathf.Rad2Deg, Vector3.forward);
        

        if (scrGlobales.EstadoJugador == Global.eEstadoJugador.Preparando)
        {
            _flecha = Instantiate(FlechaPrefab);
            _flecha.transform.SetParent(transform);
            _flecha.transform.localPosition = new Vector3(0, 0, 0);
            _flecha.transform.localEulerAngles = new Vector3(0, 0, -45f); 
            scrGlobales.EstadoJugador = Global.eEstadoJugador.Esperando;

        }

        
        if (Input.GetMouseButtonDown(0) && scrGlobales.EstadoJugador == Global.eEstadoJugador.Esperando)
        {

            _flecha.transform.SetParent(null);
            _flecha.GetComponent<ControlPruebaFlecha>().Velocidad = new Vector3(velocidadDisparo * Mathf.Cos((float)_angulo), velocidadDisparo * Mathf.Sin((float)_angulo));

            
            // _flecha.GetComponent<ControlMRUV>().posInicial = mousePos;
            //_flecha.GetComponent<ControlMRUV>().setPosInicial(angle);
            
            scrGlobales.EstadoJugador = Global.eEstadoJugador.Disparo;



        }
    }
}
