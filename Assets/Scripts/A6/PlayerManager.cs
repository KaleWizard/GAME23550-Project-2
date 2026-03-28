using UnityEngine;

public class PlayerManager : SingletonBehaviour<PlayerManager>
{
    protected override bool BindToScene => true;

    public static Transform PlayerTransform => Instance.playerTransform ??= FindAnyObjectByType<PlayerController>().transform;
    Transform playerTransform = null;
}
