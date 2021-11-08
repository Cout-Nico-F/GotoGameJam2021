using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace GrapplingJam
{
    public class GrapplingInput : MonoBehaviour
    {
        [SerializeField] private GrapplingGun grapplingGun;
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
                    grapplingGun.SetGrapplePoint(); canGrappling = false;
                }
                else if (Input.GetKey(KeyCode.Mouse0))
                {
                    if (grapplingGun.grappleRope.enabled)
                    {
                        grapplingGun.RotateGun(grapplingGun.GrapplePoint, false);
                    }
                    else
                    {
                        Vector2 mousePos = grapplingGun.Camera.ScreenToWorldPoint( new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
                        grapplingGun.RotateGun(mousePos, true);
                    }

                    if (grapplingGun.LaunchToPoint && grapplingGun.grappleRope.isGrappling)
                    {
                        if (grapplingGun.LaunchType == LaunchType.Transform_Launch)
                        {
                            Vector2 firePointDistnace = grapplingGun.FirePoint.position - grapplingGun.GunHolder.localPosition;
                            Vector2 targetPos = grapplingGun.GrapplePoint - firePointDistnace;
                            grapplingGun.GunHolder.position = Vector2.Lerp(grapplingGun.GunHolder.position, targetPos, Time.deltaTime * grapplingGun.LaunchSpeed);
                        }
                    }
                }
                else if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    grapplingGun.grappleRope.enabled = false;
                    grapplingGun.SpringJoint2D.enabled = false;
                    grapplingGun.Rigidbody.gravityScale = 0;
                }
                else
                {
                    Vector2 mousePos = grapplingGun.Camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
                    grapplingGun.RotateGun(mousePos, true);
                }
            }
        }
    }
}