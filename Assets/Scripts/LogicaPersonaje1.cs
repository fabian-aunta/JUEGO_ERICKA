using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonaje1 : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 200.0f;
    private Animator animator;
    public float x, y;

    public Rigidbody rb;
    public float fuerzaSalto = 8f;
    public bool puedoSaltar;
    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0,0, y * Time.deltaTime * movementSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");  

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        if (puedoSaltar){
            if(Input.GetKeyDown(KeyCode.Space)){
                animator.SetBool("salte", true);
                rb.AddForce(new Vector3(0,fuerzaSalto, 0), ForceMode.Impulse);
            }
            animator.SetBool("tocoSuelo", true);
        }else {
            EstoyCayendo();
        }
    }

    public void EstoyCayendo()
    {
        animator.SetBool("tocoSuelo", false);
        animator.SetBool("salte",false);
    }
}
