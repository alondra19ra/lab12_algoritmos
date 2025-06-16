using System.Collections.Generic;
using UnityEngine;

public class TreeNode<T>
{
    public T Value { get; set; }
    public TreeNode<T> Parent { get; private set; }
    public List<TreeNode<T>> Children { get; private set; }

    public TreeNode(T value)
    {
        Value = value;
        Children = new List<TreeNode<T>>();
    }

    public void AddChild(TreeNode<T> child)
    {
        if (Children.Count >= 2)
        {
            Debug.LogWarning("Un árbol binario solo puede tener dos hijos.");
            return;
        }
        child.Parent = this;
        Children.Add(child);
    }

    public bool RemoveChild(TreeNode<T> child)
    {
        if (Children.Remove(child))
        {
            child.Parent = null;
            return true;
        }
        return false;
    }
}