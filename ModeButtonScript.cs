using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeButtonScript : MonoBehaviour
{
    public Button[] modeButton;
    public static int mode = 5;

    private void Start()
    {       
        modeButton[2].Select();
        modeButton[2].onClick.Invoke();
    }
    public void CardMax_3()
    {
        DeleteColor();
        mode = 3;
        modeButton[0].image.color = new Color(255, 0, 0, 255);
    }
    public void CardMax_4()
    {
        DeleteColor();
        mode = 4;
        modeButton[1].image.color = new Color(255, 0, 0, 255);
    }
    public void CardMax_5()
    {
        DeleteColor();
        mode = 5;
        modeButton[2].image.color = new Color(255, 0, 0, 255);
    }
    public void CardMax_6()
    {
        DeleteColor();
        mode = 6;
        modeButton[3].image.color = new Color(255, 0, 0, 255);
    }
    public void CardMax_7()
    {
        DeleteColor();
        mode = 7;
        modeButton[4].image.color = new Color(255, 0, 0, 255);
    }
    public void CardMax_8()
    {
        DeleteColor();
        mode = 8;
        modeButton[5].image.color = new Color(255, 0, 0, 255);
    }
    public void CardMax_9()
    {
        DeleteColor();
        mode = 9;
        modeButton[6].image.color = new Color(255, 0, 0, 255);
    }
    void DeleteColor()
    {
        foreach (var k in modeButton)
        {
            k.image.color = new Color(255, 255, 255, 255);
        }
    }
}
