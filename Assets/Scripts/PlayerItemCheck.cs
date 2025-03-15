using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCheck : MonoBehaviour
{
    public static PlayerItemCheck instance; // Singleton kullanarak eri�imi kolayla�t�r�yoruz

    public bool ElindeObjeVar = false; // Oyuncunun elinde obje var m�?

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

    // Elinde obje var m� kontrol et
    public bool CanPickUpItem()
    {
        return !ElindeObjeVar;
    }

    // Objeyi ald���nda
    public void SetItemPickedUp(bool pickedUp)
    {
        ElindeObjeVar = pickedUp;
    }
}
