/**
 *  HOW TO ADD NEW LEVEL PARTS:
 * -----------------------------
 *  Pull an existing level part
 *  from the "Prefabs" folder
 *  into your scene.
 *
 *  Edit the Tilemap inside the
 *  Grid to your liking.
 *  
 *  When you are finished,
 *  MAKE SURE TO RENAME THE
 *  WHOLE LEVEL PART before
 *  pulling it back into
 *  the "Prefabs" folder
 *  and deleting the part
 *  from your scene.
 *
 *  Next, add a new level 
 *  part to this script 
 *  down below.
 *
 *  Don't forget to insert
 *  the length into the
 *  {lengthArray} and increase
 *  the {arrayLength}.
 *  
 *  Then add the new level 
 *  part to [allLevelParts]
 *  in the Awake() method.
 *  
 *  You're almost done.
 *  Inspect the 
 *  {LevelGenerator} object
 *  in Unity and pull your 
 *  generated Prefab into
 *  the new empty 
 *  "Level Generator (Script)"
 *  slot.
 *
 *
 *  -> if the new part collides
 *     with other parts:
 *     ------------------------
 *     Check the {lengthArray}
 *     and play around with the
 *     length of the new part
 *     a bit (the old ones
 *     should be fine).
 *
 *
 *  -> if everything works:
 *     --------------------
 *     Congrats, you
 *     successfully added
 *     a new part to the
 *     game! :D
 */


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // add new level parts here
    [SerializeField] private Transform levelPart_1;
    [SerializeField] private Transform levelPart_2;

    // lengths of parts should be their grid length + 2 (for space in between)
    private int[] lengthArray = new int[] {17, 12};

    private int arrayLength = 2;        // length of array above
    private int rIndex;                 // randomly generated index
    private int current_posX = 0;       // current generation position

    void Awake() {
        // list that contains all levelParts initialized at the beginning
        List<Transform> allLevelParts = new List<Transform> {levelPart_1, levelPart_2};

        // this line is used to make sure the player doesn't fall on spawn
        SpawnLevelPart(allLevelParts[0]);

        for (int i = 0; i < 5; i++)
        {
            // generate new random number for random platform generation
            var random = new System.Random();
            rIndex = (int) Math.Floor(random.NextDouble() * arrayLength);
            SpawnLevelPart(allLevelParts[rIndex]);
        }
    }

    private void SpawnLevelPart(Transform currPart) {
        Vector3 spawnPosition = new Vector3(current_posX,0);
        Instantiate(currPart, spawnPosition, Quaternion.identity);

        current_posX = current_posX + lengthArray[rIndex];
    }
}