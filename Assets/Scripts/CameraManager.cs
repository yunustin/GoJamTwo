using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public List<Camera> cameras = new List<Camera>(); // Kameralar� tutan liste
    public List<GameObject> characters = new List<GameObject>(); // Karakterleri tutan liste
    private int activeCamIndex = 0;

    private void Start()
    {
        // T�m kameralar� bul ve listeye ekle
        //cameras.AddRange(FindObjectsOfType<Camera>());

        // T�m karakterleri de listeye ekle (Tag ile filtreleme yap�labilir)
       // characters.AddRange(GameObject.FindGameObjectsWithTag("Player"));

        // Ba�lang��ta t�m kameralar� ve karakterleri devre d��� b�rak
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].gameObject.SetActive(false);
            if (i < characters.Count) characters[i].SetActive(false);   
        }

        // �lk kamera ve ona ait karakteri a�
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
            Debug.LogWarning("Ge�ersiz kamera indexi: " + camIndex);
            return;
        }

        // Eski kameray� ve karakteri kapat
        cameras[activeCamIndex].gameObject.SetActive(false);
        if (activeCamIndex < characters.Count) characters[activeCamIndex].SetActive(false);

        // Yeni kameray� ve karakteri a�
        activeCamIndex = camIndex;
        cameras[activeCamIndex].gameObject.SetActive(true);
        if (activeCamIndex < characters.Count) characters[activeCamIndex].SetActive(true);

        Debug.Log("Kamera de�i�ti: " + activeCamIndex);
    }
}
