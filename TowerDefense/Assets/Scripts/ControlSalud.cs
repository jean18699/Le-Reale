using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSalud : MonoBehaviour
{

    GameObject healtBarJugador;
    GameObject _vidaJugador;


    // Start is called before the first frame update
    void Start()
    {
        
        _vidaJugador = transform.GetChild(2).gameObject;
        
        
    }

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        
        _vidaJugador.transform.localScale -= new Vector3(0.2f, 0, 0);
    }



}
