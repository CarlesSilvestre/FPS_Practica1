using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decal : MonoBehaviour
{
    public List<Material> materials;
    public float destroyTime;
    private MeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.material = materials[Random.Range(0, materials.Count)];
        StartCoroutine(DestroyOnTime());
    }

    private IEnumerator DestroyOnTime()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
