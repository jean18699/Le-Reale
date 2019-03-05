using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{


    public enum eEstadoJugador
    {
        Preparando,
        Esperando,
        Disparo
        
    }

    public enum eDificultad
    {
        Normal,
        Dificil
       
    }

    public enum eEstadoJuego
    {
        Ejecutando,
        Terminado
    }

    public eEstadoJugador EstadoJugador { get; set; }
    public eDificultad Dificultad { get; set; }
    public eEstadoJuego EstadoJuego;


    public TextMesh txtPuntos;
    public TextMesh txtKills;
    int flechasRestantes;
    int enemigosEliminados;
    int puntos;

    float tiempoJuego;



    // Start is called before the first frame update
    void Start()
    {
        EstadoJuego = eEstadoJuego.Ejecutando;
        EstadoJugador = eEstadoJugador.Preparando;
        Dificultad = eDificultad.Normal;
        
        enemigosEliminados = 0;
        puntos = 0;

    }

    // Update is called once per frame
    void Update()
    {
        tiempoJuego += Time.deltaTime;
        txtPuntos.text = puntos.ToString();

        txtKills.text = enemigosEliminados.ToString();
       
        //Si el jugador sobrevivio mas de un minuto se aumenta la dificultad
        if (tiempoJuego > 15)
        {
            Dificultad = eDificultad.Dificil;
        }


        //FIN DE JUEGO
        if(EstadoJuego == eEstadoJuego.Terminado)
        {
            Time.timeScale = 0;
        }

       

    }

    public void addPuntos(int puntos = 0)
    {
        this.puntos += puntos;
    }

   /* public void eliminarFlecha(bool flechaPerdida = false)
    {
        if(flechaPerdida == true && flechasRestantes > 0)
        {
            flechasRestantes--;

            if(flechasRestantes == 0)
            {
                EstadoJuego = eEstadoJuego.Terminado;
            }

        }

    }*/

    public void confirmarMuerte(bool kill = false)
    {
        if(kill == true)
        {
            enemigosEliminados+=1;
            print(enemigosEliminados);
        }
    }


}
