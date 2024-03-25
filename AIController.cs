class AIController: Component
{
    ulong processTime;
    ulong eslapsedTime;
    public AIController()
    {
        processTime = 500;
        eslapsedTime = 0;
    }

    ~AIController() { }

    public override void Update()
    {
        eslapsedTime += Engine.GetInstance().deltaTime;
        if (eslapsedTime < processTime)
        {
            return;
        }

        eslapsedTime = 0;

        Random random = new Random();
        int nextDirection = random.Next(0, 4);
        int oldX = transform.x;
        int oldY = transform.y;
        if (transform == null)
        {
            return;
        }

        if (nextDirection == 0)
        {
            transform.Translate(0, -1);
        }

        if (nextDirection == 1)
        {
            transform.Translate(0, 1);
        }

        if (nextDirection == 2)
        {
            transform.Translate(-1, 0);
        }

        if (nextDirection == 3)
        {
            transform.Translate(1, 0);
        }

        for (int i = 0; i < Engine.GetInstance().gameObjects.Count; i++)
        {
            GameObject findGameObject = Engine.GetInstance().gameObjects[i];

            if (findGameObject.transform == transform)
            {
                continue;
            }

            Collider2D? collider2D = findGameObject.GetComponent<Collider2D>();

            if (collider2D != null)
            {
                if (collider2D.Check(gameObject) == true && collider2D.isTrigger == false)
                {
                    transform.x = oldX;
                    transform.y = oldY;
                    break;
                }
            }
        }
    }
}
