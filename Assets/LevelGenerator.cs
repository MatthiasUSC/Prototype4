using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject ground;
    public GameObject wallPrefab;

    public float length;

    public float groundHeight;

    public float graceDist;

    void Start()
    {
        ground.transform.localScale = new Vector3(length * 2, groundHeight, 1);

        float dist = graceDist;
        while(dist < length){
            float wallHeight = Random.Range(1f, 10f);
            float wallGapWidth = Random.Range(0.25f, 2f);
            float wallGapHeight = Random.Range(3f, 6f);
            GameObject wall = Instantiate(wallPrefab, new Vector3(dist, wallHeight, 0), Quaternion.identity);
            wall.transform.localScale = new Vector3(wallGapWidth, wallGapHeight, 1);
            dist += Random.Range(20f, 100f);
        }
    }

}
