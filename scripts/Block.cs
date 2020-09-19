using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockVFX;
    [SerializeField] Sprite[] hitsprites;
    levels level;
    [SerializeField] int timeshit; // debugging purpose.
    private void Start()
    {
        countbreakableblocks();
    }

    private void countbreakableblocks()
    {
        level = FindObjectOfType<levels>();
        if (tag == "breakable")
        {

            level.countblocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "breakable")
        {
            timeshit++;
            int maxhits = hitsprites.Length + 1;
            if (timeshit >= maxhits)
            {
                destroyblock();
            }
            else
            {
                shownexthitsprite();
            }

        }
    }

    private void shownexthitsprite()
    {
        int index = timeshit - 1;
        if (hitsprites[index] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitsprites[index];
        }
        else
        {
            Debug.LogError("block sprite is missing from array" + gameObject.name);
        }
    }

    private void destroyblock()
    {
        playSFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        triggerblockvfx();
    }

    private void playSFX()
    {
        FindObjectOfType<gamestatus>().AddScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void triggerblockvfx()
    {
        GameObject sparkle = Instantiate(blockVFX, transform.position,transform.rotation);
        Destroy(sparkle, 1f);
    }
}
