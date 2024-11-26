using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRigidBody;
    public float playerSpeed = 1f;

    public Vector2 playerDirection;

    private bool isWalking;

    private Animator playerAnimator;

    private bool playerFacingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Obtem e inicializa as propriedades do RigidBody2d    
        playerRigidBody = GetComponent<Rigidbody2D>();

        // Obtem e inicializa as propriedades do animator
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        UptadeAnimator();

        
    }
    // Fixed Uptade geralmente é utilizada para implementação de física no jogo, por ter uma execução padronizada em direfentes dispostivos

    private void FixedUpdate()
    {
        // Verifica se player está no movimento 

        if (playerDirection.x != 0 || playerDirection.y != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        playerRigidBody.MovePosition(playerRigidBody.position + playerSpeed * Time.fixedDeltaTime * playerDirection);
    }
    void PlayerMove()
    {
        // Pega a entrada do jogador, e cria um Vector2 para usar no playerDirection
        playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Se o player vai para a ESQUERDA e está olhando para a DIREITA

        if (playerDirection.x < 0 && playerFacingRight == true)
        {
            Flip();
        }

        // Se o player vai para a DIREITA e está olhando para ESQUERDA

        else if (playerDirection.x > 0 && !playerFacingRight)
        {
            Flip();
        }
    }

    void UptadeAnimator()
    {
        // Definir o valor do parâmetro do animator, igual á propriedade isWalking
        playerAnimator.SetBool("isWalking",  isWalking);
    }

    void Flip ()
    {
        // Vai girar o sprite do player em 180 Graus no eixo Y

        // Inverter o valor da variável playerFacingRight
        playerFacingRight = !playerFacingRight;

        // Girar o sprite do player em 180 Graus no eixo Y
        // X Y Z
        transform.Rotate(0, 180, 0);
    }
}
