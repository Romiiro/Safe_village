#region

using UnityEngine;
using UnityEngine.UI;

#endregion

/// <summary>
/// ¬сплывающие подсказки.
/// </summary>
public class Tooltip : MonoBehaviour {
    private const float indent = 10f;

    private const int _defXRes = 1920;
    private const int _defYRes = 1080;
    private static bool _isUI;
    private static RectTransform _object;
    private static string _message;

    [SerializeField] private Color _backgroundColor = Color.white;
    private Color _backgroundColorFade;
    [SerializeField] private Color _textColor = Color.black;
    private Color _textColorFade;
    private float _resolutionFixX;
    [SerializeField] private float _speed = 10f;

    private Image _img;
    [SerializeField] private int _border = 10;
    [SerializeField] private int _fontSize = 14;
    [SerializeField] private int _maxWidth = 250;
    [SerializeField] private RectTransform _box;
    [SerializeField] private Text _text;

    public static bool IsUI {
        get => _isUI;
        set => _isUI = value;
    }

    public static RectTransform Object {
        set => _object = value;
    }

    public static string Message {
        get => _message;
        set => _message = value;
    }

    /// <summary>
    /// ”станавливает позицию всплывающей подсказки с корректировкой при изменении разрешени€.
    /// ƒл€ позиции Y используетс€ 
    /// </summary>
    public void SetPosition() {
        var curY = _object.position.y * _resolutionFixX + _object.sizeDelta.y / 2 + _box.sizeDelta.y / 2 + indent;
        if (curY + _box.sizeDelta.y / 2 > Screen.currentResolution.height)
            curY = _object.position.y * _resolutionFixX - _object.sizeDelta.y / 2 - _box.sizeDelta.y / 2 - indent;

        var curX = _object.position.x * _resolutionFixX;
        if (curX + _box.sizeDelta.x / 2 > Screen.currentResolution.width)
            curX = _object.position.x * _resolutionFixX - _box.sizeDelta.x - indent;
        else if (curX - _box.sizeDelta.x / 2 <= 0)
            curX = _object.position.x * _resolutionFixX + (_box.sizeDelta.x / 2 - curX) + indent;

        _box.anchoredPosition = new Vector2(curX, curY);
    }


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

    /// <summary>
    /// ≈сли курсор наведен на элемент интерфейса отображет подсказку(про€вление с заданной скоростью) и пересчитывает корректировку разрешени€.
    /// </summary>
    private void LateUpdate() {
        var show = false;
        _text.fontSize = _fontSize;
        _text.text = _message;
        float width = _maxWidth;
        if (_text.preferredWidth <= _maxWidth - _border) width = _text.preferredWidth + _border;

        _box.sizeDelta = new Vector2(width, _text.preferredHeight + _border);
        if (_isUI) {
            _resolutionFixX = (float) _defXRes / Screen.width;
            SetPosition();
            _img.color = Color.Lerp(_img.color, _backgroundColor, _speed * Time.deltaTime);
            _text.color = Color.Lerp(_text.color, _textColor, _speed * Time.deltaTime);
        }
        else {
            _img.color = Color.Lerp(_img.color, _backgroundColorFade, _speed * Time.deltaTime);
            _text.color = Color.Lerp(_text.color, _textColorFade, _speed * Time.deltaTime);
        }
    }
}