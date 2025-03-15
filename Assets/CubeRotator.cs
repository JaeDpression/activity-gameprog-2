using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;

    public float rotationSpeed = 100f;
    public float rotationDuration = 3f;

    private bool isCube1Rotating = true;
    private bool isCube2Rotating = true;
    private bool isCube3Rotating = true;

    private void Start()
    {
        // Start spinning all cubes at the same time
        StartRotation(cube1, () => isCube1Rotating);
        StartRotation(cube2, () => isCube2Rotating);
        StartRotation(cube3, () => isCube3Rotating);

        // Stop them one by one
        StartCoroutine(StopCubesOneByOne());
    }

    private async void StartRotation(GameObject cube, System.Func<bool> isRotating)
    {
        while (isRotating())
        {
            cube.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            await Task.Yield(); // Keeps it non-blocking
        }
    }

    private IEnumerator StopCubesOneByOne()
    {
        yield return new WaitForSeconds(rotationDuration);
        isCube1Rotating = false; // Stops Cube1

        yield return new WaitForSeconds(rotationDuration);
        isCube2Rotating = false; // Stops Cube2

        yield return new WaitForSeconds(rotationDuration);
        isCube3Rotating = false; // Stops Cube3
    }
}
