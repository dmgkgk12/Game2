using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]float speed = 10f;
    [SerializeField]float xRange = 5f;
    [SerializeField]float yRange = 5f;
    [SerializeField]float positionPitchFactor = 0f;
    [SerializeField]float controlPitchFactor = 0f;
    [SerializeField]float positionYawFactor = 0f;
    [SerializeField]float controlYawFactor = 0f;
    [SerializeField]float controlRollFactor = 0f;
    [SerializeField]GameObject[] lasers;
    float hor;
    float ver;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }
    
    void ProcessFiring()
    {
        if(Input.GetButton("Fire1"))
        {
            SetLaserActive(true);
        }
        else
        {
            SetLaserActive(false);
        }
    }
    void SetLaserActive(bool isActive)
    {
        foreach(GameObject beam in lasers)
        {
            var emissionModule = beam.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled=isActive;
        }
    }
    
    void ProcessRotation()
    {
        float pitchPos = transform.localPosition.y * positionPitchFactor;
        float pitchCon = ver * controlPitchFactor;

        float pitch = pitchPos + pitchCon;

        float YawPos = transform.localPosition.x * positionYawFactor;
        float YawCon = hor * controlYawFactor;

        float yaw = YawPos + YawCon;

        float roll = hor * controlRollFactor;

        transform.localRotation=Quaternion.Euler(pitch,yaw,roll);
    }
    private void ProcessTranslation()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        float xOffset = hor * Time.deltaTime * speed;
        float newXpos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(newXpos, -xRange, xRange);

        float yOffset = ver * Time.deltaTime * speed;
        float newYpos = transform.localPosition.y + yOffset;
        float clampedYpos = Mathf.Clamp(newYpos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }
}
