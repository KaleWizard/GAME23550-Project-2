using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class MoveToTargetAT : ActionTask {

		public BBParameter<Transform> moveTargetBBP;

		Vector3 direction;

        protected override string OnInit()
        {
			direction = (moveTargetBBP.value.position - agent.transform.position).normalized;


            return null;
        }

		protected override void OnUpdate() {

			agent.transform.position += direction * Time.deltaTime;

			Vector3 diff = moveTargetBBP.value.position - agent.transform.position;

			if (Vector3.Dot(diff, direction) < 0)
			{
				EndAction(true);
			}

		}
	}
}