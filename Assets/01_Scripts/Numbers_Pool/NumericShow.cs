using UnityEngine;

public class NumericShow : MonoBehaviour
{
    private int maxLength = 8;//Max to 99999999
    private float digitDistance = 0.35f;
    public Pool[] Pools;
    public static NumericShow Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        Pools = GetComponentsInChildren<Pool>();
    }

    public void ShowMinusHP(long value, Transform target)
    {
        //float length = Mathf.Floor(Mathf.Log10(value) + 1);
        int length = GetLength(value);
        if (length > maxLength) {
            return;
        }
        float first = digitDistance * (length / 2);
        for (int i = 0; i < length; ++i)
        {
            Number_Obj obj = Pools[SplitNumbers(value, i)].Get();
            obj.trans.position = target.position + new Vector3(first - digitDistance * i, 0, 0);
            obj.enabled = true;
        }
    }


    private long SplitNumbers(long value, int digit)
    {
        long d;
        switch (digit)
        {
            case 0:
                d = value % 10;
                break;
            case 1:
                d = value % 100;
                d = d / 10;
                break;
            case 2:
                d = value % 1000;
                d = d / 100;
                break;
            case 3:
                d = value % 10000;
                d = d / 1000;
                break;
            case 4:
                d = value % 100000;
                d = d / 10000;
                break;
            case 5:
                d = value % 1000000;
                d = d / 100000;
                break;
            case 6:
                d = value % 10000000;
                d = d / 1000000;
                break;
            case 7:
                d = value % 100000000;
                d = d / 10000000;
                break;
            case 8:
                d = value % 1000000000;
                d = d / 100000000;
                break;
            case 9:
                d = value % 10000000000;
                d = d / 1000000000;
                break;
            default:
                d = 0;
                break;
        }
        return d;
    }

    private int GetLength(long value)
    {
        if (value < 0) { return 0; }
        if (value < 10L) return 1;
        if (value < 100L) return 2;
        if (value < 1000L) return 3;
        if (value < 10000L) return 4;
        if (value < 100000L) return 5;
        if (value < 1000000L) return 6;
        if (value < 10000000L) return 7;
        if (value < 100000000L) return 8;
        return 9;
    }
}
