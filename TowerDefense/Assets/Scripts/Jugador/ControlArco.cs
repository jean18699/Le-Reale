using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArco : MonoBehaviour
{
    // Start is called before the first frame update

    Vector2 mousePos;
	Vector3 screenPos;
	public GameObject Flecha;
	GameObject _flecha;
    
    void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
        rotar();
    }



    void rotar()
    {
		mousePos = new Vector2(Input.mousePosition.x - gameObject.transform.position.x, Input.mousePosition.y);
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);

		mousePos.x -= gameObject.transform.position.x;
		mousePos.y -= gameObject.transform.position.y;

		if(mousePos.x <= 4.45f)
		{
			mousePos.x = 4.45f;
		}
		if (mousePos.y <= -5.60f)
		{
			mousePos.y = -5.60f;
		}
		if (mousePos.y >= 4.45f)
		{
			mousePos.y = 4.45f;
		}

		var angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			_flecha = Instantiate(Flecha);
			//var _flechaScript = GameObject.FindGameObjectWithTag("Flecha").GetComponent<ControlFlecha>();
			//_flechaScript.mousePos = mousePos;
			var _flechaScript = _flecha.GetComponent<ControlFlecha>();
			_flechaScript.mousePos = mousePos;
			_flecha.transform.position = new Vector2(0, 0);
			_flecha.transform.SetParent(gameObject.transform);
			_flecha.transform.localPosition = new Vector2(0, 0);
			//_flecha.transform.SetParent(null);

			//_flecha.transform.SetParent(null);
		}

	}

}
