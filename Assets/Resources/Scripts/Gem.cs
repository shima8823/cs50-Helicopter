﻿using UnityEngine;

public class Gem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -25)
        {
            Destroy(gameObject);
        }
        else
        {

            // ensure coin moves at the same rate as the skyscrapers do
            transform.Translate(-SkyscraperSpawner.speed * Time.deltaTime, 0, 0, Space.World);
        }

        // infinitely rotate this coin about the Y axis in world space
        transform.Rotate(0, 5f, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        // trigger coin pickup function if a helicopter collides with this
        other.transform.parent.GetComponent<HeliController>().PickupGem();
        print("destroyed gem");
        Destroy(gameObject);
    }
}
