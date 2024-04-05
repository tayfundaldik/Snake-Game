using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Vector2 xdirection = Vector2.right;
    List<Transform> segments=new List<Transform>();
    public Transform tail;
    public int snakeSize = 4;


    private void Start()
    {
        ResetPosition();
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            xdirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            xdirection = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            xdirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            xdirection = Vector2.left;
        }
    }


    private void FixedUpdate()
    {
        for (int i = segments.Count-1;  i>0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x) + xdirection.x, Mathf.Round(this.transform.position.y) + xdirection.y, 0f);
    }

    public void Grow()
    {
        Transform Tail = Instantiate(this.tail);
        Tail.position = segments[segments.Count - 1].position;
        segments.Add(Tail);
    }
    public void ResetPosition()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(this.transform);
        for (int i = 1; i < this.snakeSize; i++)
        {
            segments.Add(Instantiate(this.tail));
        }
        this.transform.position = Vector3.zero;
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            Grow();
        }
        else if (other.CompareTag("Obstacle"))
        {
            ResetPosition();
        }
    }
}
