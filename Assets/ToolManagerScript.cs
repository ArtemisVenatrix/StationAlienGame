using System.Collections;
using System.Collections.Generic;
using Classes.BodyAssets;
using UnityEngine;
using UnityEngine.UI;

public class ToolManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject myRoot;
    public GameObject Root
    {
        get { return myRoot; }
        set
        {
            if (myRoot == value) return;
            myRoot = value;
            if (OnRoot != null)
                OnRoot(myRoot);
        }
    }
    private List<GameObject> selected;
    private Dictionary<string, GameObject> Templates;
    
    [SerializeField] public GameObject boneContainer;
    [SerializeField] public ChildHelper toolMenuChildHelper;

    public delegate void OnRootDelegate(GameObject newVal);

    public event OnRootDelegate OnRoot;

    void Start()
    {
        OnRoot += OnRootHandler;
        Templates = gameObject.GetComponent<ChildHelper>().GetChildren();
    }

    private void OnRootHandler(GameObject newVal)
    {
        if (newVal == null)
        {
            foreach (var pair in toolMenuChildHelper.GetChildren())
            {
                if (pair.Key.Equals("SkullButton"))
                {
                    pair.Value.GetComponent<Button>().interactable = true;
                }
                else
                {
                    pair.Value.GetComponent<Button>().interactable = false;
                }
            }
            
        }
        else
        {
            foreach (var pair in toolMenuChildHelper.GetChildren())
            {
                if (pair.Key.Equals("SkullButton"))
                {
                    pair.Value.GetComponent<Button>().interactable = false;
                }
                else
                {
                    pair.Value.GetComponent<Button>().interactable = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceSkull()
    {
        GameObject tempV = Instantiate(Templates["VertexTemplate"]);
        tempV.SetActive(true);
        tempV.transform.parent = boneContainer.transform;
        Debug.Log(tempV);
        GameObject tempS = Instantiate(Templates["SkullTemplate"]);
        tempS.SetActive(true);
        tempS.transform.parent = boneContainer.transform;
        tempS.GetComponent<Skull>().Init(tempV);
        Root = tempS;
    }
}
