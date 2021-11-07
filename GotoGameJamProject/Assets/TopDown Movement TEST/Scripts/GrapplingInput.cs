using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrapplingJam
{
    public class GrapplingInput : MonoBehaviour
    {
        [SerializeField] private GrapplingGun GGS;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GGS.SetGrapplePoint();
            }
            else if (Input.GetKey(KeyCode.Mouse0))
            {
                if (GGS.grappleRope.enabled)
                {
                    GGS.RotateGun(GGS.grapplePoint, false);
                }
                else
                {
                    Vector2 mousePos = GGS.m_camera.ScreenToWorldPoint(Input.mousePosition);
                    GGS.RotateGun(mousePos, true);
                }

                if (GGS.launchToPoint && GGS.grappleRope.isGrappling)
                {
                    if (GGS.launchType == LaunchType.Transform_Launch)
                    {
                        Vector2 firePointDistnace = GGS.firePoint.position - GGS.gunHolder.localPosition;
                        Vector2 targetPos = GGS.grapplePoint - firePointDistnace;
                        GGS.gunHolder.position = Vector2.Lerp(GGS.gunHolder.position, targetPos, Time.deltaTime * GGS.launchSpeed);
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                GGS.grappleRope.enabled = false;
                GGS.m_springJoint2D.enabled = false;
                GGS.m_rigidbody.gravityScale = 0;
            }
            else
            {
                Vector2 mousePos = GGS.m_camera.ScreenToWorldPoint(Input.mousePosition);
                GGS.RotateGun(mousePos, true);
            }
        }
    }
}