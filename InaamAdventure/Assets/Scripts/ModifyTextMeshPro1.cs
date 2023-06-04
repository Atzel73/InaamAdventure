using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ModifyTextMeshPro1 : MonoBehaviour
{
    public TMP_Text canvasText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EditarTexto();
        RebootLevel();
    }
    public void EditarTexto(){
        int contador = 0;
        if (Input.GetButtonDown("Fire2"))
        {
            canvasText.text = "Ya estas en otro nivel, Y Por que? Por metiche";
            contador = contador + 1;
            if (contador > 5)
            {
                canvasText.text = "Por metiche :)";
            }
        }
        
    }
    public void RebootLevel(){
            if (Input.GetKeyDown(KeyCode.K) && Input.GetKeyDown(KeyCode.L) )
            {
                canvasText.text = "Ya no puedes volver :)";
                
                
            }
        }
        public void LevelBefore(){
            if (Input.GetKeyDown(KeyCode.V))
            {
                  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
}
