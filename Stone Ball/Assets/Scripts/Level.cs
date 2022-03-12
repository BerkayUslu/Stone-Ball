using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // for debugging purpose

    //cached referance
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void countBreakableBlocks()
    {
        breakableBlocks++;        
    }

    public void blockIsBreaked()
    {
        breakableBlocks--;
        isLevelEnded();
    }

    private void isLevelEnded()
    {
        if (breakableBlocks == 0)
        {
            sceneLoader.nextScene();
        }
    }
}
