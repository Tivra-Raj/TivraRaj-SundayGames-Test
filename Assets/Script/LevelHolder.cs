using UnityEngine;

[CreateAssetMenu (fileName = "LevelHolder", menuName = "Create Level / Level Holder")]
public class LevelHolder : ScriptableObject
{
    [SerializeField] private Level[] levels;

    public Level[] Levels => levels;
}