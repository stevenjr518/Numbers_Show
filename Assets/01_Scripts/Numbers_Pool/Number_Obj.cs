using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number_Obj : MonoBehaviour
{
    public SpriteRenderer sRenderer;
    public Transform trans;
    private Pool pool;
    private float timer = 0;
    private float moveSpeed = 2f;
    private float moveTime = 0.5f;
    //private Color minusColor;
    //private Color originColor;

    void Awake()
    {
        //minusColor = new Color(0, 0, 0, moveSpeed);
        //originColor = sRenderer.color;
        pool = GetComponentInParent<Pool>();
        enabled = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        trans.localPosition += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        //sRenderer.color -= minusColor * Time.deltaTime;
        if (timer >= moveTime)
        {
            BackToPool();
            timer = 0;
        }
    }

    private void BackToPool()
    {
        pool.ReturnToPool(this);
        trans.localPosition = pool.trans.localPosition;
        //sRenderer.color = originColor;
        enabled = false;
    }

}
