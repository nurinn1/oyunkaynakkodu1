using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_movement : MonoBehaviour
{
    private SpriteRenderer spriteRendererComponent;

    // Karakterin hareket hýzý
    private float moveSpeed = 5f;

    // Karakterin hareket edip edemeyeceðini kontrol eden deðiþken
    private bool canMove = true;

    // Karakterin baktýðý yönü belirlemek için deðiþken
    // 'firing_projectile.cs' gibi ayrý bir scriptte mermilerin hangi yöne atýlacaðýný anlamak için kullanýlýr.
    public bool isfacingright = true; // Eðer bu deðiþken 'false' ise, karakter sola bakýyor demektir.

    // Baþlangýçta bir kere çalýþan metod
    void Start()
    {
        // GameObject'ten SpriteRenderer bileþenini al
        spriteRendererComponent = GetComponent<SpriteRenderer>();

        // SpriteRenderer bileþeni bulunamazsa hata mesajý göster
        if (spriteRendererComponent == null)
        {
            Debug.LogError("SpriteRenderer bileþeni GameObject üzerinde bulunamadý.");
        }
    }

    // Her karede bir kere çalýþan metod
    void Update()
    {
        // Eðer karakter hareket edebiliyorsa
        if (canMove)
        {
            // "A" tuþuna basýlýrsa sola hareket
            if (Input.GetKey(KeyCode.A))
            {
                // Karakteri sola hareket ettir
                transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);

                // Sprite'ý yatayda çevir (sola bak)
                FlipSprite(true);

                // Karakterin sola baktýðýný belirt
                isfacingright = false;
            }

            // "D" tuþuna basýlýrsa saða hareket
            if (Input.GetKey(KeyCode.D))
            {
                // Karakteri saða hareket ettir
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

                // Sprite'ý yatayda çevirme (saða bak)
                FlipSprite(false);

                // Karakterin saða baktýðýný belirt
                isfacingright = true;
            }
        }
    }

    // Karakterin hareket edip edemeyeceðini kontrol eden metod
    public void ToggleMovement(bool allowMovement)
    {
        canMove = allowMovement;
    }

    // Sprite'ý yatayda çevirmek için kullanýlan metod
    private void FlipSprite(bool flip)
    {
        // Sprite'ý yatay eksende çevir (flipX, SpriteRenderer bileþeninde yerleþik bir özelliktir)
        spriteRendererComponent.flipX = flip;
    }
}
