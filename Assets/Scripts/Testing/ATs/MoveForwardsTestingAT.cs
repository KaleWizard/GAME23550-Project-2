using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class MoveForwardsTestingAT : ActionTask {

		public BBParameter<float> speedBBP;

		protected override void OnUpdate() {
			agent.transform.position += speedBBP.value * Time.deltaTime * agent.transform.forward;
		}
	}
}