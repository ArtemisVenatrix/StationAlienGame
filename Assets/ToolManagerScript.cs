using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool rootPlaced;

    [SerializeField] public GameObject Skull;
    [SerializeField] public GameObject LegBone;
    [SerializeField] public GameObject ArmBone;
    [SerializeField] public GameObject Vertebrae;
    [SerializeField] public GameObject Shoulder;
    [SerializeField] public GameObject Pelvis;
    [SerializeField] public GameObject HandBone;
    [SerializeField] public GameObject FootBone;
    void Start()
    {
        rootPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void placeRoot()
    {
        
    }
}
