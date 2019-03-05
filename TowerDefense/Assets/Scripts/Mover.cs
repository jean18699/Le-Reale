using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * velocidad * Time.deltaTime, Input.GetAxis("Vertical") * velocidad * Time.deltaTime, 0);  
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetType() == typeof(CircleCollider2D))
        {

            Debug.Log("Cabeza");

        }

        if (other.collider.GetType() == typeof(BoxCollider2D))
        {

            Debug.Log("Torso");
        }
        if (other.collider.GetType() == typeof(CapsuleCollider2D))
        {

            Debug.Log("Piernas");

        }


    }


}
