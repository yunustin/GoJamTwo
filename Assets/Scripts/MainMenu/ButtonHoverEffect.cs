using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverObject1; // Ýlk obje
    public GameObject hoverObject2; // Ýkinci obje

    private void Start()
    {
        // Baþlangýçta objeleri gizle
        if (hoverObject1) hoverObject1.SetActive(false);
        if (hoverObject2) hoverObject2.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Butonun üzerine gelince objeleri aktif et
        if (hoverObject1) hoverObject1.SetActive(true);
        if (hoverObject2) hoverObject2.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Butondan çýkýnca objeleri tekrar gizle
        if (hoverObject1) hoverObject1.SetActive(false);
        if (hoverObject2) hoverObject2.SetActive(false);
    }
}
