using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Transform targetPosition; // Objeyi taþýyacaðýmýz hedef nokta (örneðin karakterin eli)
    public float moveSpeed = 5f; // Objeyi taþýrken kullanýlan hýz
    private bool isPickedUp = false; // Objenin elde olup olmadýðýný kontrol eder
    private Transform originalParent; // Objeyi býrakýrken eski parent'ýna geri döndürmek için
    private Vector3 originalPosition; // Objeyi býrakýrken eski konumuna geri döndürmek için

    void Start()
    {
        originalParent = transform.parent; // Objeyi aldýðýmýzda eski parent'ý sakla
        originalPosition = transform.position; // Ýlk konumu sakla
    }

    public void PickUpThisItem(GameObject item)
    {
        isPickedUp = true;
        StartCoroutine(MoveItemSmoothly(item, targetPosition.position)); // Objeyi yumuþak þekilde taþý
        item.transform.SetParent(targetPosition); // Objeyi karaktere baðla
    }

    public void PutDownItem()
    {
        isPickedUp = false;
        transform.SetParent(null); // Objeyi serbest býrak
        StartCoroutine(MoveItemSmoothly(gameObject, originalPosition)); // Objeyi eski yerine smooth döndür
    }

    public bool IsPickedUp()
    {
        return isPickedUp;
    }

    private IEnumerator MoveItemSmoothly(GameObject item, Vector3 targetPos)
    {
        float elapsedTime = 0f;
        float duration = 0.2f; // Hareketin süresi (0.5 saniye)
        Vector3 startPos = item.transform.position;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration; // 0 ile 1 arasýnda bir deðer
            item.transform.position = Vector3.Lerp(startPos, targetPos, t); // Pozisyonu yumuþakça deðiþtir
            yield return null;
        }

        item.transform.position = targetPos; // Son pozisyonu tam olarak ayarla
    }
}
