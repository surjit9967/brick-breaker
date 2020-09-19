using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gamestatus : MonoBehaviour
{ [Range(0.1f,10f)][SerializeField] float Gamespeed= 1f;
    [SerializeField] int pointsperhit=20;
    [SerializeField] int currentscore=0;
    [SerializeField] TextMeshProUGUI scoretext;
    private void Awake()
    {
        int gamestatuscount = FindObjectsOfType<gamestatus>().Length;
        if (gamestatuscount>1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject); 
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = currentscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = Gamespeed;
    }
    public void AddScore()
    {
        currentscore += pointsperhit;
        scoretext.text = currentscore.ToString();
    }
    public void Resetgame()
    {
        Destroy(gameObject);
    }
}
