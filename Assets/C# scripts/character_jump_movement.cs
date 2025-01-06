using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Karakterin zýplama hareketini kontrol eden sýnýf
public class character_jump_movement : MonoBehaviour
{
    // Zýplama kuvveti
    private float jumpForce = 4f;

    // Yer katmaný için LayerMask
    public LayerMask groundLayer;

    // Yerden kontrol mesafesi
    public float groundCheckDistance = 0.1f;

    // Rigidbody2D bileþeni referansý
    private Rigidbody2D rb;

    // Zýplama yapýlýp yapýlamayacaðýný belirleyen bayrak
    private bool canJump;

    // Baþlangýçta çalýþacak metod
    void Start()
    {
        // Rigidbody2D bileþenini al
        rb = GetComponent<Rigidbody2D>();

        // Zýplama izinli olsun
        canJump = true;
    }

    // Her kare güncelleðinde çalýþacak metod
    void Update()
    {
        // Karakterin yerde olup olmadýðýný kontrol et
        bool isGrounded = IsGrounded();

        // Yerde olup olmadýðýný konsola yazdýr
        print(isGrounded);

        // Space tuþuna basýlýrsa, karakter yerdeyse ve zýplama izinliyse zýpla
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canJump)
        {
            Jump();
        }
    }

    // Karakterin yere temas edip etmediðini kontrol eden metod
    bool IsGrounded()
    {
        // BoxCollider2D'nin sýnýrlarýný al
        Bounds bounds = GetComponent<BoxCollider2D>().bounds;

        // Sýnýrlarýn alt merkezinden aþaðý doðru bir ýþýn oluþtur
        Ray2D ray = new Ray2D(new Vector2(bounds.center.x, bounds.min.y), Vector2.down);

        // Iþýný groundLayer üzerinde kontrol mesafesi kadar at ve çarpýþma olup olmadýðýný kontrol et
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, bounds.size.y / 2f, groundLayer);

        // Iþýn groundLayer üzerinde bir þeye çarparsa yere temas ediyor demektir
        return hit.collider != null;
    }

    // Zýplama iþlemini gerçekleþtiren metod
    void Jump()
    {
        // Karakterin mevcut yatay hýzýný koruyarak dikey hýzý zýplama kuvveti ile ayarla
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    // Hareketi açýp kapatmak için kullanýlacak metod (örneðin, etkileþim scriptlerinde)
    public void ToggleJumpMovement(bool allowMovement)
    {
        canJump = allowMovement;
    }
}
