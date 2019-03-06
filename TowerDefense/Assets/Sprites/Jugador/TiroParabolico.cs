using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroParabolico : MonoBehaviour
{

    const float VELOCIDADSALTO = 10f;
    ControlMRUV controlMRUV;
    Vector3 posicionMouse;
    double _alto, _ancho, _angulo;
    public GameObject Bala;


    void Awake()
    {
        controlMRUV = gameObject.GetComponent<ControlMRUV>();
   
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            controlMRUV.MovimientoActivo = true;
            controlMRUV.velocidadFinal = new Vector3(0, VELOCIDADSALTO);
        }


        posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _alto = posicionMouse.y - transform.position.y;
        _ancho = posicionMouse.x - transform.position.x;
        _angulo = Mathf.Atan((float)_alto / (float)_ancho);
     

        if (Input.GetButtonDown("Fire1"))
        {
            var nuevaBala = Instantiate(Bala, gameObject.transform.position, Quaternion.identity);
            var controlMRUV = nuevaBala.GetComponent<ControlMRUV>();
            controlMRUV.MovimientoActivo = true;
            controlMRUV.velocidadFinal = new Vector3(10f * Mathf.Cos((float)_angulo), 10f * Mathf.Sin((float)_angulo));
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        controlMRUV.MovimientoActivo = false;

    }


}

