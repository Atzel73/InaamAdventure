using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "NuevoPersonaje", menuName = "Personaje")]


public class personaje : ScriptableObject {
    
    public AnimationClip animator;
    public AnimationClip animator1;
    public AnimationClip animator2;
    public GameObject personajeJugable;
    public Sprite imagen;
    public string nombre;
    

   
}
