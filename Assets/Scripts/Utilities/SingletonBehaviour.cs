using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
    private static T instance;
    public static T Instance => GetInstance();

    protected virtual bool BindToScene => false;
    private SceneHandle boundSceneHandle;

    /// <summary>
    /// Finds a singleton in the scene or creates one if none exists
    /// </summary>
    /// <returns></returns>
    private static T GetInstance()
    {
        if (!instance)
        {
            instance = FindAnyObjectByType<T>();
            if (!instance)
            {
                new GameObject(typeof(T).ToString(), typeof(T));
            } else if (instance.gameObject.scene.name != "DontDestroyOnLoad")
            {
                instance.transform.parent = null;
                DontDestroyOnLoad(instance.gameObject);
            }
        }

        return instance;
    }

    private void Awake()
    {
        GetInstance();

        if (instance && instance != this)
        {
            Debug.LogWarning($"Destroying duplicate {typeof(T)} component.");
            Destroy(this);
        }

        if (BindToScene)
        {
            boundSceneHandle = SceneManager.GetActiveScene().handle;
            SceneManager.sceneUnloaded += OnSceneUnload;
        }
    }

    /// <summary>
    /// Empty function to begin the MonoSingleton's behaviour
    /// </summary>
    public static void Wake() { }

    void OnSceneUnload(Scene scene)
    {
        if (!BindToScene || !scene.handle.Equals(boundSceneHandle)) return;

        boundSceneHandle = default;
        SceneManager.sceneUnloaded -= OnSceneUnload;
        InternalOnDestroy();
        instance = null;
        Destroy(this);
    }

    protected virtual void InternalOnDestroy()
    {

    }
}
