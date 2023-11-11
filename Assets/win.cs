using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{
    private int enemy1;
    private int enemy2;
    private int enemy3;
    [SerializeField] private BoxCollider2D winSquare;
    // Start is called before the first frame update
    void Start()
    {
        winSquare.GetComponent<BoxCollider2D>();
        winSquare.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        enemy1 = GameObject.FindGameObjectsWithTag("enemy_stage1").Length;
        enemy2 = GameObject.FindGameObjectsWithTag("enemy_stage2").Length;
        enemy3 = GameObject.FindGameObjectsWithTag("enemy_stage3").Length;
        Debug.Log(enemy1 + enemy2 + enemy3);
        if (enemy1 == enemy2 && enemy2 == enemy3 && enemy1 == 0)
        {
            winSquare.enabled = true;
        }
    }
}
