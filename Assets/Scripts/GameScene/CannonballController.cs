using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballController : MonoBehaviour
{
    internal static List<GameObject> cannonBallGOs;

    void Awake()
    {
        InitializeCannonballGOLists();
    }

    public static void DestroyCannonballs()
    {
        foreach (GameObject cannonballGO in cannonBallGOs)
        {
            Destroy(cannonballGO);
        }
    }

    public static float GetMaxSpeedOfCannonballs()
    {
        float maxSpeed = 0;
        foreach (GameObject cannonballGO in cannonBallGOs)
        {
            float speed = cannonballGO.GetComponent<Rigidbody>().velocity.magnitude;
            if (speed > maxSpeed)
            {
                maxSpeed = speed;
            }
        }
        return maxSpeed;
    }

    public void InitializeCannonballGOLists()
    {
        if (cannonBallGOs == null)
        {
            cannonBallGOs = new List<GameObject>();
        }
        cannonBallGOs.Add(gameObject);
    }

    void OnDestroy()
    {
        cannonBallGOs.Remove(gameObject);
    }
}
