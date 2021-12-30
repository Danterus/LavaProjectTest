using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _resetLevel;

    public void Init(UnityAction restartLevel)
    {
        _resetLevel.onClick.RemoveAllListeners();
        _resetLevel.onClick.AddListener(restartLevel);
    }
}
