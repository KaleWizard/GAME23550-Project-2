using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class InterceptTargetTestingAT : ActionTask {

		public BBParameter<Transform> targetBBP;
		public BBParameter<AwesomeBestCharacterController> characterBBP;

		public float distance = 1;
		public float randomization = 1;

		float horizontalModifier;

        protected override string OnInit()
        {
			horizontalModifier = Random.Range(-randomization, randomization);

            return null;
        }

		protected override void OnExecute() {
			//Vector2 random = Random.insideUnitCircle.normalized * distance;
			//Vector3 forward = characterBBP.value.direction;
			//Vector3 right = new(forward.z, forward.y, -forward.x);

   //         Vector3 targetPos = characterBBP.value.transform.position 
			//	+ (distance + Random.Range(randomization / 2, randomization * 1.5f)) * forward 
			//	+ new Vector3(random.x, 0, random.y)
			//	+ horizontalModifier * characterBBP.value.transform.right;
			//targetBBP.value.position = targetPos;
			EndAction(true);
		}
	}
}