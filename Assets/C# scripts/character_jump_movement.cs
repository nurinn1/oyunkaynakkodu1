using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Karakterin z�plama hareketini kontrol eden s�n�f
public class character_jump_movement : MonoBehaviour
{
    // Z�plama kuvveti
    private float jumpForce = 4f;

    // Yer katman� i�in LayerMask
    public LayerMask groundLayer;

    // Yerden kontrol mesafesi
    public float groundCheckDistance = 0.1f;

    // Rigidbody2D bile�eni referans�
    private Rigidbody2D rb;

    // Z�plama yap�l�p yap�lamayaca��n� belirleyen bayrak
    private bool canJump;

    // Ba�lang��ta �al��acak metod
    void Start()
    {
        // Rigidbody2D bile�enini al
        rb = GetComponent<Rigidbody2D>();

        // Z�plama izinli olsun
        canJump = true;
    }

    // Her kare g�ncelle�inde �al��acak metod
    void Update()
    {
        // Karakterin yerde olup olmad���n� kontrol et
        bool isGrounded = IsGrounded();

        // Yerde olup olmad���n� konsola yazd�r
        print(isGrounded);

        // Space tu�una bas�l�rsa, karakter yerdeyse ve z�plama izinliyse z�pla
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canJump)
        {
            Jump();
        }
    }

    // Karakterin yere temas edip etmedi�ini kontrol eden metod
    bool IsGrounded()
    {
        // BoxCollider2D'nin s�n�rlar�n� al
        Bounds bounds = GetComponent<BoxCollider2D>().bounds;

        // S�n�rlar�n alt merkezinden a�a�� do�ru bir ���n olu�tur
        Ray2D ray = new Ray2D(new Vector2(bounds.center.x, bounds.min.y), Vector2.down);

        // I��n� groundLayer �zerinde kontrol mesafesi kadar at ve �arp��ma olup olmad���n� kontrol et
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, bounds.size.y / 2f, groundLayer);

        // I��n groundLayer �zerinde bir �eye �arparsa yere temas ediyor demektir
        return hit.collider != null;
    }

    // Z�plama i�lemini ger�ekle�tiren metod
    void Jump()
    {
        // Karakterin mevcut yatay h�z�n� koruyarak dikey h�z� z�plama kuvveti ile ayarla
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    // Hareketi a��p kapatmak i�in kullan�lacak metod (�rne�in, etkile�im scriptlerinde)
    public void ToggleJumpMovement(bool allowMovement)
    {
        canJump = allowMovement;
    }
}
