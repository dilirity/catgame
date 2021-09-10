using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    Vector3 offset = new Vector3(0, 5, -10);

    void Update()
    {
        transform.position = player.position + offset;
    }
}
