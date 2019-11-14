using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoader : AsyncLoader
{
    public int sceneIndexToLoad = 1;
    private static int _scenceIndex = 1;
    private static GameLoader _instance; // The only singleton you should have
    // diff between static class and singleton: there is no instance in static class
    public List<Component> gameModules = new List<Component>();

    protected override void Awake()
    {
        Debug.Log("GameLoader Staring");

        // Safety Chech
        if (_instance != null && _instance != true)
        {
            Debug.Log("A duplicate instance of the GameLoader was found");
            Destroy(gameObject);
            return;
        }

        _instance = this; // Sigleton

        DontDestroyOnLoad(gameObject);

        // Scence Index Check
        if (sceneIndexToLoad < 0 || sceneIndexToLoad > SceneManager.sceneCount)
        {
            Debug.Log("Give scene index is invalid");
            _scenceIndex = 1;
        }
        else
        {
            _scenceIndex = sceneIndexToLoad;
        }

        // Setup Systems GameObject
        GameObject systemGo = new GameObject("[Services]");
        systemGo.tag = "Services";
        Transform systemParent = systemGo.transform;
        DontDestroyOnLoad(systemGo);

        // Queue up loading routine
        Enqueue(InitializeCoreSystems(systemParent), 70);
        Enqueue(InitializingModularSystems(systemParent), 30);

        // Set the completion callback
        CallOnComplete(OnComplete);
    }

    private IEnumerator InitializeCoreSystems(Transform systemsParent)
    {
        Debug.Log("Initializing Core System");

        //GameObject uiManagerGo = new GameObject("UIManager");
        //uiManagerGo.transform.SetParent(systemsParent);
        //UIManager uIManagerComp = uiManagerGo.AddComponent<UIManager>();
        //ServiceLocator.Register<UIManager>(uIManagerComp);
        yield return null;
    }

    private IEnumerator InitializingModularSystems(Transform systemsParent)
    {
        Debug.Log("Initializing Modular Systems");
        //Debug.Log("Loading Moduler System");
        //foreach (var module in gameModules)
        //{
        //    if (module is IGameModule)
        //    {
        //        IGameModule gameModule = module as IGameModule;
        //        yield return gameModule.LoadModule();
        //    }
        //}
        yield return null;
    }

    private void OnComplete()
    {
        StartCoroutine(LoadInitialScene(_scenceIndex));
    }

    private IEnumerator LoadInitialScene(int index)
    {
        Debug.Log("GameLoader Starting Scene Load");
        yield return SceneManager.LoadSceneAsync(index);
    }
}