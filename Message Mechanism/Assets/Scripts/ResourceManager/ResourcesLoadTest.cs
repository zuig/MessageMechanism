using UnityEngine;
using System.Collections;
using System;

public class ResourcesLoadTest : MonoBehaviour
{
	
	void Awake () 
	{
	}

	// Use this for initialization
	void Start ()
	{
        ResMgr.Instance.LoadAsync("Cube", new LoadFinish());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnDestroy()
    {
    }
}

public class LoadFinish : IResLoadListener
{
    public void Failure()
    {
        Debug.Log("加载失败");
    }

    public void Finish(object asset)
    {
        GameObject.Instantiate(asset as GameObject);
    }
}
