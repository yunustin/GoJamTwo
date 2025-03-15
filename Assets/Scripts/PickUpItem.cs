using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Transform targetPosition; // Objeyi ta��yaca��m�z hedef nokta (�rne�in karakterin eli)
    public float moveSpeed = 5f; // Objeyi ta��rken kullan�lan h�z
    private bool isPickedUp = false; // Objenin elde olup olmad���n� kontrol eder
    private Transform originalParent; // Objeyi b�rak�rken eski parent'�na geri d�nd�rmek i�in
    private Vector3 originalPosition; // Objeyi b�rak�rken eski konumuna geri d�nd�rmek i�in

    void Start()
    {
        originalParent = transform.parent; // Objeyi ald���m�zda eski parent'� sakla
        originalPosition = transform.position; // �lk konumu sakla
    }

    public void PickUpThisItem(GameObject item)
    {
        isPickedUp = true;
        StartCoroutine(MoveItemSmoothly(item, targetPosition.position)); // Objeyi yumu�ak �ekilde ta��
        item.transform.SetParent(targetPosition); // Objeyi karaktere ba�la
    }

    public void PutDownItem()
    {
        isPickedUp = false;
        transform.SetParent(null); // Objeyi serbest b�rak
        StartCoroutine(MoveItemSmoothly(gameObject, originalPosition)); // Objeyi eski yerine smooth d�nd�r
    }

    public bool IsPickedUp()
    {
        return isPickedUp;
    }

    private IEnumerator MoveItemSmoothly(GameObject item, Vector3 targetPos)
    {
        float elapsedTime = 0f;
        float duration = 0.2f; // Hareketin s�resi (0.5 saniye)
        Vector3 startPos = item.transform.position;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration; // 0 ile 1 aras�nda bir de�er
            item.transform.position = Vector3.Lerp(startPos, targetPos, t); // Pozisyonu yumu�ak�a de�i�tir
            yield return null;
        }

        item.transform.position = targetPos; // Son pozisyonu tam olarak ayarla
    }
}
