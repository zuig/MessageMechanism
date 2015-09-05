/// <summary>
/// 消息监听接口
/// </summary>
public interface IEventListener
{
    /// <summary>
    /// 处理消息
    /// </summary>
    /// <param name="id">消息ID</param>
    /// <param name="param1">预留参数1</param>
    /// <param name="param2">预留参数2</param>
    /// <returns>是否终止消息派发</returns>
    bool HandleEvent(int id, object param1, object param2);

    /// <summary>
    /// 消息优先级别
    /// </summary>
    /// <returns></returns>
    int EventPriority();
}
