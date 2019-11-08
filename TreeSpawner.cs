using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    //public GameObject Player;
    public GameObject PlantHole; //global var to store the planting hole GO
    public GameObject Tree; //global var to store the tree GO

    private GameObject MyPlantHole;
    
    public bool collision = false; //watches over where the player is compared to the plant hole

    public Transform PlantHoleLoc;
        
    

    // Start is called before the first frame update
    void Start()
    {
        //PlantHoleLoc = PlantHole.transform;

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown("space") && collision) //detects when the player presses spacebar
            {
                
                PlantTree(Tree); //call the instruction to plant the tree
                DestroyGameObject(PlantHole);

                
            }

    }

    
    void OnTriggerEnter2D(Collider2D PlantHole)
    {
       if (PlantHole.tag == "PlantHole") 
        {
            Debug.Log("Hi PlantHole");
            collision = true;
            PlantHoleLoc = PlantHole.transform;
            MyPlantHole = PlantHole.gameObject;

        }
    }

    void OnTriggerExit2D(Collider2D PlantHole)
    {
        if (PlantHole.tag == "PlantHole") 
        {
            Debug.Log("Bye PlantHole");
            collision = false;
        }
    }

    void PlantTree(GameObject t)
    {
        Instantiate(Tree, PlantHoleLoc.position, PlantHoleLoc.rotation);  //instantiates a tree GO
        Tree.tag = "Tree";
        Debug.Log("I'm Instantiating");
        GameText.score += 100;      //gain points for planting a tree
        GameText.treeCount++;
    }

    void DestroyGameObject(GameObject t)
    {
        Destroy(MyPlantHole);
    }
}
