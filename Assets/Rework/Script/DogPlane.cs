using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class DogPlane : MonoBehaviour
{
    [SerializeField] private GameObject dog;
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private ARPlaneManager planeManager;
    private ARPlane selectedPlane = null;
    
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && selectedPlane == null)
            {
                if (raycastManager.Raycast(touch.position,hits,TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;

                    ARPlane plane = planeManager.GetPlane(hits[0].trackableId);
                    if (plane != null)
                    {
                        selectedPlane = plane;
                        PlacingDog();
                    }
                }
            }
        }

    }

    private void PlacingDog()
    {
        Vector3 planeCenter = selectedPlane.center;
        Vector3 planePosition = selectedPlane.transform.TransformPoint(planeCenter);

        Instantiate(dog, planePosition, Quaternion.identity);
    }
}
