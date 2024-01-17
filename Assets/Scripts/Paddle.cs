using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("Static Data")]
    public PaddleData data;

    public string InputAxisName;

    private float yPosition;
    private MeshRenderer mesh;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }
}

[CreateAssetMenu(fileName = "Data", menuName = "Delorenzo/PaddleData", order = 1)]
public class PaddleData : ScriptableObject
{
    public float MovementSpeedScaleFactor;
    public float PositionScale;
}