using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]float speed = 10f;
    [SerializeField]float xRange = 5f;
    [SerializeField]float yRange = 5f;

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        
        float xOffset = hor * Time.deltaTime * speed;
        float newXpos= transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(newXpos, -xRange, xRange);
        
        float yOffset = ver * Time.deltaTime * speed;
        float newYpos= transform.localPosition.y + yOffset;
        float clampedYpos = Mathf.Clamp(newYpos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXpos,clampedYpos,transform.localPosition.z);
    }
}
