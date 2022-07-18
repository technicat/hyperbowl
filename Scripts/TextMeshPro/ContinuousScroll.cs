using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

namespace Fugu
{
    
    public class ContinuousScroll : MonoBehaviour
    {

        public float speed = 1.0f;

        private float start = -1.5f;
        public float end = 4.0f;

        private float x = 0.0f;

        private TMP_Text text;
        private RectTransform rectTransform;
        private Vector3 startPosition;


        void Awake()
        {
            text = GetComponent<TMP_Text>();
            rectTransform = GetComponent<RectTransform>();
            startPosition = rectTransform.position;
            x = start;


            //if (GetComponentInParent(typeof(Canvas)) as Canvas == null)
            //{
            //    GameObject canvas = new GameObject("Canvas", typeof(Canvas));
            //    gameObject.transform.SetParent(canvas.transform);
            //    canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

            //    // Set RectTransform Size
            //    gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 300);
            //    m_textMeshPro.fontSize = 48;
            //}


        }


   /*     IEnumerator Start()
        {

            // Force and update of the mesh to get valid information.
            //textMeshPro.ForceMeshUpdate();


            int totalVisibleCharacters = m_textMeshPro.textInfo.characterCount; // Get # of Visible Character in text object
            int counter = 0;
            int visibleCount = 0;

            while (true)
            {
                visibleCount = counter % (totalVisibleCharacters + 1);

                textMeshPro.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?

                // Once the last character has been revealed, wait 1.0 second and start over.
                if (visibleCount >= totalVisibleCharacters)
                {
                    yield return new WaitForSeconds(1.0f);
                }

                counter += 1;

                yield return new WaitForSeconds(0.05f);
            }

            //Debug.Log("Done revealing the text.");
        } */

        

        void Update() {
            x += speed*Time.deltaTime;
            rectTransform.position = new Vector3(startPosition.x+x, startPosition.y, startPosition.z);
            if (x>end) {
                x = start;
            }
        }

    }
}