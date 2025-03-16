using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
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

    // Her bir item için setter metodlarý ekleyin
    public void SetFlashlight(bool value) { flashlight = value; }
    public void SetKukla(bool value) { kukla = value; }
    public void SetTrambolin(bool value) { trambolin = value; }
    public void SetKýrbaç(bool value) { kýrbaç = value; }
    public void SetYiyecek(bool value) { yiyecek = value; }
    public void SetKarý(bool value) { karý = value; }
    public void SetTarak(bool value) { tarak = value; }
    public void SetÇiçek(bool value) { çiçek = value; }
    public void SetSigara(bool value) { sigara = value; }

    // Her bir itemin durumunu almanýza olanak tanýyan getter metodlarý
    public bool GetFlashlight() { return flashlight; }
    public bool GetKukla() { return kukla; }
    public bool GetTrambolin() { return trambolin; }
    public bool GetKýrbaç() { return kýrbaç; }
    public bool GetYiyecek() { return yiyecek; }
    public bool GetKarý() { return karý; }
    public bool GetTarak() { return tarak; }
    public bool GetÇiçek() { return çiçek; }
    public bool GetSigara() { return sigara; }
}
