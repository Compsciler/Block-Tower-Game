using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] GameObject cannonballPrefab;
    [SerializeField] Transform cannonballParentTF;
    [SerializeField] float maxShotSpeed;
    [SerializeField] float shotVelocityMultiplier;  // To not move mouse as far to achieve max shot speed
    private Vector3 shotVelocity;
    [SerializeField] Transform shotPointTF;

    [SerializeField] GameObject trajectoryPointPrefab;
    [SerializeField] Transform trajectoryPointParentTF;
    private GameObject[] trajectoryPoints;
    [SerializeField] int trajectoryPointCount;
    [SerializeField] float trajectoryPointStartTime;
    [SerializeField] float timeBetweenTrajectoryPoints;
    [SerializeField] float scaleChangeBetweenTrajectoryPoints;

    // Start is called before the first frame update
    void Start()
    {
        InitializeTrajectoryPoints();
    }

    // Update is called once per frame
    void Update()
    {
        GetShotVelocity();
        transform.right = shotVelocity;

        for (int i = 0; i < trajectoryPoints.Length; i++)
        {
            trajectoryPoints[i].transform.position = GetCannonballPos(i * timeBetweenTrajectoryPoints + trajectoryPointStartTime);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void GetShotVelocity()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        shotVelocity = mousePos - transform.position;
        shotVelocity *= shotVelocityMultiplier;
        if (shotVelocity.magnitude > maxShotSpeed)
        {
            shotVelocity = shotVelocity.normalized * maxShotSpeed;
        }
    }

    public void Shoot()
    {
        GameObject cannonBallGO = Instantiate(cannonballPrefab, shotPointTF.position, shotPointTF.rotation);
        cannonBallGO.transform.parent = cannonballParentTF;
        cannonBallGO.GetComponent<Rigidbody>().velocity = shotVelocity;
    }

    public Vector3 GetCannonballPos(float t)
    {
        Vector3 shotDisplacement = shotVelocity * t + 0.5f * Physics.gravity * (t * t);
        return shotPointTF.position + shotDisplacement;
    }

    public void InitializeTrajectoryPoints()
    {
        trajectoryPoints = new GameObject[trajectoryPointCount];
        for (int i = 0; i < trajectoryPointCount; i++)
        {
            trajectoryPoints[i] = Instantiate(trajectoryPointPrefab, shotPointTF.position, Quaternion.identity);
            trajectoryPoints[i].transform.parent = trajectoryPointParentTF;
            float trajectoryPointScaleDimension = i * scaleChangeBetweenTrajectoryPoints + trajectoryPoints[i].transform.localScale.x;
            trajectoryPoints[i].transform.localScale = new Vector3(trajectoryPointScaleDimension, trajectoryPointScaleDimension, trajectoryPointScaleDimension);
        }
    }
}
