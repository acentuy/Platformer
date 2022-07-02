using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float delta = 0.01f;
    [SerializeField] private Transform Camera;
    [SerializeField] private Transform Player;

    private float speed = 0.06f;
    private void Update()

    {
        if (Player == null) return;
        var cameraPosition = Camera.position;
        cameraPosition.x = Mathf.Lerp(cameraPosition.x, Player.position.x, speed);
        cameraPosition.y = Mathf.Lerp(cameraPosition.y, Player.position.y, speed)+ delta;
        Camera.position = cameraPosition;
    }
}

