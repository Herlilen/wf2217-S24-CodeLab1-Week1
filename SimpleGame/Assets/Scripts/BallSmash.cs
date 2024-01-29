using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallSmash : MonoBehaviour
{
    // hit bool
    public bool hit;
    public float currentTime;
    // reset time in seconds
    public float resetTime = 5; 

    
    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        currentTime = resetTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            // reset the level with timer
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "targets")
        {
            hit = true;
            Debug.Log("hit");
        }
    }
}
