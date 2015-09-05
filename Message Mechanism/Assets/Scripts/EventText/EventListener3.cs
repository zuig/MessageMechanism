using UnityEngine;
using System.Collections;
using System;

public class EventListener3 : MonoBehaviour,IEventListener {

    void Awake()
    {
        if (EventNodeCore.Instance)
        {
            EventNodeCore.Instance.AttachEventListener(EventDef.EventTest1, this);
            EventNodeCore.Instance.AttachEventListener(EventDef.EventTest2, this);
        }
    }

    void OnDestroy()
    {
        if (EventNodeCore.Instance)
        {
            EventNodeCore.Instance.DetchEventListener(EventDef.EventTest1, this);
            EventNodeCore.Instance.DetchEventListener(EventDef.EventTest2, this);
        }
    }

    public int EventPriority()
    {
        return 0;
    }

    public bool HandleEvent(int id, object param1, object param2)
    {
        Debug.Log("EventListener3.HandleEvent => id=" + id + " param1=" + param1);
        return false;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
