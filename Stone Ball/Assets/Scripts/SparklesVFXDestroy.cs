using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SparklesVFXDestroy : MonoBehaviour
{
    float createdAt;
    private void Start()
    {
        createdAt = Time.time; 
    }
    // Update is called once per frame
    void Update()
    {
        if((Time.time - createdAt) > 2f)
        {
            Destroy(gameObject);
        }
    }
}
