internal class Timer
{
    public ulong executeTime = 0;
    protected ulong elapsedTime = 0;
    public delegate void Callback();
    public Callback? callback;
    public void SetTimer(ulong _executeTime, Callback _callback)
    {
        executeTime = _executeTime;
        callback = _callback;
    }

    public void Update()
    {
        elapsedTime += Engine.GetInstance().deltaTime;
        if(elapsedTime > executeTime)
        {
            // 실행
            if(callback != null)
            {
                callback();
            }
        }
    }
}
