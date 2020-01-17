using UnityEngine;

public class FollowP : MonoBehaviour
{
    public GameObject Player;
    public Vector3 offset;

   

    void LateUpdate()
    {
        float newXPosition = Player.transform.position.x - offset.x;
        float newYPosition = Player.transform.position.y - offset.y;
        float newZPosition = Player.transform.position.z - offset.z;

        transform.position = new Vector3(newXPosition, newYPosition, newZPosition);
    }
}
