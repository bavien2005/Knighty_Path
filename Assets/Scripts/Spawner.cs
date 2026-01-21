using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class Spawner : MonoBehaviour
{
    [SerializeField] private AssetLabelReference obj;
    [SerializeField] private AssetReference obj1; 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObj();
        }
    }

    private void SpawnObj()
    {
        var handle = Addressables.LoadAssetsAsync<GameObject>(obj, result =>
        {
            Instantiate(result);
        });

        var handle1 = Addressables.LoadAssetAsync<GameObject>(obj1);

        handle1.Completed += (AsyncOperationHandle<GameObject> task) =>
        {
            Instantiate(task.Result);
        };
    }
}
