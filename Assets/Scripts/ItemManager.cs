using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private bool flashlight;
    [SerializeField] private bool kukla;
    [SerializeField] private bool trambolin;
    [SerializeField] private bool k�rba�;
    [SerializeField] private bool yiyecek;
    [SerializeField] private bool kar�;
    [SerializeField] private bool tarak;
    [SerializeField] private bool �i�ek;
    [SerializeField] private bool sigara;

    // Her bir item i�in setter metodlar� ekleyin
    public void SetFlashlight(bool value) { flashlight = value; }
    public void SetKukla(bool value) { kukla = value; }
    public void SetTrambolin(bool value) { trambolin = value; }
    public void SetK�rba�(bool value) { k�rba� = value; }
    public void SetYiyecek(bool value) { yiyecek = value; }
    public void SetKar�(bool value) { kar� = value; }
    public void SetTarak(bool value) { tarak = value; }
    public void Set�i�ek(bool value) { �i�ek = value; }
    public void SetSigara(bool value) { sigara = value; }

    // Her bir itemin durumunu alman�za olanak tan�yan getter metodlar�
    public bool GetFlashlight() { return flashlight; }
    public bool GetKukla() { return kukla; }
    public bool GetTrambolin() { return trambolin; }
    public bool GetK�rba�() { return k�rba�; }
    public bool GetYiyecek() { return yiyecek; }
    public bool GetKar�() { return kar�; }
    public bool GetTarak() { return tarak; }
    public bool Get�i�ek() { return �i�ek; }
    public bool GetSigara() { return sigara; }
}
