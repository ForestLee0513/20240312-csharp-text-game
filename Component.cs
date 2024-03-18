internal class Component
{
    public Component()
    {
        gameObject = null;
        transform = null;
    }

    ~Component()
    {
    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }

    // 내가 어디 속해 있는지 확인하는 용도
    public GameObject? gameObject;
    // 내가 속해있는 게임 오브젝트의 이동을 처리하기 위함.
    public Transform? transform;
}
