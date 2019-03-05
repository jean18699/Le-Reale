using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMRUV : MonoBehaviour
{
    const float FACTORREBOTE = -1.1f;
    Vector3 velocidadFinal = Vector3.zero;
    Vector3 cambioPosicion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Cambio de posicion
        cambioPosicion.x = velocidadFinal.x * Time.deltaTime + (Physics.gravity.x * (Mathf.Pow(Time.deltaTime, 2) / 2));

        cambioPosicion.y = velocidadFinal.y * Time.deltaTime + (Physics.gravity.y * (Mathf.Pow(Time.deltaTime, 2) / 2));

        gameObject.transform.Translate(cambioPosicion);

        velocidadFinal += Physics.gravity * Time.deltaTime;
        

    }

   private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Plataforma")
        {
            
            velocidadFinal *= -1f;//FACTORREBOTE;
        }
    
    }

}
