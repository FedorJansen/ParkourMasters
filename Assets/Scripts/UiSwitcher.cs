using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSwitcher : MonoBehaviour
{
    public GameObject main;
    public GameObject creds;
    // Start is called before the first frame update

    public void SwitchMainCreds()
    {
        main.SetActive(!main.activeSelf);
        creds.SetActive(!creds.activeSelf);
    }
}
