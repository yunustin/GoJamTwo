using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCheck : MonoBehaviour
{
    public static PlayerItemCheck instance; // Singleton kullanarak eriþimi kolaylaþtýrýyoruz

    public bool ElindeObjeVar = false; // Oyuncunun elinde obje var mý?

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Elinde obje var mý kontrol et
    public bool CanPickUpItem()
    {
        return !ElindeObjeVar;
    }

    // Objeyi aldýðýnda
    public void SetItemPickedUp(bool pickedUp)
    {
        ElindeObjeVar = pickedUp;
    }
}
