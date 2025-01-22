using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private Brick[] bricks;

    public void ActivateBrick(BrickTypeEnum brickType)
    {
        foreach (Brick brick in bricks)
        {
            if (brick == null)
            {
                continue;
            }

            // Activate the brick if it matches the type, deactivate otherwise
            brick.gameObject.SetActive(brick.BrickType == brickType);
        }
    }
}
