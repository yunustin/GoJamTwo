using UnityEngine;

public class PlayerItemCheck : MonoBehaviour
{
    public static PlayerItemCheck instance;

    private bool itemPickedUp = false;

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

    public bool HasItem()
    {
        return itemPickedUp;
    }
}
