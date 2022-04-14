using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
  

    public void ChangeSceneHome()
    {
        SceneManager.LoadScene("GameMenu");
    }
    public void ChangeSceneNine()
    {
        SceneManager.LoadScene("NineStage");
    }
    public void OnCharenge() //チャレンジモードのスタートボタン
    {
        GameMng.isCharengeMode = true;
        SceneManager.LoadScene("NineStage");
    }
}
