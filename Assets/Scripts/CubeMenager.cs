using System;
using UnityEngine;

public class CubeMenager : MonoBehaviour
{
    private bool isSliceable;
    private Vector2 sliceDir = Vector2.zero;
    public Vector2 playerInput = new Vector2();
    
    public string path; //left or right //!set while create
    public int dir;

    [SerializeField] private float speed = 1f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        
        //if (path == "left") playerInput = PlayerInput.instance.leftInput;
        //if (path == "right") playerInput = PlayerInput.instance.rightInput;

        if (sliceDir == playerInput)
        {
            print("hll");
        }
        if (isSliceable && sliceDir == playerInput)
        {
            Kill();
        }
    }

    private void Update()
    {
        switch (dir)
        {
            case 0:
                sliceDir = Vector2.up;
                break;
            case 1:
                sliceDir = Vector2.right;
                break;
            case 2:
                sliceDir = Vector2.down;
                break;
            case 3:
                sliceDir = Vector2.left;
                break;
        }
        print(sliceDir);
    }

    void Kill()
    {
        FindObjectOfType<PlayerStats>().point++;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collider")) isSliceable = true;
        if(other.CompareTag("backline")) Destroy(gameObject);
    }
}
