using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hitpoints_system : MonoBehaviour
{
    // Düþmanýn can puaný (baþlangýç deðeri: 3)
    public int hitpoints = 3;

    // Baþlangýçta bir kez çalýþtýrýlan metod
    void Start()
    {
        // Not: 'gameObject', bu scriptin baðlý olduðu GameObject'i temsil eder. 
        // Bu referans kullanýlarak GameObject üzerinde çeþitli iþlemler yapýlabilir.

        // Bu þekilde bu C# scriptinin baðlý olduðu GameObject'e bir referans oluþturabilirsiniz.
        // GameObject thisGameObject = gameObject;
    }

    // Her karede bir kez çalýþan metod
    void Update()
    {
        // Eðer düþmanýn can puaný sýfýra ulaþýrsa
        if (hitpoints <= 0)
        {
            // GameObject'i yok et (düþmaný sahneden kaldýr)
            Destroy(gameObject);

            // Konsola düþmanýn öldüðüne dair mesaj yazdýr
            print("Bir düþman öldürüldü!");
        }
    }

    // Baþka bir nesneyle çarpýþma gerçekleþtiðinde çalýþan metod
    void OnCollisionEnter2D(Collision2D other)
    {
        // Çarpýþýlan nesnenin etiketi 'arrow' ise
        if (other.gameObject.CompareTag("arrow"))
        {
            // Ok ile çarpýþma durumunu iþleyen kod
            // Örneðin, can puanýný azaltabilir veya hasar animasyonunu tetikleyebilirsiniz
            TakeDamage();
        }
    }

    // Hasar alma iþlemini gerçekleþtiren metod
    void TakeDamage()
    {
        // Düþmanýn can puanýný 1 azalt
        hitpoints--;

        // Konsola düþmanýn hasar aldýðýna dair mesaj yazdýr
        print("Bir düþman hasar aldý!");
    }
}
