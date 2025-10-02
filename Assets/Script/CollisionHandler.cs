using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.name+ "이" + other.gameObject.name +"에 부딪혀 숨짐");
    }
}
