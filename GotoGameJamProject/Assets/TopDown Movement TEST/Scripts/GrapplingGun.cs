using UnityEngine;
namespace GrapplingJam
{
    public enum LaunchType
    {
        Transform_Launch,
        Physics_Launch
    }
    public class GrapplingGun : MonoBehaviour
    {
        [Header("Scripts Ref:")]
        public GrapplingRope grappleRope;

        [Header("Layers Settings:")]
        [SerializeField] private bool grappleToAll = false;
        [SerializeField] private int grappableLayerNumber = 9;

        [Header("Main Camera:")]
        [SerializeField] private Camera m_camera;

        [Header("Transform Ref:")]
        [SerializeField] private Transform gunHolder;
        [SerializeField] private Transform gunPivot;
        [SerializeField] private Transform firePoint;

        [Header("Physics Ref:")]
        [SerializeField] private SpringJoint2D m_springJoint2D;
        [SerializeField] private Rigidbody2D m_rigidbody;

        [Header("Rotation:")]
        [SerializeField] private bool rotateOverTime = true;
        [Range(0, 60)] [SerializeField] private float rotationSpeed = 4;

        [Header("Distance:")]
        [SerializeField] private bool hasMaxDistance = false;
        [SerializeField] private float maxDistnace = 20;

        [Header("Launching:")]
        [SerializeField] private bool launchToPoint = true;
        [SerializeField] private LaunchType launchType = LaunchType.Physics_Launch;
        [SerializeField] private float launchSpeed = 1;

        [Header("No Launch To Point")]
        [SerializeField] private bool autoConfigureDistance = false;
        [SerializeField] private float targetDistance = 3;
        [SerializeField] private float targetFrequncy = 1;

        private Vector2 grapplePoint;
        private Vector2 grappleDistanceVector;

        public Transform GunHolder { get => gunHolder; set => gunHolder = value; }
        public Vector2 GrapplePoint { get => grapplePoint; set => grapplePoint = value; }
        public Vector2 GrappleDistanceVector { get => grappleDistanceVector; set => grappleDistanceVector = value; }
        public bool LaunchToPoint { get => launchToPoint; set => launchToPoint = value; }
        public LaunchType LaunchType { get => launchType; set => launchType = value; }
        public float LaunchSpeed { get => launchSpeed; set => launchSpeed = value; }
        public Camera Camera { get => m_camera; set => m_camera = value; }
        public Transform FirePoint { get => firePoint; set => firePoint = value; }
        public Rigidbody2D Rigidbody { get => m_rigidbody; set => m_rigidbody = value; }
        public SpringJoint2D SpringJoint2D { get => m_springJoint2D; set => m_springJoint2D = value; }

        private void Start()
        {
            grappleRope.enabled = false;
            m_springJoint2D.enabled = false;
        }

        public void RotateGun(Vector3 lookPoint, bool allowRotationOverTime)
        {
            Vector3 distanceVector = lookPoint - gunPivot.position;

            float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
            if (rotateOverTime && allowRotationOverTime)
            {
                gunPivot.rotation = Quaternion.Lerp(gunPivot.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
            }
            else
            {
                gunPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }

        public void SetGrapplePoint()
        {
            Vector2 distanceVector = m_camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.current.nearClipPlane)) - gunPivot.position;
            if (Physics2D.Raycast(firePoint.position, distanceVector.normalized))
            {
                RaycastHit2D _hit = Physics2D.Raycast(firePoint.position, distanceVector.normalized);
                if (_hit.transform.gameObject.layer == grappableLayerNumber || grappleToAll)
                {
                    if (Vector2.Distance(_hit.point, firePoint.position) <= maxDistnace || !hasMaxDistance)
                    {
                        grapplePoint = _hit.point;
                        grappleDistanceVector = grapplePoint - (Vector2)gunPivot.position;
                        grappleRope.enabled = true;
                    }
                }
            }
        }

        public void Grapple()
        {
            m_springJoint2D.autoConfigureDistance = false;
            if (!launchToPoint && !autoConfigureDistance)
            {
                m_springJoint2D.distance = targetDistance;
                m_springJoint2D.frequency = targetFrequncy;
            }
            if (!launchToPoint)
            {
                if (autoConfigureDistance)
                {
                    m_springJoint2D.autoConfigureDistance = true;
                    m_springJoint2D.frequency = 0;
                }

                m_springJoint2D.connectedAnchor = grapplePoint;
                m_springJoint2D.enabled = true;
            }
            else
            {
                switch (launchType)
                {
                    case LaunchType.Physics_Launch:
                        m_springJoint2D.connectedAnchor = grapplePoint;

                        Vector2 distanceVector = firePoint.position - gunHolder.position;

                        m_springJoint2D.distance = distanceVector.magnitude;
                        m_springJoint2D.frequency = launchSpeed;
                        m_springJoint2D.enabled = true;
                        break;
                    case LaunchType.Transform_Launch:
                        m_rigidbody.gravityScale = 0;
                        m_rigidbody.velocity = Vector2.zero;
                        break;
                }
            }
        }

        public void OnDrawGizmosSelected()
        {
            if (firePoint != null && hasMaxDistance)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(firePoint.position, maxDistnace);
            }
        }

    }
}