using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class HurdleRunAT : ActionTask {

        public BBParameter<float> speedBBP;
		Rigidbody rb;

		protected override string OnInit() {
			rb = agent.GetComponent<Rigidbody>();
			if (rb == null)
				return $"{agent.name} needs a RigidBody component!";

			return null;
		}

		protected override void OnUpdate() {
			// Get direction and next velocity
			Vector3 direction = agent.transform.forward.normalized;
			direction = rb.linearVelocity + speedBBP.value * Time.deltaTime * direction;

			float yVal = direction.y;
			direction.y = 0;

			// Attempt to clamp horizontal velocity
			if (direction.magnitude > speedBBP.value)
				direction = direction.normalized * speedBBP.value;

			// Set velocity
			direction.y = yVal;
			rb.linearVelocity = direction;
		}
	}
}