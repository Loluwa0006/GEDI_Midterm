using UnityEngine;

public class PlayerEntity : BaseEntity
{
    [SerializeField] InputManager inputManager;
    [SerializeField] GameObject Bubble;

    public InputManager InputManager { get { return inputManager; } }


    public ObjectPool<GameObject> bubble;

    private void Start()
    {
        bubble = new ObjectPool<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            bubble.AddToPool(Instantiate(Bubble));
        }
    }
    private void Update()
    {
        if (inputManager.WasBubblePressed())
        {
            var bubbles = bubble.GetNewObject();
            bubble.transform.position = transform.position;
            Bubble.GetComponent<Rigidbody2D>().AddForce(new Vector2(inputManager.GetMovementDirection() * 20, 0));
        }
    }

}
