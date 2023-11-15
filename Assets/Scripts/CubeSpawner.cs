
using UnityEngine;


public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var newCube = Instantiate(_cubePrefab);
            newCube.transform.position = new Vector3(Random.Range(-20,20),50, 10);
        }
    }
}
