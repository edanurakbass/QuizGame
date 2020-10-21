using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Text dogruTxt, yanlisTxt, puanTxt;

    [SerializeField]
    private GameObject solYildiz, ortaYildiz, sagYildiz;
    public void SonuclariYAzdir( int dogruAdet, int yanlisAdet, int puan)
    {
        dogruTxt.text = dogruAdet.ToString();
        yanlisTxt.text = yanlisAdet.ToString();
        puanTxt.text = puan.ToString();

        solYildiz.SetActive(false);
        ortaYildiz.SetActive(false);
        sagYildiz.SetActive(false);

        if (dogruAdet == 1)
        {
            solYildiz.SetActive(true);
        }
        else if (dogruAdet == 2)
        {
            solYildiz.SetActive(true);
            ortaYildiz.SetActive(true);
        }
        else
        {
            solYildiz.SetActive(true);
            ortaYildiz.SetActive(true);
            sagYildiz.SetActive(false);
        }
    }
}
