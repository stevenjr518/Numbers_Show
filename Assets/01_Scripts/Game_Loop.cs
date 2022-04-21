using UnityEngine;

public class Game_Loop : MonoBehaviour
{
    public GameObject PoolPrefab;
    public int NumberValue;
    private Vector2 poolPos = new Vector2(30, 20);
    private Transform trans;

    void Start()
    {
        trans = transform;
        if (PoolPrefab != null)
        {
            GameObject obj = Instantiate(PoolPrefab);
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
            NumericShow.Instance.ShowMinusHP(NumberValue, trans);
        }
    }
}
