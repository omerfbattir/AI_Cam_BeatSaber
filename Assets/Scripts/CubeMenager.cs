using EZCameraShake;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeMenager : MonoBehaviour
{
    public GameObject particle;
    public Material green;
    public GameObject prism;
    
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
            Kill();
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collider"))
        {
            isSliceable = true;
            prism.GetComponent<MeshRenderer>().material = green;
        }
        if(other.CompareTag("backline")) Destroy(gameObject);
        if (other.CompareTag("SpawnLine"))
        { 
            FindObjectsOfType<Spawner>()[0].spawneable = true;
            FindObjectsOfType<Spawner>()[1].spawneable = true;
            FindObjectOfType<spawnertwo>().spawneable = true;
        }
    }

    void Kill()
    {
        Instantiate(particle, transform.position, Quaternion.identity);
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        FindObjectOfType<PlayerStats>().point++;
        Destroy(gameObject);
    }
}
