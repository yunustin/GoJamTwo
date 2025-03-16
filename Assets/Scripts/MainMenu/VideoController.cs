using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // VideoPlayer bile�eni
    public GameObject menuUI; // Ana men� butonlar�
    public AudioSource menuMusic; // Ana men� m�zi�i
    public TypewriterEffect typewriterEffect; // Daktilo efekti script'i

    void Start()
    {
        // Men� butonlar�n� gizle
        if (menuUI != null)
            menuUI.SetActive(false);

        // Video otomatik oynas�n
        if (videoPlayer != null)
        {
            videoPlayer.Play();
            videoPlayer.loopPointReached += OnVideoFinished; // Video bitince �al��acak fonksiyonu ba�la
        }
    }

    void Update()
    {
        // Space tu�una bas�l�nca videoyu ge�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SkipVideo();
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // Video bitti�inde daktilo efekti ba�lat
        videoPlayer.gameObject.SetActive(false); // Video objesini tamamen kapat
        ShowMenu(); // Men� butonlar�n� a�

        if (typewriterEffect != null)
        {
            typewriterEffect.StartTypingAfterVideo();
        }

        // M�zik �almaya ba�la
        if (menuMusic != null && !menuMusic.isPlaying)
        {
            menuMusic.Play(); // M�zik �al
        }
    }

    void SkipVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop(); // Video durdurulur
            ShowMenu(); // Men� butonlar�n� g�ster

            if (typewriterEffect != null)
            {
                typewriterEffect.StartTypingAfterVideo(); // Daktilo efekti ba�lat�l�r
            }
        }
    }

    void ShowMenu()
    {
        if (menuUI != null)
            menuUI.SetActive(true);
    }
}
