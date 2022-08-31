using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

namespace slot {
    public class GameControl : MonoBehaviour
    {
        public static event Action HandlePulled = delegate { };
        [SerializeField]
        private TextMeshProUGUI prizeText;

        [SerializeField]
        private Row[] rows;

        [SerializeField]
        private Transform handle;

        private int prizeValue;

        private bool resultsChecked;

        void Update()
        {
            if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped || !rows[3].rowStopped || !rows[4].rowStopped)
            {
                prizeValue = 0;
                prizeText.enabled = true;
                resultsChecked = false;
            }

            if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && rows[3].rowStopped && rows[4].rowStopped && !resultsChecked)
            {
                CheckResults();
                prizeText.enabled = true;
                prizeText.text = "Prize:" + prizeValue;
            }
        }

        private void OnMouseDown()
        {
            if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && rows[3].rowStopped && rows[4].rowStopped)
                StartCoroutine("PullHandle");
        }

        private IEnumerator PullHandle()
        {
            for (int i = 0; i < 15; i += 5)
            {
                handle.Rotate(0f, 0f, i);
                yield return new WaitForSeconds(0.1f);
            }

            HandlePulled();

            for (int i = 0; i < 15; i += 5)
            {
                handle.Rotate(0f, 0f, -i);
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void CheckResults()
        {
            if(rows[0].stoppedSlot == "A" && rows[1].stoppedSlot == "A" && rows[2].stoppedSlot == "A" && rows[3].stoppedSlot == "A" && rows[4].stoppedSlot == "A")
            {
                prizeValue = 200;
            }

            else if (rows[0].stoppedSlot == "B" && rows[1].stoppedSlot == "B" && rows[2].stoppedSlot == "B" && rows[3].stoppedSlot == "B" && rows[4].stoppedSlot == "B")
            {
                prizeValue = 400;
            }

            else if (rows[0].stoppedSlot == "C" && rows[1].stoppedSlot == "C" && rows[2].stoppedSlot == "C" && rows[3].stoppedSlot == "C" && rows[4].stoppedSlot == "C")
            {
                prizeValue = 600;
            }

            else if (rows[0].stoppedSlot == "D" && rows[1].stoppedSlot == "D" && rows[2].stoppedSlot == "D" && rows[3].stoppedSlot == "D" && rows[4].stoppedSlot == "D")
            {
                prizeValue = 800;
            }

            else if (rows[0].stoppedSlot == "E" && rows[1].stoppedSlot == "E" && rows[2].stoppedSlot == "E" && rows[3].stoppedSlot == "E" && rows[4].stoppedSlot == "E")
            {
                prizeValue = 1000;
            }



            resultsChecked = true;
        }


        public void OnEnable()
        {
            enabled = true;
        }
    }

}
