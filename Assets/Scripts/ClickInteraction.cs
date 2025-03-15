using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInteraction : MonoBehaviour
{
    public Material highlightMaterial; // Inspector'dan atanacak materyal
    private Material originalMaterial;
    private Renderer objRenderer;
    public GameObject character;
    private GridMovement gridMov; // Burada doðru isimlendirilmiþ
    public Vector2Int objectTilePosition; // Her obje için belirlenebilir tile

    private PickUpItem pickUpItemScript; // PickUpItem scriptini tutacak referans

    void Start()
    {
        // GridMovement scriptini alýyoruz ve null kontrolü yapýyoruz
        if (character != null)
        {
            gridMov = character.GetComponent<GridMovement>();
        }

        objRenderer = GetComponent<Renderer>();

        if (objRenderer != null)
        {
            originalMaterial = objRenderer.material;
        }

        // PickUpItem ve ItemPutAway scriptlerine eriþim
        pickUpItemScript = GetComponent<PickUpItem>();

        // gridMov null ise log yazýlabilir
        if (gridMov != null)
        {
            Debug.Log(gridMov.currentTilePosition);
        }
        else
        {
            Debug.LogWarning("GridMovement component not found on the character.");
        }
    }

    void OnMouseDown()
    {
        // Null kontrolü eklenmiþ
        if (gridMov != null && PlayerItemCheck.instance.CanPickUpItem() && gridMov.currentTilePosition == objectTilePosition)
        {
            Debug.Log("Objeye týkladýn: " + gameObject.name);

            // Objeyi aldýktan sonra PlayerItemCheck'e bildir
            PlayerItemCheck.instance.SetItemPickedUp(true);

            // PickUpItem scriptine objeyi ilet
            if (pickUpItemScript != null)
            {
                pickUpItemScript.PickUpThisItem(gameObject); // PickUpItem scriptindeki metodu çaðýr
            }
        }
    }

    void OnMouseEnter()
    {
        // GridMovement script'inden tile bilgilerini kontrol et
        if (gridMov != null && gridMov.currentTilePosition == objectTilePosition)
        {
            if (highlightMaterial != null && objRenderer != null)
            {
                objRenderer.material = highlightMaterial;
            }
        }
    }

    void OnMouseExit()
    {
        if (originalMaterial != null && objRenderer != null)
        {
            objRenderer.material = originalMaterial;
        }
    }
}
