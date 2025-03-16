using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private bool flashlight;
    [SerializeField] private bool kukla;
    [SerializeField] private bool trambolin;
    [SerializeField] private bool kýrbaç;
    [SerializeField] private bool yiyecek;
    [SerializeField] private bool karý;
    [SerializeField] private bool tarak;
    [SerializeField] private bool çiçek;
    [SerializeField] private bool sigara;

    // Bu fonksiyonlar, diðer sýnýflardan ilgili item'i alýp bool deðerini açacak
    public void SetFlashlight(bool value) { flashlight = value; }
    public void SetKukla(bool value) { kukla = value; }
    public void SetTrambolin(bool value) { trambolin = value; }
    public void SetKýrbaç(bool value) { kýrbaç = value; }
    public void SetYiyecek(bool value) { yiyecek = value; }
    public void SetKarý(bool value) { karý = value; }
    public void SetTarak(bool value) { tarak = value; }
    public void SetÇiçek(bool value) { çiçek = value; }
    public void SetSigara(bool value) { sigara = value; }
}
