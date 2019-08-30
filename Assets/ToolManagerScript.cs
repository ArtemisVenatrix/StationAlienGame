using System.Collections;
using System.Collections.Generic;
using Classes.BodyAssets;
using UnityEngine;

public class ToolManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool rootPlaced;

    [SerializeField] public GameObject skullTemplate;
    [SerializeField] public GameObject legBoneTemplate;
    [SerializeField] public GameObject armBoneTemplate;
    [SerializeField] public GameObject vertebraeTemplate;
    [SerializeField] public GameObject shoulderTemplate;
    [SerializeField] public GameObject pelvisTemplate;
    [SerializeField] public GameObject handBoneTemplate;
    [SerializeField] public GameObject footBoneTemplate;
    [SerializeField] public GameObject vertexTemplate;
    [SerializeField] public GameObject boneContainer;
    
    void Start()
    {
        rootPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceRoot()
    {
        GameObject tempV = Instantiate(vertexTemplate);
        tempV.SetActive(true);
        tempV.transform.parent = boneContainer.transform;
        GameObject tempS = Instantiate(skullTemplate);
        tempS.SetActive(true);
        tempS.GetComponent<Skull>().Init(tempV);
    }
}
