using Assets.Scripts.Scene2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scene3
{

    public class GameManager : MonoBehaviour
    {
        public GameObject[] shapes_array;
        public GameObject shape1;
        public GameObject shape2;
        public GameObject shape3;

        public Vector3[] origins_array = new Vector3[3];
        public Vector3 Origin0;
        public Vector3 Origin1;
        public Vector3 Origin2;

        Marquee marquee;
        Collector collector;

        public int round = 0;

        // Start is called before the first frame update
        void Start()
        {
            // setup the game array
            shapes_array = new GameObject[3];
            shapes_array[0] = shape1;
            shapes_array[1] = shape2;
            shapes_array[2] = shape3;

            // create a known origins array for each shape
            Origin0 = shapes_array[0].GetComponent<Transform>().position;
            Origin1 = shapes_array[1].GetComponent<Transform>().position;
            Origin2 = shapes_array[2].GetComponent<Transform>().position;
            origins_array[0] = Origin0;
            origins_array[1] = Origin1;
            origins_array[2] = Origin2;

            // Locate the "Trigger Plane" game object
            GameObject plane = GameObject.Find("Plane");

            // Attach the Collector component to the trigger plane
            plane.AddComponent<Collector>();

            // connect the GameManager script to the collector component on the trigger plane
            collector = plane.GetComponent<Collector>();

            // attach a marquee to the trigger plane to receive broadcast
            plane.AddComponent<Marquee>();

            //connect the GameManager script to the marquee component on the trigger plane
            marquee = plane.GetComponent<Marquee>();
    
            // load the first shape into the marquee
            this.SetMarqueeObjectName(round);

        }

        public void SetMarqueeObjectName(int round)
        {
            if (round < this.shapes_array.Length)
            {
                marquee.object_name = shapes_array[round].name;

                marquee.WriteToObject(marquee.object_name);
                this.SetCollectorObjectName(marquee);
            }

            else
            {
                this.GameOver();
            }

        }

        public void SetCollectorObjectName(Marquee marquee)
        {
            collector.objectName = marquee.object_name;
        }

        public void GameOver()
        {
            marquee.WriteToObject("");
            marquee.WriteToResponse("Game Over");            
        }

    }
}
