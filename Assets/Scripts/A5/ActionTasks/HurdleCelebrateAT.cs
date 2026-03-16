using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class HurdleCelebrateAT : ActionTask {

		public float minTime;
		public float maxTime;
        public BBParameter<float> jumpVelocityBBP;

        Rigidbody rb;

		float timer = 0;
		float currentTime;

        protected override string OnInit()
        {
            rb = agent.GetComponent<Rigidbody>();
            if (rb == null)
                return $"{agent.name} needs a RigidBody component!";

            return null;
        }

        protected override void OnExecute()
        {
			currentTime = Random.Range(minTime, maxTime);
        }

		protected override void OnUpdate() {
			// Slow down and stop if very slow
			rb.linearVelocity *= Mathf.Pow(0.5f, Time.deltaTime);
			if (rb.linearVelocity.sqrMagnitude < 0.01f)
				rb.linearVelocity = Vector3.zero;

			// Make little jumps at random intervals
			timer += Time.deltaTime;
			if (timer > currentTime)
			{
                Vector3 direction = agent.transform.up.normalized;
                rb.linearVelocity += jumpVelocityBBP.value * direction;

                currentTime = Random.Range(minTime, maxTime);
				timer = 0;
            }
		}
	}
}