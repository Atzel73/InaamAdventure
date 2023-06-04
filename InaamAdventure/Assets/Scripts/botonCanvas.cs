using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonCanvas : MonoBehaviour
{
    public void Menu(){
        Debug.Log("BOOOLAAAAAAAAAS");
    }
    public void Jugar(){
        SceneManager.LoadScene(2);
    }
}
