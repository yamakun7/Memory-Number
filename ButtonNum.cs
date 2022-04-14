using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNum : MonoBehaviour
{
    public int self_num;
    public Text panel_text;
    void Start()
    {

        panel_text = this.gameObject.GetComponentInChildren<Text>();

    }

}
