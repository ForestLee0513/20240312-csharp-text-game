class PlayerController : Component
{
    public override void Update()
    {
        if(transform == null)
        {
            return;
        }

        if (Input.GetButton("Up"))
        {
            transform.y--;
        }

        if (Input.GetButton("Down"))
        {
            transform.y++;
        }

        if (Input.GetButton("Left"))
        {
            transform.x--;
        }

        if (Input.GetButton("Right"))
        {
            transform.x++;
        }

        if (Input.GetButton("Exit"))
        {
            Engine.GetInstance().Stop();
        }

        transform.x = Math.Clamp(transform.x, 0, 80);
        transform.y = Math.Clamp(transform.y, 0, 80);
    }
}

