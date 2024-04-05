using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        RandomLocation();
    }

    private void RandomLocation()
    {
        Bounds bounds = this.box.bounds;
       float randomx = Random.Range(bounds.min.x, bounds.max.x);
       float randomy = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector3(Mathf.Round(randomx), Mathf.Round(randomy), 0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            RandomLocation();
        }
    }
}
