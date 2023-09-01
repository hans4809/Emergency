using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Ending : UI_Popup
{
    public enum Images
    {
        BackGround
    }
    Image BackGround;
    bool isClear;
    // Start is called before the first frame update
    void Start()
    {
        Init();
        StartCoroutine(FadeCoroutine());
    }
    public override void Init()
    {
        base.Init();
        Bind<Image>(typeof(Images));
        BackGround = GetImage((int)Images.BackGround);
        if (isClear)
        {
            BackGround.sprite = Managers.Resource.Load<Sprite>("UI/BackGround/Clear");
        }
        else
        {
            BackGround.sprite = Managers.Resource.Load<Sprite>("UI/BackGround/GameOver");
        }
    }
    IEnumerator FadeCoroutine()
    {
        Color color = BackGround.color;
        float fadeCount = 1;
        while (fadeCount >= 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            color.a = fadeCount;
            BackGround.color = color;
        }
    }        // Update is called once per frame
    void Update()
    {

    }
}
