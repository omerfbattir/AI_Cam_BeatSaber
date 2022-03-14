using UnityEngine;

public class CubeMenager : MonoBehaviour
{
    public bool isSliceable = false;
    private Vector2 sliceDir = Vector2.zero;
    public Vector2 playerInput = new Vector2();
    
    public string path; //left or right //!set while create
    public int dir;

    [SerializeField] private float speed = 1f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        if (isSliceable && sliceDir == playerInput)
        {
            Destroy(gameObject);
            print("fckd");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (path == "Left") playerInput = FindObjectOfType<PlayerInput>().leftInput;
        if (path == "Right") playerInput = FindObjectOfType<PlayerInput>().rightInput;
        
        switch (dir)
        {
            case 0:
                sliceDir = Vector2.up;
                break;
            case 1:
                sliceDir = Vector2.left;
                break;
            case 2:
                sliceDir = Vector2.down;
                break;
            case 3:
                sliceDir = Vector2.right;
                break;
        }
        print("PI:"+playerInput +"SD:"+sliceDir);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collider")) isSliceable = true;
        if(other.CompareTag("backline")) Destroy(gameObject);
        if (other.CompareTag("SpawnLine"))
        { 
            FindObjectsOfType<Spawner>()[0].spawneable = true;
            FindObjectsOfType<Spawner>()[1].spawneable = true;
        }
    }
}
