using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class ControlFlecha : MonoBehaviour
{
	public float Velocidad = 5;
	float velocidadX;
	float velocidadY;
	float velocidadInicialX;
	float velocidadInicialY;
	public Vector3 mousePos;
	public float angulo;
	public Vector3 PosicionFlecha;
	Vector3 _posicionFlechaInicial;
	float gravedad = 55;

	float elapsed_time;

	// Start is called before the first frame update
	void Start()
    {
		//UnityEngine.Debug.Log(mousePos.x + " " + mousePos.y);


		/* angulo = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		 Vx = Velocidad * Mathf.Cos(angulo);
		 VoY = Velocidad * Mathf.Sin(angulo);
		 duracionDeVuelo = Mathf.Abs(transform.parent.position.x / Vx);

		 Xo = transform.parent.position.x;
		 Yo = transform.parent.position.y + transform.parent.localScale.y;*/

		transform.position = PosicionFlecha;
		transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angulo));
		_posicionFlechaInicial = PosicionFlecha;

		//velocidadInicialX = Mathf.Abs(Velocidad * Mathf.Ceil(Mathf.Cos(angulo)));
		//velocidadInicialY = Velocidad * Mathf.Ceil(Mathf.Sin(angulo));

		velocidadInicialX = Velocidad * Mathf.Abs(Mathf.Floor(Mathf.Cos(angulo * Mathf.Deg2Rad)));
		velocidadInicialY = Velocidad * Mathf.Floor(Mathf.Sin(angulo * Mathf.Deg2Rad));
	}

    // Update is called once per frame
    void Update()
    {

		/*velocidadX = velocidadInicialX;
		velocidadY = velocidadInicialY - (gravedad * Time.time);

		PosicionFlecha.x = _posicionFlechaInicial.x +  velocidadX * Time.time;
		PosicionFlecha.y = _posicionFlechaInicial.y + (velocidadInicialY * Time.time) - ((1/2) * gravedad * Mathf.Pow(Time.time, 2));
		transform.Translate(PosicionFlecha / 250);

		print(velocidadY);*/

		PosicionFlecha.x = -(_posicionFlechaInicial.x + (velocidadInicialX * Time.time));
		PosicionFlecha.y = _posicionFlechaInicial.y + (velocidadInicialY * Time.time) - ((gravedad / 2) * Mathf.Pow(Time.time, 2));

		transform.Translate(PosicionFlecha / 100);

		print(velocidadInicialY);

	}

	public double ConvertToRadians(float angle)
	{
		return (float)(Math.PI / 180) * angle;
	}


	/*public void Disparar(Vector2 mousePos)
    {
		//y = y0 + v0y⋅t + 12⋅ay⋅t2
		//x=x0+vx⋅t

		float Xo = transform.parent.position.x;
		float Yo = transform.parent.position.y;

		var angulo = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

		float Vx = Velocidad * Mathf.Cos(angulo);
		float VoY = Velocidad * Mathf.Sin(angulo);
		float Vy;

		float duracionDeVuelo = Mathf.Abs(transform.parent.position.x / Vx);


		float elapse_time = 0;

		transform.SetParent(null);

		Stopwatch stopWatch = new Stopwatch();
		stopWatch.Start();

		if (transform.position.y > 0)
		{
			//Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

			//vy=v0y−g⋅t

			elapse_time = stopWatch.ElapsedMilliseconds / 1000;

			Vy = VoY - Gravity * elapse_time;

			X = Xo + Vx + elapse_time;
			Y = Yo + Vy * elapse_time + (Gravity / 2) * Mathf.Pow(elapse_time, 2);



			StartCoroutine(DesplazarFlecha());

			

			UnityEngine.Debug.Log(X);

		}

	}

	IEnumerator DesplazarFlecha()
	{
		while (true)
		{
			transform.position = new Vector2(X, Y);
			yield return new WaitForSeconds(0.5f);
		}
	}*/
}