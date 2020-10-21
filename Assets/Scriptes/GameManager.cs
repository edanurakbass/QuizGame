using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public Soru[] sorular;
    private static List<Soru> cevaplanmamisSorular;

    private Soru gecerliSoru;

    [SerializeField]
    private Text soruText;

    [SerializeField]
    private Text dogruCvpTxt, yanlisCvpTxt;

    [SerializeField]
    private GameObject dogruBtn, yanlisBtn;

    int dogruAdet, yanlisAdet;
    int toplamPuan;

    [SerializeField]
    private GameObject sonucPaneli;

    SonucManager sonucManager;

    void Start()
    {
        if (cevaplanmamisSorular == null || cevaplanmamisSorular.Count == 0)
        {
            cevaplanmamisSorular = sorular.ToList<Soru>();
        }
        yanlisAdet = 0;
        dogruAdet = 0;
        toplamPuan = 0;

        RastgeleSoruSec();
        
    }

    void RastgeleSoruSec()
    {
        yanlisBtn.GetComponent<RectTransform>().DOLocalMoveX(320f, .2f);
        dogruBtn.GetComponent<RectTransform>().DOLocalMoveX(-320f, .2f);
        int randomSoruIndex = Random.Range(0, cevaplanmamisSorular.Count);
        gecerliSoru = cevaplanmamisSorular[randomSoruIndex];

        soruText.text = gecerliSoru.soru;

        if (gecerliSoru.dogruMu)
        {
            dogruCvpTxt.text = "DOGRU CEVAPLADINIZ";
            yanlisCvpTxt.text = "YANLIS CEVAPLADINIZ";
        }
        else
        {
            dogruCvpTxt.text = "YANLIS CEVAPLADINIZ";
            yanlisCvpTxt.text = "DOGRU CEVAPLADINIZ";
        }
    }

    IEnumerator SorularArasiBekleRoutine()
    {
        cevaplanmamisSorular.Remove(gecerliSoru);
        yield return new WaitForSeconds(1f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        if (cevaplanmamisSorular.Count <= 0)
        {
            sonucPaneli.SetActive(true);

            sonucManager = Object.FindObjectOfType<SonucManager>();
            sonucManager.SonuclariYAzdir(dogruAdet, yanlisAdet, toplamPuan);
        }
        else
        {
            RastgeleSoruSec();
        }

    }
    public void DogruButonBasildi()
    {
        if (gecerliSoru.dogruMu)
        {
            dogruAdet++;
            toplamPuan += 100;
        }
        else
        {
            yanlisAdet++;
        }
        yanlisBtn.GetComponent<RectTransform>().DOLocalMoveX(1000f,.3f);
        StartCoroutine(SorularArasiBekleRoutine());
    }

    public void YanlisButonBasildi()
    {
        if (!gecerliSoru.dogruMu)
        {
           dogruAdet++;
            toplamPuan += 100;
        }
        else
        {
            yanlisAdet++;
        }

        dogruBtn.GetComponent<RectTransform>().DOLocalMoveX(-1000f,.3f);
        StartCoroutine(SorularArasiBekleRoutine());
    }
    
}
