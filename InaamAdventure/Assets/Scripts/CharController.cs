using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharController : MonoBehaviour
{
    
    public float fuerzaSalto;
    public float velocidad;
    public float fuerzaGolpe;
    public float saltosMaximos;
    public LayerMask capaSuelo;
    public AudioClip sonidoSalto;
    public AudioClip sonidoExplosion;
    public AudioManager audioManager;
    
    public bool destruir = true;
    public int comboDestruir;
    public int combo;
    public bool atacando;


    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private bool mirandoDerecha = true;
    private float saltosRestantes;
    private Animator animator;
    private bool puedeMoverse = true;


     
    // Start is called before the first frame update
    void Start()
    {
         rigidbody = GetComponent<Rigidbody2D>();
         boxCollider = GetComponent<BoxCollider2D>();
         saltosRestantes = saltosMaximos;
         animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
        Combos();
       
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }

    void ProcesarSalto()
    {
        if(EstaEnSuelo())
        {
            saltosRestantes = saltosMaximos;
        }

        if (Input.GetButtonDown("Jump") && saltosRestantes > 0)
        {
            saltosRestantes--;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("isJumping", true);
            }
            else
            {
                animator.SetBool("isJumping", false);
            }




    }

    public void autoDestruction(){
        if (Input.GetButtonDown("Fire1"))
        {
            destruir = true;
            
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
        }
        else
        {
            
        }
    }
        public void Combos (){
            if (Input.GetButtonDown("Fire1") && !atacando)
            {
                atacando = true;
                animator.SetTrigger(""+combo);
                
            }
            else
            {
               
                
            }


        }

public void startCombo(){
    atacando = false;
    if (combo < 3)
    {
        combo++;
    }
}
        public void finishAni(){
            atacando = false;
            combo = 0;
        }



    ///Metodo 1
    void ProcesarMovimiento(){

        if (!puedeMoverse) return;

        float inputMovimiento = Input.GetAxis("Horizontal");
       
            if(inputMovimiento != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }




        rigidbody.velocity = new Vector2(inputMovimiento * velocidad, rigidbody.velocity.y);
      GestionarOrientacion(inputMovimiento);
    }

    void GestionarOrientacion(float inputmovimiento)
    {
        //Si se cumple condicióm
        if ((mirandoDerecha == true && inputmovimiento < 0) || (mirandoDerecha == false && inputmovimiento > 0))
        {
            //Ejecutar codigo de volteado 
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }

    public void AplicarGolpe(){

        puedeMoverse = false;
        Vector2 direccionGolpe;

        if (rigidbody.velocity.x > 0)
        {
            direccionGolpe = new Vector2(-1, 1);
        }
        else
        {
            direccionGolpe = new Vector2(1, -1);
        }
        rigidbody.AddForce(direccionGolpe * fuerzaGolpe);
    
    StartCoroutine(EsperarYActivarMovimiento());

    }

    IEnumerator EsperarYActivarMovimiento(){
        yield return new WaitForSeconds(0.1f);

        while (!EstaEnSuelo()){

        yield return null;
            
        }
        puedeMoverse = true;
    }


    }

