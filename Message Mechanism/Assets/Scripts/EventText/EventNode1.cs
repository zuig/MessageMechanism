using UnityEngine;
using System.Collections;

public class EventNode1 : EventNode
{
    private static EventNode1 mInstance;

    public static EventNode1 Instance
    {
        get
        {
            return mInstance;
        }
    }

    void Awake()
    {
        
        mInstance = this;
        if (EventNodeCore.Instance)
        {
            EventNodeCore.Instance.AttachEventNode(this);
        }
        Debug.Log("---EventNode1 Awake---");
    }

    void OnDestroy()
    {
        EventNodePriority = 10;
        if (EventNodeCore.Instance)
        {
            EventNodeCore.Instance.DetachEventNode(this);
        }
    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(0,0,200,50),"EventNodeCore.SentEvent"))
        {
            EventNodeCore.Instance.SendEvent(EventDef.EventTest1, "测试消息发送");
            EventNodeCore.Instance.SendEvent(EventDef.EventTest2, "测试消息发送");
        }
        if (GUI.Button(new Rect(0, 60, 200, 50), "EventNode1.SentEvent"))
        {
            EventNode1.Instance.SendEvent(EventDef.EventTest1, "测试消息发送");
            EventNode1.Instance.SendEvent(EventDef.EventTest2, "测试消息发送");
        }
        if (GUI.Button(new Rect(0, 120, 200, 50), "EventNode2.SentEvent"))
        {
            EventNode2.Instance.SendEvent(EventDef.EventTest2, "测试消息发送");
        }
    }
}
