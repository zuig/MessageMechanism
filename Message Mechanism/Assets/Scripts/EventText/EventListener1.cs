using UnityEngine;
using System.Collections;
using System;

public class EventListener1 : MonoBehaviour,IEventListener {

    void Awake()
    {
        if (EventNode1.Instance)
        {
            EventNode1.Instance.AttachEventListener(EventDef.EventTest1,this);
            EventNode1.Instance.AttachEventListener(EventDef.EventTest2, this);
        }
    }

    void OnDestroy()
    {
        if (EventNode1.Instance)
        {
            EventNode1.Instance.DetchEventListener(EventDef.EventTest1, this);
            EventNode1.Instance.DetchEventListener(EventDef.EventTest2, this);
        }
    }

    public int EventPriority()
    {
        return 0;
    }

    public bool HandleEvent(int id, object param1, object param2)
    {
        Debug.Log("EventListener1.HandleEvent => id=" + id + " param1=" + param1);
        switch (id)
        {
            case EventDef.EventTest1:
                Debug.Log(this.name + "=>" + "HandleEvent EventTest1");
                return false;
        }
        return false;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
