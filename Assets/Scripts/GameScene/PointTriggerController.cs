using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTriggerController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] int pointMultiplier;
    
    // [SerializeField] Material[] pointTriggerMaterials;

    void Start()
    {
        // GetComponent<MeshRenderer>().material = pointTriggerMaterials[playerController.playerNum - 1];
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        BlockController otherBlockController = other.gameObject.GetComponentInParent<BlockController>();
        if (otherBlockController == null)
        {
            return;
        }
        playerController.AddScore(otherBlockController.pointValue * pointMultiplier);
    }
}
