using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ModifyTextMeshPro : MonoBehaviour
{
    public TMP_Text canvasText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EditarTexto(){
        int contador = 0;
        if (Input.GetButtonDown("Fire2"))
        {
            canvasText.text = "Acabas de... Espera, ¿Por que hiciste eso?";
            contador = contador + 1;
            if (contador > 5)
            {
                canvasText.text = "Por metiche :)";
                
            }
        }
        
    }
    ///Recargar escena
    public void RebootLevel(){
            if (Input.GetKeyDown(KeyCode.K)  )
            {
                canvasText.text = "Por metiche :)";
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
                
            }
        }
        ///Cargar siguiente escena
        public void NextScene(){
            if (Input.GetKeyDown(KeyCode.V))
            {
                  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
}
