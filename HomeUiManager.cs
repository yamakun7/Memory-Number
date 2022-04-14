using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUiManager : MonoBehaviour
{
    [SerializeField] GameObject home_panel;
    [SerializeField] GameObject practice_panel;
    [SerializeField] GameObject charenge_panel;

    void Start()
    {
        home_panel.SetActive(true);
        practice_panel.SetActive(false);
        charenge_panel.SetActive(false);
    }

    public void ToPractice()
    {
        home_panel.SetActive(false);
        practice_panel.SetActive(true);
    }

    public void ToHome()
    {
        home_panel.SetActive(true);
        practice_panel.SetActive(false);
        charenge_panel.SetActive(false);

    }

    public void ToCharenge()
    {
        home_panel.SetActive(false);
        charenge_panel.SetActive(true);
    }


}
