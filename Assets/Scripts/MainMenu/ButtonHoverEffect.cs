using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverObject1; // �lk obje
    public GameObject hoverObject2; // �kinci obje

    private void Start()
    {
        // Ba�lang��ta objeleri gizle
        if (hoverObject1) hoverObject1.SetActive(false);
        if (hoverObject2) hoverObject2.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Butonun �zerine gelince objeleri aktif et
        if (hoverObject1) hoverObject1.SetActive(true);
        if (hoverObject2) hoverObject2.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Butondan ��k�nca objeleri tekrar gizle
        if (hoverObject1) hoverObject1.SetActive(false);
        if (hoverObject2) hoverObject2.SetActive(false);
    }
}
