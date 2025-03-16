using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float characterDelay = 0.05f; // H�zl� yazma gecikmesi
    public float commandDelay = 0.3f; // A:\> sonras� buton a��lma s�resi
    public Button startButton;
    public Button settingsButton;
    public Button quitButton;

    private string fullText =
@"Initializing system...
Checking hardware...
Loading OS kernel...
Memory check: OK
Floppy Drive: A:\ detected
CD-ROM: Not found
Entering setup mode...


A:\> 




A:\>




A:\>                                                                              



                                                                                                                
                                                                                               


                                                                                                

                                                                                                            0xDEADBEEF";

    private int promptCount = 0;

    void Start()
    {
        textComponent.text = "";
        startButton.gameObject.SetActive(false);
        settingsButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    // Video bitti�inde veya skip yap�ld���nda daktilo efekti ba�las�n
    public void StartTypingAfterVideo()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        string currentText = "";

        foreach (char c in fullText)
        {
            currentText += c;
            textComponent.text = currentText;
            yield return new WaitForSeconds(characterDelay);

            // "A:\>" tamamland���nda butonlar� s�rayla a�
            if (currentText.EndsWith("A:\\>"))
            {
                promptCount++;
                yield return new WaitForSeconds(commandDelay); // Biraz gecikme ekleyerek efektin g�zel g�r�nmesini sa�la

                if (promptCount == 1)
                    startButton.gameObject.SetActive(true);
                else if (promptCount == 2)
                    settingsButton.gameObject.SetActive(true);
                else if (promptCount == 3)
                    quitButton.gameObject.SetActive(true);
            }
        }
    }
}
