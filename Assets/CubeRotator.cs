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

    private void Start()
    {
        StartCoroutine(RotateCubes());
    }

    private IEnumerator RotateCubes()
    {
        Task rotateTask1 = RotateCubeAsync(cube1);
        Task rotateTask2 = RotateCubeAsync(cube2);
        Task rotateTask3 = RotateCubeAsync(cube3);

        yield return new WaitForSeconds(rotationDuration);
        rotateTask1.Wait();

        yield return new WaitForSeconds(rotationDuration);
        rotateTask2.Wait();

        yield return new WaitForSeconds(rotationDuration);
        rotateTask3.Wait();
    }

    private async Task RotateCubeAsync(GameObject cube)
    {
        float elapsedTime = 0f;

        while (elapsedTime < rotationDuration * 3)
        {
            cube.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            await Task.Yield();
        }
    }
}