using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTempRaycastor : MonoBehaviour
{
    public ARRaycastManager Manager_ARRaycast;
    public GameObject Prefab_Object;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UpdateCenterObject();
        }
    }


    private void UpdateCenterObject()
    {
        Vector3 screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        Manager_ARRaycast.Raycast(screenCenter, hits, TrackableType.Planes);

        if(hits.Count > 0)
        {
            Pose firstHittedPlacePos = hits[0].pose;
            Instantiate(Prefab_Object, firstHittedPlacePos.position, firstHittedPlacePos.rotation);
        }
    }
}
