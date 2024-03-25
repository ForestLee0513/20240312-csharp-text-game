class Component
{
    public Component()
    {
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

    //내가 어디 속해 있는 확인 하는 용도
    public GameObject gameObject;

    //내가 속해 게임오브젝트의 이동을 처리 하기
    public Transform transform;
}