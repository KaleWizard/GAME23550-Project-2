using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class HurdleCloseCT : ConditionTask {

		public LayerMask hurdleMask;
        public BBParameter<float> checkDistanceBBP;
		protected override bool OnCheck() {
			// Raycast forward for nearby hurdles
			var ray = new Ray(agent.transform.position + 0.5f * Vector3.up, agent.transform.forward);
            return Physics.Raycast(ray, checkDistanceBBP.value);
        }
	}
}