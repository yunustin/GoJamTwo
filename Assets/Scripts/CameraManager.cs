using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public List<Camera> cameras = new List<Camera>(); // Kameralarý tutan liste
    public List<GameObject> characters = new List<GameObject>(); // Karakterleri tutan liste
    private int activeCamIndex = 0;

    private void Start()
    {
        // Tüm kameralarý bul ve listeye ekle
        //cameras.AddRange(FindObjectsOfType<Camera>());

        // Tüm karakterleri de listeye ekle (Tag ile filtreleme yapýlabilir)
       // characters.AddRange(GameObject.FindGameObjectsWithTag("Player"));

        // Baþlangýçta tüm kameralarý ve karakterleri devre dýþý býrak
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].gameObject.SetActive(false);
            if (i < characters.Count) characters[i].SetActive(false);   
        }

        // Ýlk kamera ve ona ait karakteri aç
        if (cameras.Count > 0)
        {
            cameras[0].gameObject.SetActive(true);
            if (characters.Count > 0) characters[0].SetActive(true);
        }
    }

    public void CamSwitch(int camIndex)
    {
        if (camIndex < 0 || camIndex >= cameras.Count)
        {
            Debug.LogWarning("Geçersiz kamera indexi: " + camIndex);
            return;
        }

        // Eski kamerayý ve karakteri kapat
        cameras[activeCamIndex].gameObject.SetActive(false);
        if (activeCamIndex < characters.Count) characters[activeCamIndex].SetActive(false);

        // Yeni kamerayý ve karakteri aç
        activeCamIndex = camIndex;
        cameras[activeCamIndex].gameObject.SetActive(true);
        if (activeCamIndex < characters.Count) characters[activeCamIndex].SetActive(true);

        Debug.Log("Kamera deðiþti: " + activeCamIndex);
    }
}
