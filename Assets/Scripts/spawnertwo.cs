using UnityEngine;

public class spawnertwo : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] SpawnPoints = new Transform[1];
    public float spawnTreshold = 0.5f;
    public int freq = 0;
    private FFTWindow fftWindow;
    public float debugSamples;
    public bool spawneable = true;

    private float[] samples = new float[1024];
    private void FixedUpdate()
    {
        AudioListener.GetSpectrumData(samples, 0, fftWindow);

        debugSamples = samples[freq];
        if (samples[freq] > spawnTreshold && spawneable)
        {
            int random = Random.Range(0, 4);
            int path = PathDecider();
            GameObject obj = new GameObject();
            obj = Instantiate(prefab, SpawnPoints[path].position, Quaternion.Euler(Vector3.forward * 90 * random));

            switch (path)
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
    
    
    int spawnCount = 1;
    int lastSpawn;
    int PathDecider()
    {
        int pathRandom = Random.Range(0,2);
        
        if (spawnCount < 3)
        {
            if (lastSpawn == pathRandom)
            {
                spawnCount++;
            }
            else
            {
                spawnCount = 1;
                lastSpawn = pathRandom;
            }
        }
        else if (spawnCount >= 3 && lastSpawn == pathRandom)
        {
            print("hello there");
            /*
            pathRandom = (pathRandom - 1 )* -1;
            spawnCount = 1;
            lastSpawn = pathRandom;
            */
            if (pathRandom > 0)
            {
                pathRandom = 0;
                spawnCount = 1;
                lastSpawn = pathRandom;
            }
            else
            {
                pathRandom = 1;
                spawnCount = 1;
                lastSpawn = pathRandom;
            }
        }
        return pathRandom;
    }
}
