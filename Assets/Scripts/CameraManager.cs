using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public List<Camera> cameras = new List<Camera>(); // Kameralar� burada tutuyoruz
    private int activeCamIndex = 0;

    private void Start()
    {
        // Ba�lang��ta t�m kameralar� listeye ekleyelim
        cameras.AddRange(FindObjectsOfType<Camera>());

        // B�t�n kameralar� kapat�p sadece ilk kameray� a�al�m
        foreach (Camera cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }

        if (cameras.Count > 0)
        {
            cameras[0].gameObject.SetActive(true);
        }
    }

    public void CamSwitch(int camIndex)
    {
        if (camIndex < 0 || camIndex >= cameras.Count)
        {
            Debug.LogWarning("Ge�ersiz kamera indexi: " + camIndex);
            return;
        }

        // �u anki kameray� kapat
        cameras[activeCamIndex].gameObject.SetActive(false);

        // Yeni kameray� a�
        activeCamIndex = camIndex;
        cameras[activeCamIndex].gameObject.SetActive(true);

        Debug.Log("Kamera de�i�ti: " + activeCamIndex);
    }
}
