using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatBullets : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("PlayerBullet")) {
            Destroy(other);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
