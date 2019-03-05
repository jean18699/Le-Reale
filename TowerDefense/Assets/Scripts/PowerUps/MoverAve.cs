using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAve : MonoBehaviour
{
    Vector3 movimiento;
    const float VELOCIDAD = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        movimiento.x = VELOCIDAD * Time.deltaTime;
        movimiento.y = 0;

        transform.Translate(movimiento);

        

    }

    private void OnTriggerEnter(Collider other)
    {
        transform.GetChild(0).SetParent(null);
        Destroy(transform.gameObject);
    }


}
