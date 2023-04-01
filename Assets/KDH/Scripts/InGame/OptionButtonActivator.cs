using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButtonActivator : MonoBehaviour
{
    private void Start()
    {
        Option.instance.RefreshOption();
    }
}