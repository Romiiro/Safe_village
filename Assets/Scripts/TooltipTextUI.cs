using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTextUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string _message;

    public string Message {
        get => _message;
        set => _message = value;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Tooltip.Object = gameObject.GetComponent<RectTransform>();
        Tooltip.Message = _message;
        Tooltip.IsUI = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        Tooltip.IsUI = false;
    }
}
