using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEntorno : MonoBehaviour
{
	float tamagno; // tamaño del gameObject
	float velocidad; // velocidad del gameObject
	float comienzoX; // punto de aparición del gameObject
	float finalX; // punto de desaparición del gameObject
	float PosY; // altura del gameObject

	public Sprite[] Aleteo;


	public enum Origen // lugar de aparición del gameObject
	{
		Izquierda,
		Derecha
	}

	public enum PosicionAlas // posición de las alas gameObject
	{
		PosicionAlas0,
		PosicionAlas1,
		PosicionAlas2,
		PosicionAlas3,
		PosicionAlas4,
		PosicionAlas5,
		PosicionAlas6,
		PosicionAlas7,
		PosicionAlas8
	}

	Origen origen;
	PosicionAlas posicionAlas;

    // Start is called before the first frame update
    void Start()
    {

		if (!gameObject.CompareTag("Nube")) // Si no es nube, se asigna el sprite del ave con las alas abajo
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = Aleteo[0];
			posicionAlas = PosicionAlas.PosicionAlas0;
		}

		if(Random.Range(0, 2) == 1) ///////////////////////////////
		{
			origen = Origen.Derecha;
			DirigirALaIzquierda();
		}
		else
		{
			origen = Origen.Izquierda;
			DirigirALaDerecha();
		} /////////////////////////////////////////////////////// Se decida donde aparece y hacia donde va el gameObject

		if (gameObject.CompareTag("Nube")) // Si el gameObject es nube, siempre se dirigirá a la derecha
		{
			origen = Origen.Izquierda;
			DirigirALaDerecha();
		}

		
    }

    // Update is called once per frame
    void Update()
    {
		if(origen == Origen.Derecha) // si el gameobject se originó desde la derecha
		{

			if(transform.position.x <= finalX) // y su posición es menor o igual a su punto de desaparición
			{

				if (Random.Range(0, 2) == 1) //////
				{
					origen = Origen.Derecha;
					DirigirALaIzquierda();
				}
				else
				{
					origen = Origen.Izquierda;
					DirigirALaDerecha();
				} //////////////////////////////// buscar nuevas coordenadas aleatorias de aparición
			}

			transform.Translate(Vector2.left * velocidad * Time.deltaTime); // movimiento del gameObject
		}
		else // si el gameobject se originó desde la izquierda
		{
			if (transform.position.x >= finalX) // y su posición es mayor o igual a su punto de desaparición
			{
				if (!gameObject.CompareTag("Nube")) // si no es nube se buscan nuevas coordenadas aleatorias
				{ 
					if (Random.Range(0, 2) == 1)
					{
						origen = Origen.Derecha;
						DirigirALaIzquierda();
					}
					else
					{
						origen = Origen.Izquierda;
						DirigirALaDerecha();
					}
				} ////////////////////////////////////////////////////////////////////////////////////////////
				else // si es nube aparecerá a la izquierda y se dirigirá a la derecha
				{
					DirigirALaDerecha();
				}
			}

			transform.Translate(Vector2.left * velocidad * Time.deltaTime); //movimiento del gameObject
		}
    }

	void DirigirALaDerecha() // movimiento hacia la derecha
	{
		// los diferentes gameObjects tienen diferentes rangos de tamaño
		if (!gameObject.CompareTag("Nube"))
		{
			tamagno = Random.Range(0.75f, 2.4f);
		}
		else
		{
			tamagno = Random.Range(0.9f, 3);
		}

		// los diferentes gameObjects tienen diferentes rangos de aparición y desaparición. Las nubes serán menos frecuentes que las aves
		if (!gameObject.CompareTag("Nube"))
		{
			comienzoX = Random.Range(-100, -40);
			finalX = Random.Range(40, 100);
		}
		else
		{
			comienzoX = Random.Range(-125, -60);
			finalX = Random.Range(60, 120);
		}
		
		// determinación del rango aleatorio de la altura
		PosY = Random.Range(2.85f, 12.55f);

		// asignación de la posición y la rotación (para que el gameObject de frente a la dirección por la cual va)
		transform.position = new Vector2(comienzoX, PosY);
		transform.localRotation = Quaternion.Euler(0, 180, 0);

		// los pajaros y nubes tienen velocidades diferentes
		if (!gameObject.CompareTag("Nube"))
		{
			velocidad = 11 * tamagno;
		}

		else
		{
			velocidad = 2 * tamagno;
		}

		if (!gameObject.CompareTag("Nube"))
		{
			StartCoroutine(Aletear());
		}

	}

	void DirigirALaIzquierda()
	{
		tamagno = Random.Range(0.75f, 2.4f);
		transform.localScale = new Vector3(1, 1, 1) * tamagno;

		comienzoX = Random.Range(40, 100);
		PosY = Random.Range(2.85f, 12.55f);
		finalX = Random.Range(-100, -30);
		transform.position = new Vector2(comienzoX, PosY);
		transform.localRotation = Quaternion.Euler(0, 0, 0);

		velocidad = 15 * tamagno;

		if (!gameObject.CompareTag("Nube"))
		{
			StartCoroutine(Aletear());
		}
	}

	IEnumerator Aletear()
	{
		while (true)
		{
			if(posicionAlas == PosicionAlas.PosicionAlas0)
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = Aleteo[1];
				posicionAlas = PosicionAlas.PosicionAlas1;
			}
			else if (posicionAlas == PosicionAlas.PosicionAlas1)
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = Aleteo[2];
				posicionAlas = PosicionAlas.PosicionAlas2;
			}
			else if (posicionAlas == PosicionAlas.PosicionAlas2)
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = Aleteo[3];
				posicionAlas = PosicionAlas.PosicionAlas3;
			}
			else if (posicionAlas == PosicionAlas.PosicionAlas3)
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = Aleteo[4];
				posicionAlas = PosicionAlas.PosicionAlas4;
			}
			else if (posicionAlas == PosicionAlas.PosicionAlas4)
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = Aleteo[3];
				posicionAlas = PosicionAlas.PosicionAlas5;
			}
			else if(posicionAlas == PosicionAlas.PosicionAlas5)
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = Aleteo[2];
				posicionAlas = PosicionAlas.PosicionAlas6;
			}
			else if (posicionAlas == PosicionAlas.PosicionAlas6)
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = Aleteo[1];
				posicionAlas = PosicionAlas.PosicionAlas7;
			}
			else if (posicionAlas == PosicionAlas.PosicionAlas7)
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = Aleteo[0];
				posicionAlas = PosicionAlas.PosicionAlas8;
			}
			else if (posicionAlas == PosicionAlas.PosicionAlas8)
			{
				posicionAlas = PosicionAlas.PosicionAlas0;
			}

			//yield return new WaitForSeconds(0.07f);
			yield return new WaitForSeconds(2.52f/velocidad);
		}
	}
}
