using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // VideoPlayer bileþeni
    public GameObject menuUI; // Ana menü butonlarý
    public AudioSource menuMusic; // Ana menü müziði
    public TypewriterEffect typewriterEffect; // Daktilo efekti script'i

    void Start()
    {
        // Menü butonlarýný gizle
        if (menuUI != null)
            menuUI.SetActive(false);

        // Video otomatik oynasýn
        if (videoPlayer != null)
        {
            videoPlayer.Play();
            videoPlayer.loopPointReached += OnVideoFinished; // Video bitince çalýþacak fonksiyonu baðla
        }
    }

    void Update()
    {
        // Space tuþuna basýlýnca videoyu geç
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SkipVideo();
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // Video bittiðinde daktilo efekti baþlat
        videoPlayer.gameObject.SetActive(false); // Video objesini tamamen kapat
        ShowMenu(); // Menü butonlarýný aç

        if (typewriterEffect != null)
        {
            typewriterEffect.StartTypingAfterVideo();
        }

        // Müzik çalmaya baþla
        if (menuMusic != null && !menuMusic.isPlaying)
        {
            menuMusic.Play(); // Müzik çal
        }
    }

    void SkipVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop(); // Video durdurulur
            ShowMenu(); // Menü butonlarýný göster

            if (typewriterEffect != null)
            {
                typewriterEffect.StartTypingAfterVideo(); // Daktilo efekti baþlatýlýr
            }
        }
    }

    void ShowMenu()
    {
        if (menuUI != null)
            menuUI.SetActive(true);
    }
}
