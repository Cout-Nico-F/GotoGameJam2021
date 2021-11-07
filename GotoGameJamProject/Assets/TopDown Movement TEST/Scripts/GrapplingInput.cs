using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace GrapplingJam
{
    public class GrapplingInput : MonoBehaviour
    {
        [SerializeField] private GrapplingGun GGS;
        [SerializeField] private PhotonView photonView;
        [SerializeField] private float maxGrapplingTimer;
        private float grapplingTimer;
        private bool canGrappling;


        private void Update()
        {
            if (photonView.IsMine)
            {
                if (!canGrappling)
                {
                    if (grapplingTimer < maxGrapplingTimer)
                    { grapplingTimer += Time.deltaTime; }
                    else
                    { grapplingTimer = 0; canGrappling = true; }
                }

                if (Input.GetKeyDown(KeyCode.Mouse0) && canGrappling)
                {
                    GGS.SetGrapplePoint(); canGrappling = false;
                }
                else if (Input.GetKey(KeyCode.Mouse0))
                {
                    if (GGS.grappleRope.enabled)
                    {
                        GGS.RotateGun(GGS.GrapplePoint, false);
                    }
                    else
                    {
                        Vector2 mousePos = GGS.Camera.ScreenToWorldPoint(Input.mousePosition);
                        GGS.RotateGun(mousePos, true);
                    }

                    if (GGS.LaunchToPoint && GGS.grappleRope.isGrappling)
                    {
                        if (GGS.LaunchType == LaunchType.Transform_Launch)
                        {
                            Vector2 firePointDistnace = GGS.FirePoint.position - GGS.GunHolder.localPosition;
                            Vector2 targetPos = GGS.GrapplePoint - firePointDistnace;
                            GGS.GunHolder.position = Vector2.Lerp(GGS.GunHolder.position, targetPos, Time.deltaTime * GGS.LaunchSpeed);
                        }
                    }
                }
                else if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    GGS.grappleRope.enabled = false;
                    GGS.SpringJoint2D.enabled = false;
                    GGS.Rigidbody.gravityScale = 0;
                }
                else
                {
                    Vector2 mousePos = GGS.Camera.ScreenToWorldPoint(Input.mousePosition);
                    GGS.RotateGun(mousePos, true);
                }
            }
        }
    }
}