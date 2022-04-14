using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    public Image[] cover_images_3;
    public Image[] cover_images_4;
    public Image[] cover_images_5;
    public Image[] cover_images_6;
    public Image[] cover_images_7;
    public Image[] cover_images_8;
    public Image[] cover_images_9;

    [SerializeField] GameObject[] panel_mode;
    [SerializeField] GameObject clearPanel;

    public Text score;
    public Text ResultScore;
    private void Start()
    {
        clearPanel.gameObject.SetActive(false);
        HidePanelAll();
        score.text = "0";
        ResultScore.text = "";
       // DisplayPanel();
    }

    public void HidePanelAll()
    {
        foreach (var k in panel_mode)
        {
            k.SetActive(false);
        }
    }
    //選択されたモードのパネルを表示する
    public void DisplayPanel()
    {
        //選択されたモードのパネルを表示する
        switch (ModeButtonScript.mode)
        {
            case 3:
                panel_mode[0].SetActive(true);
                break;
            case 4:
                panel_mode[1].SetActive(true);
                break;
            case 5:
                panel_mode[2].SetActive(true);
                break;
            case 6:
                panel_mode[3].SetActive(true);
                break;
            case 7:
                panel_mode[4].SetActive(true);
                break;
            case 8:
                panel_mode[5].SetActive(true);
                break;
            case 9:
                panel_mode[6].SetActive(true);
                break;
        }
    }

    //数をすべて隠す
    public void HideNumber()
    {
        switch (ModeButtonScript.mode)
        {
            case 3:
                foreach (var k in cover_images_3)
                {
                    k.gameObject.SetActive(true);

                }
                break;
            case 4:
                foreach (var k in cover_images_4)
                {
                    k.gameObject.SetActive(true);
                }
                break;
            case 5:
                foreach (var k in cover_images_5)
                {
                    k.gameObject.SetActive(true);
                }
                break;
            case 6:
                foreach (var k in cover_images_6)
                {
                    k.gameObject.SetActive(true);
                }
                break;
            case 7:
                foreach (var k in cover_images_7)
                {
                    k.gameObject.SetActive(true);
                }
                break;
            case 8:
                foreach (var k in cover_images_8)
                {
                    k.gameObject.SetActive(true);
                }
                break;
            case 9:
                foreach (var k in cover_images_9)
                {
                    k.gameObject.SetActive(true);
                }
                break;
        }
    }

    //一つの数を表示する
    //引数はタッチした番号の配列の添え字
    public void OpenNumber(int idx)
    {
        switch (ModeButtonScript.mode)
        {
            case 3:
                cover_images_3[idx].gameObject.SetActive(false);
                break;
            case 4:
                cover_images_4[idx].gameObject.SetActive(false);
                break;
            case 5:
                cover_images_5[idx].gameObject.SetActive(false);
                break;
            case 6:
                cover_images_6[idx].gameObject.SetActive(false);
                break;
            case 7:
                cover_images_7[idx].gameObject.SetActive(false);
                break;
            case 8:
                cover_images_8[idx].gameObject.SetActive(false);
                break;
            case 9:
                cover_images_9[idx].gameObject.SetActive(false);
                break;
        }
    }

    //数をすべてオープンする
    public void FullOpenNumber()
    {
        Debug.Log("Mode : "+ModeButtonScript.mode);
        switch (ModeButtonScript.mode)
        {
            case 3:
                foreach (var k in cover_images_3)
                {
                    k.gameObject.SetActive(false);
                    
                }
                break;
            case 4:
                foreach (var k in cover_images_4)
                {
                    k.gameObject.SetActive(false);
                }
                break;
            case 5:
                foreach (var k in cover_images_5)
                {
                    k.gameObject.SetActive(false);
                }
                break;
            case 6:
                foreach (var k in cover_images_6)
                {
                    k.gameObject.SetActive(false);
                }
                break;
            case 7:
                foreach (var k in cover_images_7)
                {
                    k.gameObject.SetActive(false);
                }
                break;
            case 8:
                foreach (var k in cover_images_8)
                {
                    k.gameObject.SetActive(false);
                }
                break;
            case 9:
                foreach (var k in cover_images_9)
                {
                    k.gameObject.SetActive(false);
                }
                break;
        }
       
    }


    public IEnumerator ClearUi()
    {
        yield return null;
        yield return new WaitForSeconds(1);
        clearPanel.gameObject.SetActive(true);
        ResultScore.text = "SCORE  " + GetComponent<GameMng>().charenge_scr.ToString();
       // SaveScore(max_num, max_num);
        
    }

    public IEnumerator GameOver(int open_num)
    {
        yield return null;
        OpenNumber(open_num);
        yield return new WaitForSeconds(1);
        FullOpenNumber();
        clearPanel.gameObject.SetActive(true);
        GameMng game = GetComponent<GameMng>();
        ResultScore.text = "SCORE  " + game.charenge_scr.ToString();
        SaveScore(game.time,game.charenge_scr);
    }

    
    private void SaveScore(int sec, int scr)
    {
        int high_scr = 0;
        string key = "";
        switch (sec)
        {
            case 1:      
                key = "SCORE_1";
                break;
            case 3:
                key = "SCORE_3";
                break;
            case 5:
                key = "SCORE_5";
                break;
            case 7:
                key = "SCORE_7";
                break;
        }
        if (PlayerPrefs.HasKey(key))
        {
            high_scr = PlayerPrefs.GetInt(key);
        }
        if (high_scr < scr)
        {
            PlayerPrefs.SetInt(key, scr);
        }
    }
    

}
