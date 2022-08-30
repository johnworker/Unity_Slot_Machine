using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace slot {
    public class GameControl : MonoBehaviour
    {
        public static event Action HandlePulled = delegate { };

        [SerializeField]
        private Row[] rows;

        [SerializeField]
        private Transform handle;

        private bool resultsChecked;

        void Start()
        {

        }

        void Update()
        {
            if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
            {
                resultsChecked = false;
            }
        }

        private void OnMouseDown()
        {
            if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
                CheckResults();
                StartCoroutine("PullHandle");
        }

        private IEnumerator PullHandle()
        {
            for (int i = 0; i < 18; i += 5)
            {
                handle.Rotate(0f, 0f, i);
                yield return new WaitForSeconds(0.1f);
            }

            HandlePulled();

            for (int i = 0; i < 18; i += 5)
            {
                handle.Rotate(0f, 0f, -i);
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void CheckResults()
        {
            if(rows[0].stoppedSlot == "Diamond" && rows[1].stoppedSlot == "Diamond" && rows[2].stoppedSlot == "Diamond")
            {

            }

            else if (rows[0].stoppedSlot == "Crown" && rows[1].stoppedSlot == "Crown" && rows[2].stoppedSlot == "Crown")

            resultsChecked = true;
        }

    }

}
