using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxMultiplier;
    public Vector3 originalPosition;

    private Transform _transform;

    private void Start()
    {
        this._transform = this.transform;
        this.originalPosition = _transform.position;
    }

    void LateUpdate()
    {
        this._transform.position = this.originalPosition + (Vector3)CalculateParallax();
    }

    Vector2 CalculateParallax()
    {
        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.x = Mathf.Clamp(worldPos.x, -128, 128);
        worldPos.y = Mathf.Clamp(worldPos.y, -72, 72);
        return -worldPos * parallaxMultiplier;
    }
}
