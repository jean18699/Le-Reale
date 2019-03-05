using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{

    public GameObject enemigosPrefab;
    GameObject _enemigo;
    Global scrGlobales;
    float vidaEnemigo;
    float tiempoAparicion;
    
    // Start is called before the first frame update
    void Start()
    {
        scrGlobales = GameObject.Find("ScriptsGlobales").GetComponent<Global>();
    }

    // Update is called once per frame
    void Update()
    {
        if(scrGlobales.Dificultad == Global.eDificultad.Normal)
        {
            tiempoAparicion += Time.deltaTime;
            if (tiempoAparicion > 5)
            {

                _enemigo = Instantiate(enemigosPrefab);
                _enemigo.GetComponent<ControlEnemigo>().nivel = 1;
                _enemigo.transform.position = new Vector3(transform.position.x, -21f, 0);
                tiempoAparicion = 0;

            }


            /*
            if (scrGlobales.Dificultad == Global.eDificultad.Dificil)
            {
                tiempoAparicion += Time.deltaTime;
                if (tiempoAparicion > 10)
                {

                    _enemigo = Instantiate(enemigosPrefab);
                    _enemigo.GetComponent<ControlEnemigo>().nivel = 2;
                    _enemigo.transform.position = new Vector3(transform.position.x, -21f, 0);
                    tiempoAparicion = 0;

                }


            }*/

        }
        
    }
}
