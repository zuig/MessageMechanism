using UnityEngine;
using System.Collections.Generic;
using System;

public class ResMgr : EventNode, IEventListener
{
    private static ResMgr mInstance;

    public static ResMgr Instance
    {
        get
        {
            return mInstance;
        }
    }

    void Awake()
    {
        mInstance = this;
    }

    public class LoadAssetInfo
    {
        public ResourceRequest request;
        public List<IResLoadListener> listeners = new List<IResLoadListener>();
        public string assetName;

        public LoadAssetInfo(ResourceRequest _request, string _assetName)
        {
            this.request = _request;
            this.assetName = _assetName;
        }
    }

    public List<LoadAssetInfo> mInLoads = new List<LoadAssetInfo>();
    public void LoadAsync(string assetName, IResLoadListener listener)
    {
        for (int i = 0; i < mInLoads.Count; i++)
        {
            if (mInLoads[i].assetName == assetName)
            {
                if (!mInLoads[i].listeners.Contains(listener))
                {
                    mInLoads[i].listeners.Add(listener);
                }
                return;
            }
        }
        ResourceRequest request = Resources.LoadAsync(assetName);
        LoadAssetInfo load = new LoadAssetInfo(request, assetName);
        load.listeners.Add(listener);
        mInLoads.Add(load);
    }

    void Update()
    {
        for (int i = mInLoads.Count - 1; i >= 0; i--)
        {
            if (mInLoads[i].request.isDone)
            {
                for (int j = 0; j < mInLoads[i].listeners.Count; j++)
                {
                    if (mInLoads[i].listeners[j]!=null)
                    {
                        if(mInLoads[i].request.asset!=null)
                        {
                            mInLoads[i].listeners[j].Finish(mInLoads[i].request.asset);
                        }
                        else
                        {
                            mInLoads[i].listeners[j].Failure();
                        }
                    }
                }

                mInLoads.Remove(mInLoads[i]);
            }
        }
    }

    public int EventPriority()
    {
        return 0;
    }

    public bool HandleEvent(int id, object param1, object param2)
    {
        return false;
    }
}
