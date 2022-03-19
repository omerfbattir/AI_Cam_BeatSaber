using UnityEngine;

public class spawnertwo : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] SpawnPoints = new Transform[1];
    public float spawnTreshold = 0.5f;
    public int freq = 0;
    public FFTWindow fftWindow;
    public float debugSamples;
    public bool spawneable = true;

    private float[] samples = new float[1024];
    private void FixedUpdate()
    {
        AudioListener.GetSpectrumData(samples, 0, fftWindow);

        debugSamples = samples[freq];
        if (samples[freq] > spawnTreshold && spawneable)
        {
            int pointRandom = Random.Range(0, 2);
            int random = Random.Range(0, 4);
            
            GameObject obj = new GameObject();
            obj = Instantiate(prefab, SpawnPoints[pointRandom].position, Quaternion.Euler(Vector3.forward * 90 * random));
            

            switch (pointRandom)
            {
                case 0:
                    obj.GetComponent<CubeMenager>().path = "Left";
                    break;
                case 1:
                    obj.GetComponent<CubeMenager>().path = "Right";
                    break;
            }
            obj.GetComponent<CubeMenager>().dir = random;
            
            spawneable = false;
        }
    }
}
