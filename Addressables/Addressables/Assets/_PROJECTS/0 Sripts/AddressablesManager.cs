using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class AddressablesManager : MonoBehaviour
{
    [SerializeField] private AssetReference[] balls;
    [SerializeField] private AssetReference buttonAssetReference;
    private GameObject _refBall;

    [SerializeField] private Data data;
    private void Start()
    {
        Addressables.InitializeAsync().Completed += AddressablesManager_Completed;
    }

    private void AddressablesManager_Completed(AsyncOperationHandle<IResourceLocator> obj)
    {
        foreach (var ball in balls)
        {
            ball.LoadAssetAsync<GameObject>().Completed += (x) =>
            {
                data.balls.Add(ball);
                LoadScene();
            };
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
