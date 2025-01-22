using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private Brick brickPrefab;
    [SerializeField] private BrickTypeEnum brickType;

    public Brick BrickPrefab => brickPrefab;
    public BrickTypeEnum BrickType => brickType;
}