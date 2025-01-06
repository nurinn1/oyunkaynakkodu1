using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hitpoints_system : MonoBehaviour
{
    // D��man�n can puan� (ba�lang�� de�eri: 3)
    public int hitpoints = 3;

    // Ba�lang��ta bir kez �al��t�r�lan metod
    void Start()
    {
        // Not: 'gameObject', bu scriptin ba�l� oldu�u GameObject'i temsil eder. 
        // Bu referans kullan�larak GameObject �zerinde �e�itli i�lemler yap�labilir.

        // Bu �ekilde bu C# scriptinin ba�l� oldu�u GameObject'e bir referans olu�turabilirsiniz.
        // GameObject thisGameObject = gameObject;
    }

    // Her karede bir kez �al��an metod
    void Update()
    {
        // E�er d��man�n can puan� s�f�ra ula��rsa
        if (hitpoints <= 0)
        {
            // GameObject'i yok et (d��man� sahneden kald�r)
            Destroy(gameObject);

            // Konsola d��man�n �ld���ne dair mesaj yazd�r
            print("Bir d��man �ld�r�ld�!");
        }
    }

    // Ba�ka bir nesneyle �arp��ma ger�ekle�ti�inde �al��an metod
    void OnCollisionEnter2D(Collision2D other)
    {
        // �arp���lan nesnenin etiketi 'arrow' ise
        if (other.gameObject.CompareTag("arrow"))
        {
            // Ok ile �arp��ma durumunu i�leyen kod
            // �rne�in, can puan�n� azaltabilir veya hasar animasyonunu tetikleyebilirsiniz
            TakeDamage();
        }
    }

    // Hasar alma i�lemini ger�ekle�tiren metod
    void TakeDamage()
    {
        // D��man�n can puan�n� 1 azalt
        hitpoints--;

        // Konsola d��man�n hasar ald���na dair mesaj yazd�r
        print("Bir d��man hasar ald�!");
    }
}
