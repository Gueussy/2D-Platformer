using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private bool isJumping;
    private bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb;

    private Vector3 velocity = Vector3.zero;


    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position); //créer une boite de collision et vérifie si ça touche
        
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; //calcul le mouvement du Player

        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y); //estime la vélocité du Player

        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f); //bouge le Player

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce)); //Ajoute une force à y

            isJumping = false;
        }
    }
}
