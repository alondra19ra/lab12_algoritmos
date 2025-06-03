using UnityEngine;
using System.Collections.Generic;

public class UITree : MonoBehaviour
{
    public UITreeNode uiNodeTreePrefab;

    [SerializeField] private int spacingX = 5;
    [SerializeField] private int spacingY = 5;

    [SerializeField] private Tree<object> TreeData;

    public List<UITreeNode> TreeNodes = new List<UITreeNode>();

    public void Set(Tree<object> _tree)
    {
        TreeData = _tree;
        TreeNodes.Clear();

        if (_tree != null && _tree.Root != null)
        {
            createAndPopulate(_tree.Root);
        }
    }

    public void createAndPopulate(TreeNode<object> _treeNode, UITreeNode _parent = null)
    {
        UITreeNode node = Instantiate(uiNodeTreePrefab, transform);

        node.name = _treeNode.Value.ToString();
        node.Set(_treeNode.Value, _parent);

        TreeNodes.Add(node);

        float x = -TreeData.GeLevel(_treeNode) * spacingX;  
        float y = 0;



        if (_parent != null)
        { 

            int siblingsCount =  _treeNode.Parent.Children.Count;

            int siblingIndex = _treeNode.Parent.Children.IndexOf(_treeNode);

            float totalHeight = (siblingsCount - 1) * spacingY;

            float startY = _parent.transform.localPosition.y + totalHeight / 2f;

            y = startY - siblingIndex * spacingY; ;

        }
        else
        {
            y = 0f;
        }

        foreach (var otherNode in TreeNodes)
        {
            if (otherNode == node) continue;

            // Solo verificamos si están en la misma columna (X muy parecido)
            if (Mathf.Abs(otherNode.transform.localPosition.x - x) < 0.1f)
            {
                // Si la distancia vertical es muy pequeña, movemos este nodo hacia abajo
                if (Mathf.Abs(otherNode.transform.localPosition.y - y) < spacingY)
                {
                    y = otherNode.transform.localPosition.y - spacingY;
                }
            }
        }


        node.transform.localPosition = new Vector3(x, y, 0);

        foreach (var child in _treeNode.Children)
        {
            createAndPopulate(child, node);
        }
    }

}
