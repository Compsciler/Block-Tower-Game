using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private enum PointValueCalculation
    {
        Constant,
        Mass,
        Volume
    }
    [SerializeField] PointValueCalculation pointValueCalculation;

    internal int pointValue;

    void Start()
    {
        SetPointValue();
    }

    public void SetPointValue()
    {
        switch (pointValueCalculation)
        {
            case PointValueCalculation.Constant:
                pointValue = 1;
                break;
            case PointValueCalculation.Mass:
                pointValue = Mathf.CeilToInt(GetComponent<Rigidbody>().mass);
                break;
            case PointValueCalculation.Volume:
                pointValue = Mathf.CeilToInt(transform.localScale.x * transform.localScale.y * transform.localScale.z);
                break;
        }
    }
}
