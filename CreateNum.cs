using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNum
{
    //1～10の数字を重複しないようにランダムに生成する。
    //テキストの文字を書き換え一気に表示して、数秒後に消す。
    //数の小さい数字を順にクリックしていき、間違えたら終了して全表示させる。

    public int[] arr = new int[20];


    //ダステンフェルドのアルゴリズムでランダムな数を生成する
    public void CreateRandom(int min_num, int max_num)
    {
        int arr_num = max_num - min_num + 1;
        for (int i = 0; i < arr_num; i++)
        {
            arr[i] = i + 1;
        }
        for (int t = 0; t < arr_num - 1; t++)
        {
            int index = Random.Range(0, arr_num - 1 - t);
            int a = arr[arr_num - 1 - t];
            arr[arr_num - 1 - t] = arr[index];
            arr[index] = a;
        }
        int p = 0;
        foreach (var k in arr)
        {
            Debug.Log($"arr[{p}] : {k}");
            p++;
        }
    }
}