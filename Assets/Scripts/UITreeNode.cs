using UnityEngine;
using System.Collections.Generic;
public class UITreeNode : MonoBehaviour
{
    public UITreeNode Parent;
    public object Value;
    public List<UITreeNode> Children = new List<UITreeNode>();

    private List<LineToChild> childLines = new List<LineToChild>();
    public LineToChild lineprefab;

    public void Set(object _value, UITreeNode _parent)
    {
        Value = _value;
        Parent = _parent;
        if (Parent != null)
        {
            Parent.Children.Add(this);
        }
    }

    public bool HasParent()
    {
        return Parent != null;
    }
    public void Start()
    {
       // DrawLinesToChildren();
        Invoke("DrawLinesToChildren", 1f);
    }
    void Update()
    {
        
    }

    void DrawLinesToChildren()
    {
        // Limpia los line renderers anteriores
        foreach (var lr in childLines)
        {
            if (lr != null)
                Destroy(lr.gameObject);
        }
        childLines.Clear();
        Color randomColor = Random.ColorHSV();
        foreach (var child in Children)
        {
            LineToChild lineObj = Instantiate(lineprefab);
            lineObj.transform.SetParent(this.transform);

           
            lineObj.Set(transform, child.transform, randomColor);
            childLines.Add(lineObj);
        }
    }
}
