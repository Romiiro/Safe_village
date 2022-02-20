using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipText : MonoBehaviour
{
    [SerializeField] private string _message;

    public string Message {
        get => _message;
        set => _message = value;
    }
}
