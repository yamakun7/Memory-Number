using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharengeSecound : MonoBehaviour
{
    public Button[] secoundButton;
    public static int sec_charenge = 1;
    [SerializeField] Text max_scr; //最高スコア


    private void Start()
    {
        sec_charenge = 1;
        secoundButton[1].Select();
        secoundButton[1].onClick.Invoke();
    }

    public void OneSec()
    {
        sec_charenge = 1;
        DeleteColor();
        secoundButton[0].image.color = new Color(255, 0, 0, 255);
        max_scr.text = PlayerPrefs.GetInt("SCORE_1").ToString();
        Debug.Log(sec_charenge);
    }
    public void ThreeSec()
    {
        sec_charenge = 3;
        DeleteColor();
        secoundButton[1].image.color = new Color(255, 0, 0, 255);
        max_scr.text = PlayerPrefs.GetInt("SCORE_3").ToString();
        Debug.Log(sec_charenge);

    }
    public void FiveSec()
    {
        sec_charenge = 5;
        DeleteColor();
        secoundButton[2].image.color = new Color(255, 0, 0, 255);
        max_scr.text = PlayerPrefs.GetInt("SCORE_5").ToString();

    }
    public void SevenSec()
    {
        sec_charenge = 7;
        DeleteColor();
        secoundButton[3].image.color = new Color(255, 0, 0, 255);
        max_scr.text = PlayerPrefs.GetInt("SCORE_7").ToString();
    }

    void DeleteColor()
    {
        foreach (var k in secoundButton)
        {
            k.image.color = new Color(255, 255, 255, 255);
        }
    }
}
