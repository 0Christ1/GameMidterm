using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour
{
    // Start is called before the first frame update

    public int lifeTime = 1;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
