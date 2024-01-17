using UnityEngine;

public class Ball : MonoBehaviour, ILocalPositionAdapter
{
    public Vector3 LocalPosition
    { 
        get 
        {
            return transform.localPosition;
        }

        set 
        {
            transform.localPosition = value;
        }
    }

    public Vector3 velocity;

    private Logic logic;
    private Simulation simulation;

    void Awake()
    {
        this.simulation = new Simulation(velocity);
        this.logic = new Logic(this, simulation);
        logic.onDestroyed += DestroyBall;
    }

    private void DestroyBall(string message)
    {
        Destroy(this.gameObject);
        Debug.Log(message);
    }

    void FixedUpdate()
    {
        logic.UpdatePosition(Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        logic.Hit(collider.gameObject);
    }
}

public interface ILocalPositionAdapter
{
    Vector3 LocalPosition { get; set; }
}

public delegate void OnDestroyed(string message);

public class Logic
{
    public ILocalPositionAdapter Adapter { get; private set; }
    public Simulation Simulation { get; private set; }

    public OnDestroyed onDestroyed;

    public Logic(ILocalPositionAdapter adapter, Simulation sim)
    {
        this.Adapter = adapter;
        this.Simulation = sim;
    }

    public void UpdatePosition(float deltaTime)
    {
        Simulation.UpdatePosition(Adapter, new Vector3(-3, 0, 0), deltaTime);
    }

    public void Hit(GameObject go)
    {
        var wall = go.GetComponentInChildren<Wall>();

        if (wall != null)
        {
            onDestroyed(go.name);
        }
    }
}

public class Simulation
{
    public Vector3 InitialVelocity { get; private set; }

    public Simulation(Vector3 initialVelocity)
    {
        this.InitialVelocity = initialVelocity;
    }

    public void UpdatePosition(ILocalPositionAdapter adapter, Vector3 newPosition, float deltaTime)
    {
        adapter.LocalPosition += newPosition * deltaTime;
    }
}