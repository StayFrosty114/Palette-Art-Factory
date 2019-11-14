using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour, IGameModule
{
    public List<UnityEngine.Object> DataSources;
    public Dictionary<string, IDataSource> LoadedDataSource;

    private void Awake()
    {
        LoadedDataSource = new Dictionary<string, IDataSource>();
        GameLoader.CallOnComplete(Init);
    }

    private void Init()
    {
        ServiceLocator.Register<DataLoader>(this);
    }

    public IDataSource GetDataByName(string id)
    {
        if(LoadedDataSource.ContainsKey(id))
        {
            return LoadedDataSource[id];
        }
        return null;
    }

    public IEnumerator LoadModule()
    {

        foreach(var obj in DataSources)
        {
            if(obj is IDataSource)
            {
                IDataSource source = (IDataSource)obj;
                yield return LoadAsync(source);
            }
        }
        yield return null;

    }

    public IEnumerator LoadAsync(IDataSource source)
    {
        if(!source.IsLoading)
        {
            source.IsLoading = true;
            yield return source.LoadAsync();
            source.IsLoaded = true;
            LoadedDataSource.Add(source.Id, source);
            Debug.Log("Loaded Source: " + source.Id);
        }
        yield return null;
    }
}
