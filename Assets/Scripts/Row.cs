using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace slot
{
    public class Row : MonoBehaviour
    {
        private int randomValue;
        private float timeInterval;

        public bool rowStopped;
        public string stoppedSlot;
        void Start()
        {
            rowStopped = true;
            GameControl.HandlePulled += startRotating;
        }

        private void startRotating()
        {
            stoppedSlot = "";
            StartCoroutine("Rotate");
        }

        // 協同程序控制旋轉
        private IEnumerator Rotate()
        {
            rowStopped = false;
            timeInterval = 0.05f;

            for (int i = 0; i < 30; i++)
            {
                if (transform.position.y <= -3.5f)
                    transform.position = new Vector2(transform.position.x, 1.425f);

                transform.position = new Vector2(transform.position.x, transform.position.y + 2.85f);
                yield return new WaitForSeconds(timeInterval);
            }

            randomValue = Random.Range(0, 100);
            switch (randomValue % 3)
            {
                case 1:
                    randomValue += 2;
                    break;
                case 2:
                    randomValue += 1;
                    break;
            }

            for (int i = 0; i < randomValue; i++)
            {
                if (transform.position.y <= 5.55f)
                    transform.position = new Vector2(transform.position.x, 2.15f);
                transform.position = new Vector2(transform.position.x, transform.position.y + 2.85f);

                if (i > Mathf.RoundToInt(randomValue * 0.25f))
                    timeInterval = 0.05f;
                if (i > Mathf.RoundToInt(randomValue * 0.5f))
                    timeInterval = 0.1f;
                if (i > Mathf.RoundToInt(randomValue * 0.75f))
                    timeInterval = 0.15f;
                if (i > Mathf.RoundToInt(randomValue * 0.95f))
                    timeInterval = 0.2f;

                yield return new WaitForSeconds(timeInterval);
            }

            if (transform.position.y == 5.55f)
                stoppedSlot = "A";
            else if (transform.position.y == 8.4f)
                stoppedSlot = "B";
            else if (transform.position.y == 11.25f)
                stoppedSlot = "C";
            else if (transform.position.y == 14.1f)
                stoppedSlot = "D";
            else if (transform.position.y == 16.95f)
                stoppedSlot = "E";
            else if (transform.position.y == 19.8f)
                stoppedSlot = "F";
            else if (transform.position.y == 22.65f)
                stoppedSlot = "G";
            else if (transform.position.y == 25.5f)
                stoppedSlot = "H";
            else if (transform.position.y == 28.35f)
                stoppedSlot = "I";
            else if (transform.position.y == 31.2f)
                stoppedSlot = "J";
            else if (transform.position.y == 34.05f)
                stoppedSlot = "K";
            else if (transform.position.y == 36.9f)
                stoppedSlot = "L";
            else if (transform.position.y == 39.75f)
                stoppedSlot = "M";
            else if (transform.position.y == 42.6f)
                stoppedSlot = "N";
            else if (transform.position.y == 45.45f)
                stoppedSlot = "O";
            else if (transform.position.y == 48.3f)
                stoppedSlot = "P";
            else if (transform.position.y == 51.15f)
                stoppedSlot = "Q";
            else if (transform.position.y == 54f)
                stoppedSlot = "R";


            rowStopped = true;
        }

        private void OnDestroy()
        {
            GameControl.HandlePulled -= startRotating;
        }

    }

}
