using UnityEngine;

public class PlayerItemCheck : MonoBehaviour
{
    public static PlayerItemCheck instance;

    private bool itemPickedUp = false; // Oyuncunun elinde item olup olmadýðýný tutar

    private void Awake()
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

    public void SetItemPickedUp(bool pickedUp)
    {
        itemPickedUp = pickedUp;
    }

    public bool HasItem() // Eksik olan metod eklendi
    {
        return itemPickedUp;
    }
}
