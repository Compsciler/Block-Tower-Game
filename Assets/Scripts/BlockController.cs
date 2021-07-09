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
    private float pointValueCalculationOffset = 0.001f;

    internal int pointValue;

    internal static List<GameObject> blockGOs;

    void Awake()
    {
        InitializeBlockGOLists();
    }

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
                pointValue = Mathf.CeilToInt(GetComponent<Rigidbody>().mass - pointValueCalculationOffset);
                break;
            case PointValueCalculation.Volume:
                pointValue = Mathf.CeilToInt(transform.lossyScale.x * transform.lossyScale.y * transform.lossyScale.z - pointValueCalculationOffset);
                break;
        }
    }

    public static float GetMaxSpeedOfBlocks()
    {
        float maxSpeed = 0;
        foreach (GameObject blockGO in blockGOs)
        {
            float speed = blockGO.GetComponent<Rigidbody>().velocity.magnitude;
            if (speed > maxSpeed)
            {
                maxSpeed = speed;
            }
        }
        return maxSpeed;
    }

    public void InitializeBlockGOLists()
    {
        if (blockGOs == null)
        {
            blockGOs = new List<GameObject>();
        }
        blockGOs.Add(gameObject);
    }

    void OnDestroy()
    {
        blockGOs.Remove(gameObject);
    }
}
