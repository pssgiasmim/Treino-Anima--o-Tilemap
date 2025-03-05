using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator; //Referência para o animator do personagem.
    private Rigidbody2D rigidbody2d; //Referência para o rigidbody2d do personagem.
    public float speed = 5f; //Velocidade de movimento.
    public float jumpForce = 10f; //Força do pulo.
    public bool isGrounded = true; //Verifica se o personagem está no chão.
    private SpriteRenderer spriteRenderer; //Cuida da escala do personagem.

    // Start é chamado antes do primeiro frame de Update. 
    void Start()
    {
        //Pegar o SpriteRenderer do personagem.
        spriteRenderer =GetComponent<SpriteRenderer>();
        //Pegar o animator e o rigidbody 2d que estão no gameobject do personagem.
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update é chamado a cada frame.
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); //Pega o movimento horizontal de 1 (direita) e -1 (esquerda) e 0 (parado).

        rigidbody2d.velocity = new Vector2(moveInput * speed, rigidbody2d.velocity.y); //Movimento do personagem para os lados.
        

        //Troca de animação para correr.
        if (moveInput != 0)
        {
            animator.SetBool("isRunning", true);

            spriteRenderer.flipX = (moveInput < 0);  // Espelha o personagem caso ele esteja indo para a esquerda
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        //Pulo ao pressionar W
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
            isGrounded = false; //Diz que ele não está mais no chão.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Verifica se tocou no chão.
        if (collision. gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }
}
