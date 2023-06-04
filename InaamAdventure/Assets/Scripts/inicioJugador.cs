using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inicioJugador : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        Instantiate(GameManager.Instance.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity);
        
    }

    
}
