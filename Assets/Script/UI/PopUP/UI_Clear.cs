using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Clear : UI_Popup
{
    // Start is called before the first frame update
    public enum Images
    {
        BackGround
    }
    Image BackGround;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        Bind<Image>(typeof(Images));
        BackGround = GetImage((int)Images.BackGround);
        StartCoroutine(FadeCoroutine());
    }
    IEnumerator FadeCoroutine()
    {
        yield return new WaitForSeconds(1f);

        Color color = BackGround.color;
        float fadeCount = 1;
        while (fadeCount >= 0.0f)
        {
            fadeCount -= 0.001f;
            yield return new WaitForSeconds(0.003f);
            color.a = fadeCount;
            BackGround.color = color;
        }

        yield return new WaitForSeconds(1f);
        Managers.Scene.LoadScene(Define.Scene.Main);
    }
}
