using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levels : MonoBehaviour
{
    [SerializeField] int Breakableblocks;
    SceneLoader sceneloader;
    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>(); 
    }
    public void countblocks()
    {
        Breakableblocks++;
    }
    public void BlockDestroyed()
    {
        Breakableblocks--;
        if (Breakableblocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }


}