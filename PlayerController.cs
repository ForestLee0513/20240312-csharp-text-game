using SDL2;
using System.Diagnostics;

class PlayerController : Component
{
    SpriteRenderer? renderer;
    public override void Start()
    {
        base.Start();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.currentYIndex = 3;
    }

    public override void Update()
    {
        int oldX = transform.x;
        int oldY = transform.y;
        if(transform == null)
        {
            return;
        }


        if (Input.GetButton("Up"))
        {
            transform.Translate(0, -1);
            renderer.currentYIndex = 2;
        }

        if (Input.GetButton("Down"))
        {
            transform.Translate(0, 1);
            renderer.currentYIndex = 3;
        }

        if (Input.GetButton("Left"))
        {
            transform.Translate(-1, 0);
            renderer.currentYIndex = 0;
        }

        if (Input.GetButton("Right"))
        {
            transform.Translate(1, 0);
            renderer.currentYIndex = 1;
        }

        if (Input.GetButton("Exit"))
        {
            Engine.GetInstance().Stop();
        }

        transform.x = Math.Clamp(transform.x, 0, 80);
        transform.y = Math.Clamp(transform.y, 0, 80);

        for (int i = 0; i < Engine.GetInstance().gameObjects.Count; i++)
        {
            GameObject findGameObject = Engine.GetInstance().gameObjects[i];

            if(findGameObject.transform == transform)
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

                else if(collider2D.Check(gameObject) == true && collider2D.isTrigger == true)
                {
                    if (findGameObject.name == "Monster")
                    {
                        Engine.GetInstance().Find("GameManager").GetComponent<GameManager>().isGameOver = true;
                    }
                    else if (findGameObject.name == "Goal")
                    {
                        Engine.GetInstance().Find("GameManager").GetComponent<GameManager>().isNextLevel = true;
                    }
                }
            }
        }
    }
}

