using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Loop : MonoBehaviour
{
    public GameObject pool_Prefab;
    public int number_Value;
    private Vector2 poolPos = new Vector2(30, 20);
    private Transform trans;

    void Start()
    {
        trans = transform;
        if (pool_Prefab != null)
        {
            GameObject obj = Instantiate(pool_Prefab);
            obj.transform.localPosition = poolPos;
        }
        if(NumericShow.Instance == null)
        {
            enabled = false;
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NumericShow.Instance.ShowMinusHP(number_Value, trans);
        }
    }
}
