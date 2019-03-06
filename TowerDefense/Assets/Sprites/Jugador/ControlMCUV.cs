using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMCUV : MonoBehaviour
{
    Vector3 velocidadFinal;//Vector3.zero;
    Vector3 aceleracion = new Vector3(1, 1);
    Vector3 angulo = Vector3.zero;
    private float _radio;
    private Vector3 _centro;

    
    // Start is called before the first frame update
    void Start()
    {
        velocidadFinal = new Vector3(200, 200, 0);
        //Coordenadas del hook
        establecerCentro(new Vector3(-23, -1));    
        //establecerCentro();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(_centro == Vector3.zero)
        {
            return;
        }

        angulo = velocidadFinal * Time.time /_radio; //Este time.time debe ser reemplazado por la hora en la que inicio
        //el hook

        gameObject.transform.position = new Vector3(_centro.x + _radio * Mathf.Cos(angulo.x), _centro.y
            + _radio * Mathf.Sin(angulo.y));


        //velocidadFinal += aceleracion * Time.deltaTime;

    }

    void establecerCentro(Vector3 nuevoCentro)
    {
        _centro = nuevoCentro;
        _radio = 30;//(float)calcularDistancia(/*nuevoCentro*/_centro, gameObject.transform.position);
    }

    double calcularDistancia(Vector3 punto1, Vector3 punto2)
    {
        return Mathf.Sqrt(Mathf.Pow(punto1.x - punto2.x, 2) + Mathf.Pow(punto1.y - punto2.y, 2));
    }


}
