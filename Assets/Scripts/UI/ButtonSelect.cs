#region

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#endregion

/// <summary>
/// ����� �������� ���� ������ ��� ������
/// </summary>
public class ButtonSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _selectedColor;

    private Text _text;

    public void OnPointerEnter(PointerEventData eventData) {
        _text.color = _selectedColor;
    }

    public void OnPointerExit(PointerEventData eventData) {
        _text.color = _defaultColor;
    }

    private void Start() {
        _text = GetComponentInChildren<Text>();
    }
}