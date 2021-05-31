using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLaunch : MonoBehaviour
{
    void Awake()
    {
        new Map();
        Destroy(gameObject);
    }
}
