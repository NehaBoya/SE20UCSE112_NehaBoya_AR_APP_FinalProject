using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ContentManager : MonoBehaviour
{

    public Toggle BirdToggle;
    public GameObject MummaBirdPrefab;
    public GameObject BabyBirdPrefab;
    private GameObject SpawnedBird;
    public Camera ARCamera;

    private List<RaycastResult> RaycastResults = new List<RaycastResult>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Down!");

            Ray ray = ARCamera.ScreenPointToRay(Input.mousePosition);
            Debug.Log(ray);

            if (IsPointerOverUI(Input.mousePosition))
            {
                Debug.Log("Do Nothing!");
            }
            else
            {
                SpawnedBird = Instantiate(WhichBird(), ray.origin, Quaternion.identity);
                SpawnedBird.GetComponent<Rigidbody>().AddForce(ray.direction * 100);
            }
        }
        
    }


    public GameObject WhichBird()
    {
        if (BirdToggle.isOn)
        {
            return MummaBirdPrefab;
        }
        else
        {
            return BabyBirdPrefab;
        }
    }

    private bool IsPointerOverUI(Vector2 fingerPosition)
    {
        PointerEventData eventDataPosition = new PointerEventData(EventSystem.current);
        eventDataPosition.position = fingerPosition;
        EventSystem.current.RaycastAll(eventDataPosition, RaycastResults);
        return RaycastResults.Count > 0;
    }

}
