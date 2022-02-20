using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/GameSettings")]
public class GameSettings : ScriptableObject {
//    [SerializeField] private float _timeToFirstWave;
//    [SerializeField] private float _timeBetweenWaves;
//    [SerializeField] private int _encounterGrowth;
    [SerializeField] private float _warriorSpeed;
    [SerializeField] private float _timeSpeed;
    [SerializeField] private int _wavesToWin;

    public float WarriorSpeed {
        get => _warriorSpeed;
        set => _warriorSpeed = value;
    }

/*    public float TimeToFirstWave {
        get => _timeToFirstWave;
    }

    public float TimeBetweenWaves {
        get => _timeBetweenWaves;
        set => _timeBetweenWaves = value;
    }

    public int EncounterGrowth {
        get => _encounterGrowth;
        set => _encounterGrowth = value;
    }
*/

    public float TimeSpeed {
        get => _timeSpeed;
        set => _timeSpeed = value;
    }

    public float WavesToWin {
        get => _wavesToWin;
    }
}
