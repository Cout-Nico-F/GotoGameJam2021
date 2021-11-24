using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [System.Serializable]
    public struct Area
    {
        public string areaName;
        public Vector2 horizontalLimits;
        public Vector2 verticalLimits;
    }

    [SerializeField] private Area[] areas;
    [SerializeField] private Area currentArea;

    private void Start()
    {
        currentArea = areas[0];
    }


    private void Update()
    {
        var horizontal = Mathf.Clamp(target.position.x, currentArea.horizontalLimits.x, currentArea.horizontalLimits.y);
        var vertical = Mathf.Clamp(target.position.y, currentArea.verticalLimits.x, currentArea.verticalLimits.y);
        transform.position = new Vector3(horizontal, vertical, transform.position.z);
    }


    public void ChangeArea(int areaIndex)
    {
        if (areaIndex < 0 || areaIndex >= areas.Length)
        {
            Debug.LogError("El index se sale de los limites del array");
            return;
        }

        currentArea = areas[areaIndex];
    }
}
