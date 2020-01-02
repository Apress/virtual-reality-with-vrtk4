using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Menu_Controller : MonoBehaviour
{
    // Create an array to hold the Transform components of each statue
    Transform[] statues = new Transform [3];

    // Define 3 public GameObject fields into which we can drag our statues
    public GameObject statue_1;
    public GameObject statue_2;
    public GameObject statue_3;

    void Start()
    {
        // Load the statue array with our scene's statues
        statues[0] = statue_1.transform;
        statues[1] = statue_2.transform;
        statues[2] = statue_3.transform;
    }

    // The function fired by the Button Action click event
    public void FindNearestStatue()
    {
        // Define an empty variable to hold the nearest statue
        Transform bestTarget = null;

        // Define a variable to hold a ridiculously large number
        float closestDistanceSqr = Mathf.Infinity;

        // Store the user's position in a variable
        Vector3 currentPosition = transform.position;

        // Iterate over the collection of statues in the scene
        foreach (Transform potentialTarget in statues)
        {
            // Store the distance between a statue and the user in a Vector3 variable
            Vector3 directionToTarget = potentialTarget.position - currentPosition;

            // Store the distance between a statue and the user squared
            float dSqrToTarget = directionToTarget.sqrMagnitude;

            // Compare the distance between the statue and user to the previously stored smallest distance
            if(dSqrToTarget < closestDistanceSqr)
            {
                // If the distance between the statue and the user is smaller than a previously calculated distance...
                // Store the current distance as the smallest distance
                closestDistanceSqr = dSqrToTarget;

                // Save the transform with the shortest distance as the value of the bestTarget variable
                bestTarget = potentialTarget;
            }
        }

        // Log the name of the closest statue for testing
        Debug.Log(bestTarget.name);

        // Store the canvas object of the nearest statue in a variable
        Canvas canvas = bestTarget.GetComponentInChildren<Canvas>();

        // Store the text object of the nearest object's canvas in a variable
        TextMeshPro text = canvas.GetComponentInChildren<TextMeshPro>();

        // Toggle the state of the nearest statue's canvas
        if (!canvas.enabled)
            canvas.enabled = true;
        else
            canvas.enabled = false;

    }
}