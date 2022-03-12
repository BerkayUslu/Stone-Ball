using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    [SerializeField] GameObject brokenOne;


    private void OnCollisionExit2D(Collision2D collision)
    {
        // gameObject.SetActive(false);
        Destroy(gameObject);
        brokenOne.SetActive(true);
    }
}
