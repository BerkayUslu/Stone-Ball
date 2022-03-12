using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockBrokenOne : MonoBehaviour
{
    [SerializeField] GameObject brokenOne;
    bool controller = false;

    private void OnCollisionExit2D(Collision2D collision)
    {
        //    if (controller)
        //  {
        //    gameObject.SetActive(false);
        //  brokenOne.SetActive(true);
        // }
        //controller = true;
        Destroy(gameObject);
        brokenOne.SetActive(true);
    }
}
