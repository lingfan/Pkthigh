using System.Collections;
using System.Collections.Generic;
using JEngine.Core;
using UnityEngine;

public class TestChangeLanguage : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public void ClickChange()
    {
        if (Localization.CurrentLanguage.Equals("zh-cn"))
        {
            Localization.ChangeLanguage("en-us");
        }
        else
        {
            Localization.ChangeLanguage("zh-cn");
        }
    }
}