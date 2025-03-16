using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
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

    // Bu fonksiyonlar, di�er s�n�flardan ilgili item'i al�p bool de�erini a�acak
    public void SetFlashlight(bool value) { flashlight = value; }
    public void SetKukla(bool value) { kukla = value; }
    public void SetTrambolin(bool value) { trambolin = value; }
    public void SetK�rba�(bool value) { k�rba� = value; }
    public void SetYiyecek(bool value) { yiyecek = value; }
    public void SetKar�(bool value) { kar� = value; }
    public void SetTarak(bool value) { tarak = value; }
    public void Set�i�ek(bool value) { �i�ek = value; }
    public void SetSigara(bool value) { sigara = value; }
}
