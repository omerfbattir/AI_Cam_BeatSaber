using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnTreshold = 0.5f;
    public int freq = 0;
    public FFTWindow fftWindow;
    public float debugSamples;
    public bool spawneable = true;

    public string path;

    private float[] samples = new float[1024];
    
    private void FixedUpdate()
    {
        AudioListener.GetSpectrumData(samples, 0, fftWindow);

        debugSamples = samples[freq];
        if (samples[freq] > spawnTreshold && spawneable)
        {
            int random = Random.Range(0, 4);
            GameObject obj = new GameObject();
            obj = Instantiate(prefab, transform.position, Quaternion.Euler(Vector3.forward * 90 * random));
            obj.GetComponent<CubeMenager>().path = path;
            obj.GetComponent<CubeMenager>().dir = random;
            spawneable = false;
            StartCoroutine(spawn());
        }
    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(10f);
    }
}
