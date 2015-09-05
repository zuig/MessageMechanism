using UnityEngine;
using System.Collections;

public class EventNodeCore : EventNode
{
    private static EventNodeCore mInstance;

    public static EventNodeCore Instance
    {
        get
        {
            return mInstance;
        }
    }

    void Awake()
    {
        mInstance = this;
        Debug.Log("---EventNodeCore Awake---");
    }
}
