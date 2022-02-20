using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;
using UnityEngine.UI;
using Zenject;

public class Tooltip : MonoBehaviour {
    private static string _message;
    private static bool _isUI;
    private static RectTransform _object;

    public static RectTransform Object {
        set => _object = value;
    }
    public static string Message {
        get => _message;
        set => _message = value;
    }

    public static bool IsUI {
        get => _isUI;
        set => _isUI = value;
    }

    [SerializeField] private Color _backgroundColor = Color.white;
    [SerializeField] private Color _textColor = Color.black;
    [SerializeField] private int _fontSize = 14;
    [SerializeField] private int _maxWidth = 250;
    [SerializeField] private int _border = 10;
    [SerializeField] private RectTransform _box;
    [SerializeField] private Text _text;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed = 10f;

    private Image _img;
    private Color _backgroundColorFade;
    private Color _textColorFade;
    private float _resolutionFixX;
    private float _resolutionFixY;
    private int _defXRes = 1920;
    private int _defYRes = 1080;


    private void Awake() {
        _img = _box.GetComponent<Image>();
        _box.sizeDelta = new Vector2(_maxWidth, _box.sizeDelta.y);
        _backgroundColorFade = _backgroundColor;
        _backgroundColorFade.a = 0;
        _textColorFade = _textColor;
        _textColorFade.a = 0;
        _isUI = false;
        _img.color = _backgroundColorFade;
        _text.color = _textColorFade;
        _text.alignment = TextAnchor.MiddleCenter;
    }

    private void LateUpdate() {
        bool show = false;
        _text.fontSize = _fontSize;
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.GetComponent<TooltipText>()) {
                _message = hit.transform.GetComponent<TooltipText>().Message;
                show = true;
            }
        }

        _text.text = _message;
        float width = _maxWidth;
        if (_text.preferredWidth <= _maxWidth - _border) {
            width = _text.preferredWidth + _border;
        }

        _box.sizeDelta = new Vector2(width, _text.preferredHeight + _border);
        if (show || _isUI) {
            _resolutionFixX = (float) _defXRes / Screen.width;
            _resolutionFixY = (float)_defYRes / Screen.height;
            SetPosition();
            _img.color = Color.Lerp(_img.color, _backgroundColor, _speed * Time.deltaTime);
            _text.color = Color.Lerp(_text.color, _textColor, _speed * Time.deltaTime);
        }
        else {
            _img.color = Color.Lerp(_img.color, _backgroundColorFade, _speed * Time.deltaTime);
            _text.color = Color.Lerp(_text.color, _textColorFade, _speed * Time.deltaTime);
        }
    }

    public void SetPosition() {
        float curY = _object.position.y * _resolutionFixX + _object.sizeDelta.y / 2 + _box.sizeDelta.y / 2 + 10f; 
        if (curY + _box.sizeDelta.y / 2 > Screen.currentResolution.height) {
            curY = _object.position.y * _resolutionFixX - _object.sizeDelta.y / 2 - _box.sizeDelta.y / 2 - 10f;
        }

        float curX = _object.position.x * _resolutionFixX;
        if (curX + _box.sizeDelta.x / 2 > Screen.currentResolution.width) {
            curX = _object.position.x * _resolutionFixX - _box.sizeDelta.x - 10;
        }
        else if (curX - _box.sizeDelta.x / 2 <= 0) {
            curX = _object.position.x * _resolutionFixX + (_box.sizeDelta.x / 2 - curX) + 10;
        }

        _box.anchoredPosition = new Vector2(curX, curY);
    }
}
