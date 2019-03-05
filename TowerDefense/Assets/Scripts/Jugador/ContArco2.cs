using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContArco2 : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 mousePos;
    public GameObject Flecha;
    GameObject _flecha;
    Global scrGlobales;
    TiroFlecha controlFlecha;
    public float angulo { get; set; }


    void Start()
    {
        scrGlobales = GameObject.Find("ScriptsGlobales").GetComponent<Global>();
        controlFlecha = GameObject.FindGameObjectWithTag("Flecha").GetComponent<TiroFlecha>();

    }

    // Update is called once per frame
    void Update()
    {
        rotar();
        if(scrGlobales.EstadoJugador == Global.eEstadoJugador.Preparando)
        {
            prepararFlecha();
            scrGlobales.EstadoJugador = Global.eEstadoJugador.Esperando;
        }
        if (Input.GetButton("Fire1"))
        {

           
            
        }
        

    }


    void prepararFlecha()
    {
        _flecha = Instantiate(Flecha);
        _flecha.transform.SetParent(transform);
        _flecha.transform.localPosition = new Vector3(0f,mousePos.y);
        


    }

    void rotar()
    {

        mousePos = Input.mousePosition;
        mousePos.z = -10;
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

        var angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        controlFlecha.asignarAngulo(angle);

        
    }

}
