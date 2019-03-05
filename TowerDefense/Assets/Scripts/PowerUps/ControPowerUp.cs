using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControPowerUp : MonoBehaviour
{
    Vector3 Velocidad;
    Vector3 movimiento;
    public GameObject[] PowerUps = new GameObject[3];
    GameObject _pwrUp;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == null)
        {


            movimiento.y = Velocidad.y * Time.deltaTime + (Physics.gravity.y * Mathf.Pow(Time.deltaTime, 2)) / 2;
            Velocidad.y -= Time.deltaTime * 1.2f;
            transform.Translate(movimiento);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.name == "DeadZoneSuelo")
        {
            _pwrUp = Instantiate(PowerUps[0]);

           /* if(_pwrUp.transform.tag == "Escudo")
            {
                _pwrUp.transform.position = new Vector3(-37.70712f, -1.992721f, 0);
                _pwrUp.GetComponent<ControlMCUV>()._centro = new Vector3(-30, -20, 0);
            }
            */
        }
    }

}
