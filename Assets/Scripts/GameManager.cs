using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UITree uiTree;

    public Tree<object> AgumonEvoTree = new Tree<object>("Agumon");

    void Start()
    {
        #region Evolutions From Agumon
        var greymon = new TreeNode<object>("Greymon");
        var dramon = new TreeNode<object>("V-Dramon");
        var tuskmon = new TreeNode<object>("Tuskmon");
        var tyranomon = new TreeNode<object>("Tyranomon");
        AgumonEvoTree.Root.AddChild(greymon);
        AgumonEvoTree.Root.AddChild(dramon);
        AgumonEvoTree.Root.AddChild(tuskmon);
        AgumonEvoTree.Root.AddChild(tyranomon);
        #endregion
        #region Evolutions From dramon
        var aerovDramon = new TreeNode<object>("Aerov-Dramon");
        dramon.AddChild(aerovDramon);
            #region Evolutions From Aerov-Dramon
            var godDramon = new TreeNode<object>("GodDramon");
            var ultraForcedDramon = new TreeNode<object>("UltraForced-Dramon");
            aerovDramon.AddChild(godDramon);
            aerovDramon.AddChild(ultraForcedDramon);
        #endregion
        #endregion
        #region Evolutions From Greymoon
        var sullGreymon = new TreeNode<object>("SkullGreymon");
        var metalGreymonVirus = new TreeNode<object>("MetalGreymonVirus");
        var metalGreymonVaccine = new TreeNode<object>("MetalGreymonVaccine");
        greymon.AddChild(sullGreymon);
        greymon.AddChild(metalGreymonVirus);
        greymon.AddChild(metalGreymonVaccine);
        #endregion
        #region Evolutions From Tyramon
        var nametyramon = new TreeNode<object>("NameTyramon");
        var mastertyranomon = new TreeNode<object>("Mastertyranomon");
        tyranomon.AddChild(nametyramon);
        tyranomon.AddChild(mastertyranomon);
        #endregion.



        AgumonEvoTree.TraversePreOrder(AgumonEvoTree.Root, var => Debug.Log(var));


        uiTree.Set(AgumonEvoTree);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
}
