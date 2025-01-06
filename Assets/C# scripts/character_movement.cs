using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_movement : MonoBehaviour
{
    private SpriteRenderer spriteRendererComponent;

    // Karakterin hareket h�z�
    private float moveSpeed = 5f;

    // Karakterin hareket edip edemeyece�ini kontrol eden de�i�ken
    private bool canMove = true;

    // Karakterin bakt��� y�n� belirlemek i�in de�i�ken
    // 'firing_projectile.cs' gibi ayr� bir scriptte mermilerin hangi y�ne at�laca��n� anlamak i�in kullan�l�r.
    public bool isfacingright = true; // E�er bu de�i�ken 'false' ise, karakter sola bak�yor demektir.

    // Ba�lang��ta bir kere �al��an metod
    void Start()
    {
        // GameObject'ten SpriteRenderer bile�enini al
        spriteRendererComponent = GetComponent<SpriteRenderer>();

        // SpriteRenderer bile�eni bulunamazsa hata mesaj� g�ster
        if (spriteRendererComponent == null)
        {
            Debug.LogError("SpriteRenderer bile�eni GameObject �zerinde bulunamad�.");
        }
    }

    // Her karede bir kere �al��an metod
    void Update()
    {
        // E�er karakter hareket edebiliyorsa
        if (canMove)
        {
            // "A" tu�una bas�l�rsa sola hareket
            if (Input.GetKey(KeyCode.A))
            {
                // Karakteri sola hareket ettir
                transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);

                // Sprite'� yatayda �evir (sola bak)
                FlipSprite(true);

                // Karakterin sola bakt���n� belirt
                isfacingright = false;
            }

            // "D" tu�una bas�l�rsa sa�a hareket
            if (Input.GetKey(KeyCode.D))
            {
                // Karakteri sa�a hareket ettir
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

                // Sprite'� yatayda �evirme (sa�a bak)
                FlipSprite(false);

                // Karakterin sa�a bakt���n� belirt
                isfacingright = true;
            }
        }
    }

    // Karakterin hareket edip edemeyece�ini kontrol eden metod
    public void ToggleMovement(bool allowMovement)
    {
        canMove = allowMovement;
    }

    // Sprite'� yatayda �evirmek i�in kullan�lan metod
    private void FlipSprite(bool flip)
    {
        // Sprite'� yatay eksende �evir (flipX, SpriteRenderer bile�eninde yerle�ik bir �zelliktir)
        spriteRendererComponent.flipX = flip;
    }
}
