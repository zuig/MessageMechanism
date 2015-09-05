using UnityEngine;
using System.Collections;
using System;

public class EventListener2 : MonoBehaviour, IEventListener
{

    void Awake()
    {
        if (EventNode2.Instance)
        {
            EventNode2.Instance.AttachEventListener(EventDef.EventTest2, this);
        }
    }

    void OnDestroy()
    {
        if (EventNode2.Instance)
        {
            EventNode2.Instance.DetchEventListener(EventDef.EventTest2, this);
        }
    }

    public int EventPriority()
    {
        return 0;
    }

    public bool HandleEvent(int id, object param1, object param2)
    {
        Debug.Log("EventListener2." + " HandleEvent => id = " + id + " param1=" + param1);
        return true;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
