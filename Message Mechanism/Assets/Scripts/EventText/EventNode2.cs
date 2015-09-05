using UnityEngine;
using System.Collections;

public class EventNode2 : EventNode
{
    private static EventNode2 mInstance;

    public static EventNode2 Instance
    {
        get
        {
            return mInstance;
        }
    }

    void Awake()
    {
        EventNodePriority = 20;
        mInstance = this;
        if (EventNodeCore.Instance)
        {
            EventNodeCore.Instance.AttachEventNode(this);
        }
    }
    void OnDestroy()
    {
        if (EventNodeCore.Instance)
        {
            EventNodeCore.Instance.DetachEventNode(this);
        }
    }
}
