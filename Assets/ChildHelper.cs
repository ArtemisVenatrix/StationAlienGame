using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChildHelper : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<string, GameObject> children;
    private List<Type> filters;
    
    [SerializeField] public List<string> FilterStrings;
    void Start()
    {
        children = new Dictionary<string, GameObject>();
        if (FilterStrings.Contains("all"))
        {
            foreach (Transform child in transform)
            {
                GameObject childGameObject = child.gameObject;
                children[childGameObject.name] = childGameObject;
            }
        }
        else
        {
            //filters = (from type in FilterStrings select Type.GetType(type)) as List<Type>;
            foreach (Transform child in transform)
            {
                GameObject childGameObject = child.gameObject;
                foreach (var name in FilterStrings)
                {
                    if (childGameObject.name.Contains(name))
                    {
                        children[childGameObject.name] = childGameObject;
                    }
                }
                /*foreach (var type in filters)
                {
                    if (TestWithFilter(childGameObject, type))
                    {
                        children[childGameObject.name] = childGameObject;
                        break;
                    }
                }*/
            }
        }
        Debug.Log("Listing Requested Children Of " + gameObject.name + ":");
        foreach (var pairs in children)
        {
            Debug.Log(pairs);
        }
    }

    private bool TestWithFilter(GameObject subject, Type filter)
    {
        if (subject.GetComponents(filter).Length > 0)
        {
            return true;
        }

        return false;
    }

    public Dictionary<string, GameObject> GetChildren()
    {
        return children;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
