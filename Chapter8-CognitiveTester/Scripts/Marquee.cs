using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Scene3 
{
    public class Marquee : MonoBehaviour
    {
        public string object_name;
        public bool isCorrect;

        GameManager gameManager;
        Collector collector;

        TextMeshProUGUI textMesh_go;
        TextMeshProUGUI textMesh_response;

        private void Awake()
        {
            TextMeshProUGUI[] textMeshes = FindObjectsOfType<TextMeshProUGUI>();
            foreach(TextMeshProUGUI textMesh in textMeshes)
            {
                if(textMesh.name == "Text_go")
                {
                    textMesh_go = textMesh;
                }
                else
                {
                    textMesh_response = textMesh;
                    textMesh_response.text = null;
                }
            }

            gameManager = FindObjectOfType<GameManager>();
            collector = FindObjectOfType<Collector>();

        }

        public void WriteToObject(string word)
        {
            textMesh_go.SetText(word);
        }

        public void WriteToResponse(string word)
        {
            textMesh_response.SetText(word);
        }

        public void SetCorrect(bool value)
        {
            isCorrect = value;

            if (isCorrect == true)
            {
                Debug.Log(true);
                textMesh_response.SetText("Correct!");
                gameManager.round++;
                if (gameManager.round < gameManager.shapes_array.Length)
                {
                    this.object_name = gameManager.shapes_array[gameManager.round].name;
                    collector.collected_ObjectName = null;
                    gameManager.SetMarqueeObjectName(gameManager.round);                    
                }
                else
                {
                    gameManager.GameOver();
                }                              
            }

            else if (isCorrect == false)
            {
                Debug.Log(false);
                textMesh_response.text = "Wrong!";

                for (int i = 0; i < gameManager.shapes_array.Length; i++)
                {
                    if(collector.collected_ObjectName == gameManager.shapes_array[i].name)
                    {
                        Instantiate(gameManager.shapes_array[i], gameManager.origins_array[i], Quaternion.identity);
                    }
                }

                gameManager.SetMarqueeObjectName(gameManager.round);
            }
        }
    }
}
