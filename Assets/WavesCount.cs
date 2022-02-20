using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class WavesCount : MonoBehaviour {

    [SerializeField] private WaveManager _waveManager;
    // Update is called once per frame
    void Start() {
        _waveManager.WavesPassed = 0;
    }
    void Update() {
        gameObject.GetComponent<Text>().text = _waveManager.WavesPassed.ToString();
    }
}
