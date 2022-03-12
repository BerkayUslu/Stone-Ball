using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreak : MonoBehaviour
{
    //config params
    [SerializeField] int maxHits = 1;
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] blockSprites;

    //cached referance
    Level level;
    GameStatus GameStatusScript;

    //state variables
    [SerializeField] int timesHit = 0;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.countBreakableBlocks();
        }
        if (tag == "Bouncing")
        {
            GameObject loseCollider = GameObject.Find("Lose Collider");
            Physics2D.IgnoreCollision(loseCollider.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }

    }

    private void showNextBlockSprite()
    {
        if (maxHits>=timesHit) {
            if (maxHits == 2)
            {
                GetComponent<SpriteRenderer>().sprite = blockSprites[1];
            }
            else {
                GetComponent<SpriteRenderer>().sprite = blockSprites[timesHit - 1];
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((tag != "Unbreakable") && (collision.gameObject.name == "Ball"))
        {
            checkHitsAndDstroy();
        }
       
    }

    private void checkHitsAndDstroy()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            hitAndDestroyBlock();
        }
        else
        {
            showNextBlockSprite();
        }
    }

    private void hitAndDestroyBlock()
    {
        Destroy(gameObject);
        TriggerSparklesVFX();    
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);
            
            FindObjectOfType<GameStatus>().updateScore();
            level.blockIsBreaked();
                       
    }

    private void TriggerSparklesVFX()
    {
        
        GameObject sparkles = Instantiate(blockSparklesVFX ,transform.position,transform.rotation);
        sparkles.AddComponent<SparklesVFXDestroy>();
    }
}
