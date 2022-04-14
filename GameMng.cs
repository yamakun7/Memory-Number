using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//数字があっているかどうかは乱数をテキストに上書きしてそのテキストで判定している
public class GameMng : MonoBehaviour
{
    public Text[] texts_3; //表示するテキスト
    public Text[] texts_4;
    public Text[] texts_5;
    public Text[] texts_6;
    public Text[] texts_7;
    public Text[] texts_8;
    public Text[] texts_9;

    public Text score;
    int[] arr = new int[15];

    public int touch_cnt; //数の判定
    public int charenge_scr;
    public int charenge_stage_sum;
    private bool isTouchOk; //タッチの判定可能
    public Text countDown;
    public static bool isCharengeMode;
    public int charenge_sec; //チャレンジモードの時間
    public int time = 0;

    private void Start()
    {
        Debug.Log("STARRRRRRRRRRRRRRRRRRRRRRRRRRRRRTTTTTT");
        charenge_scr = 0;
        charenge_stage_sum = 0;
        touch_cnt = 1; //スタートの値を1にする
        isTouchOk = false; //タッチできないようにする
        countDown.text = "";
        switch (ModeButtonScript.mode)
        {
            case 3:
                foreach (var k in texts_3)
                {
                    k.text = "";
                }
                break;
            case 4:
                foreach (var k in texts_4)
                {
                    k.text = "";
                }
                break;
            case 5:
                foreach (var k in texts_5)
                {
                    k.text = "";
                }
                break;
            case 6:
                foreach (var k in texts_6)
                {
                    k.text = "";
                }
                break;
            case 7:
                foreach (var k in texts_7)
                {
                    k.text = "";
                }
                break;
            case 8:
                foreach (var k in texts_8)
                {
                    k.text = "";
                }
                break;
            case 9:
                foreach (var k in texts_9)
                {
                    k.text = "";
                }
                break;
        }
        StartCoroutine("WaitDisplay");
    }

    private void Update()
    {
        if (isTouchOk)
        {
            switch (ModeButtonScript.mode)
            {
                case 3:
                    Touch(3);
                    break;
                case 4:
                    Touch(4);
                    break;
                case 5:
                    Touch(5);
                    break;
                case 6:
                    Touch(6);
                    break;
                case 7:
                    Touch(7);
                    break;
                case 8:
                    Touch(8);
                    break;
                case 9:
                    Touch(9); //タッチされたかを毎時判定する
                    break;
            }
        }
    }

    //ランダムに生成した値を画面に表示させる
    public void OutNumber()
    {
        CreateNum createNum = new CreateNum();
        if (isCharengeMode)
        {
          //  ModeButtonScript.mode = Random.Range(3, 9);
            Debug.Log("MOOOOOOOOOOOOOOOOOODdddd" + ModeButtonScript.mode);
            createNum.CreateRandom(1, ModeButtonScript.mode);
        }
        else
        {
            createNum.CreateRandom(1, ModeButtonScript.mode);
        }

        arr = createNum.arr;
        int p = 0;
        foreach (var k in arr)
        {
            Debug.Log($"arr[{p}] : {k}");
            p++;
        }
        switch (ModeButtonScript.mode)
        {
            case 3:
                for (int i = 0; i < 3; i++)
                {
                    texts_3[i].text = arr[i].ToString();
                }
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                {
                    texts_4[i].text = arr[i].ToString();
                }
                break;
            case 5:
                for (int i = 0; i < 5; i++)
                {
                    texts_5[i].text = arr[i].ToString();
                }
                break;
            case 6:
                for (int i = 0; i < 6; i++)
                {
                    texts_6[i].text = arr[i].ToString();
                }
                break;
            case 7:
                for (int i = 0; i < 7; i++)
                {
                    texts_7[i].text = arr[i].ToString();
                }
                break;
            case 8:
                for (int i = 0; i < 8; i++)
                {
                    texts_8[i].text = arr[i].ToString();
                }
                break;
            case 9:
                for (int i = 0; i < 9; i++)
                {
                    texts_9[i].text = arr[i].ToString();
                }
                break;
        }

    }


    

    public void Touch(int length)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            if (hit2D.collider)
            {
                GameObject array_obj = hit2D.collider.gameObject; //タッチしたgameobject取得
                Text num_text = array_obj.GetComponentInChildren<Text>(); //タッチしたgameobjectのTextを取得
                int touch_index = int.Parse(num_text.text); //そのテキストをint型で取得
                int index = int.Parse(array_obj.name); //arr_objの名前の数字ー１が添え字になる
                Debug.Log("index" + index + "    touch_cnt" + touch_cnt);
                UiManager ui = GetComponent<UiManager>();
                if (touch_index == touch_cnt) //正解
                {
                    ui.OpenNumber(index-1); //タッチした番号を開示する。index-1はタッチした配列の添え字
                    Debug.Log("正解");
                    touch_cnt++; //1から増えていく
                    charenge_scr++; //得点
                    ui.score.text = charenge_scr.ToString();
                    Debug.Log("得点"+charenge_scr);

                }
                else //失敗
                {
                    isTouchOk = false;
                    ui.StartCoroutine(ui.GameOver(index - 1));
                }
                //すべて押せたら
                if (touch_cnt == length + 1)
                {
                    Debug.Log("CLEAR");
                    isTouchOk = false;
                    if (isCharengeMode) //チャレンジモードの時
                    {
                        //次のステージの準備
                        touch_cnt = 1; //スタートの値を1にする
                        StartCoroutine("WaitDisplay");
                    }
                    else //トレーニングモードの時
                    {
                        ui.StartCoroutine("ClearUi");
                    }
                }
            }
        }
    }

    //画面表示から画面を隠してタッチ可能までの制御
    IEnumerator WaitDisplay()
    {
        yield return null;
        Debug.Log("CHARENGEMODEEEEEEEE" + isCharengeMode);
        UiManager ui = GetComponent<UiManager>();
        

        if (isCharengeMode)
        {
            if (charenge_stage_sum != 0)
            {
                yield return new WaitForSeconds(1);
            }
            charenge_stage_sum++;
            ModeButtonScript.mode = Random.Range(3, 10);
            
            if (GameMng.isCharengeMode)
            {
                time = CharengeSecound.sec_charenge;
            }
            else
            {
                time = SecoundButton.sec;
            }
        }
        else
        {
            time = SecoundButton.sec;
        }
        ui.HidePanelAll();
        ui.DisplayPanel();
        ui.HideNumber();


        yield return new WaitForSeconds(0.7f);
        countDown.text = "3";
        yield return new WaitForSeconds(1);
        countDown.text = "2";
        yield return new WaitForSeconds(1);
        countDown.text = "1";
        yield return new WaitForSeconds(1);
        countDown.text = "";
        OutNumber();
        ui.FullOpenNumber();
        
        switch (time)
        {
            case 1:
                yield return new WaitForSeconds(1);
                break;
            case 3:
                yield return new WaitForSeconds(3);
                break;
            case 5:
                yield return new WaitForSeconds(5);
                break;
            case 7:
                yield return new WaitForSeconds(7);
                break;

        }
        Debug.Log("WAIT NOW!");
        ui.HideNumber();
        isTouchOk = true;

    }


}
