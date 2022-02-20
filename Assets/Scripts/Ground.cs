using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
    private GameObject[,] ground;
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject grassPrefab;
    [SerializeField] private GameObject roadPrefab;
    [SerializeField] private GameObject plantsPrefab;

    void Start() {
        int screenSizeX = Screen.currentResolution.width;
        int screenSizeY = Screen.currentResolution.height;
        float screenProportion = screenSizeX / (float)screenSizeY;
        int groundSizeX = Mathf.RoundToInt(100 * screenProportion / 3);
        int groundSizeY = 81 / 3;

        ground = new GameObject[groundSizeX, groundSizeY];
        for(int i = 0; i < groundSizeX; i++)
            for(int j = 0; j < groundSizeY; j++)
        {
            if (i < (groundSizeX / 2.5) - 3) {
                if (j > groundSizeY / 2 - 4 && j < groundSizeY / 2 + 4) {
                    ground[i, j] = Instantiate(roadPrefab, new Vector3(i*3 + 1, j*3 + 1), Quaternion.identity, gameObject.transform);
                }
                else {
                    ground[i, j] = Instantiate(grassPrefab, new Vector3(i*3 + 1, j *3 + 1), Quaternion.identity,
                        gameObject.transform);
                }
            } else if (i > (groundSizeX / 2.5) + 3) {
                if (j < 1) {
                    ground[i, j] = Instantiate(plantsPrefab, new Vector3(i*3 + 1, j * 3 + 1), Quaternion.identity, gameObject.transform);
                } else {
                    ground[i, j] = Instantiate(groundPrefab, new Vector3(i*3+1, j *3 + 1), Quaternion.identity,
                        gameObject.transform);
                }
            } else {
                ground[i, j] = Instantiate(wallPrefab, new Vector3(i*3 + 1, j*3+1, 2.5f), Quaternion.identity, gameObject.transform);
            }

            ground[i, j].gameObject.name = "ground " + i + " " + j;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
