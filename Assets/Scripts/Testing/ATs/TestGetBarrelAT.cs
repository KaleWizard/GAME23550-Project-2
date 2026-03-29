using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class TestGetBarrelAT : ActionTask {

		public BBParameter<GameObject> barrelBBP;

		protected override void OnExecute() {
			barrelBBP.value = TestingBarrelManager.Instance.GetBarrel(agent.transform.position);
			EndAction(barrelBBP.value != null);
		}
	}
}