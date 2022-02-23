#region

using UnityEngine;

#endregion

[CreateAssetMenu(menuName = "ScriptableObject/GameSettings")]
public class GameSettings : ScriptableObject {
    [SerializeField] private float _timeSpeed;
    [SerializeField] private int _wavesToWin;

    public float TimeSpeed {
        get => _timeSpeed;
        set => _timeSpeed = value;
    }

    public float WavesToWin => _wavesToWin;
}