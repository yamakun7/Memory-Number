using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SecoundButton : MonoBehaviour
{
    public Button[] secoundButton;
    public static int sec=1;
    private void Start()
    {
        sec = 1;
        secoundButton[1].Select();
        secoundButton[1].onClick.Invoke();
    }

    public void OneSec()
    {
        sec = 1;
        DeleteColor();
        secoundButton[0].image.color = new Color(255, 0, 0, 255);
        Debug.Log(sec);
    }
    public void ThreeSec()
    {
        sec = 3;
        DeleteColor();
        secoundButton[1].image.color = new Color(255, 0, 0, 255);
        Debug.Log(sec);

    }
    public void FiveSec()
    {
        sec = 5;
        DeleteColor();
        secoundButton[2].image.color = new Color(255, 0, 0, 255);
        Debug.Log(sec);

    }
    public void SevenSec()
    {
        sec = 7;
        DeleteColor();
        secoundButton[3].image.color = new Color(255, 0, 0, 255);
        Debug.Log(sec);

    }

    void DeleteColor()
    {
            foreach(var k in secoundButton)
        {
            k.image.color = new Color(255, 255, 255, 255);
        }
    }
}
