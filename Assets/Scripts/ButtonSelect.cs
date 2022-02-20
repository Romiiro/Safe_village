using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField]
    private Color _selectedColor;
    [SerializeField] 
    private Color _defaultColor;
    
    private Text _text;

    private void Start() {
        _text = GetComponentInChildren<Text>();
    }
    public void OnPointerEnter(PointerEventData eventData) {
        _text.color = _selectedColor;
    }

    public void OnPointerExit(PointerEventData eventData) {
        _text.color = _defaultColor;
    }
}
