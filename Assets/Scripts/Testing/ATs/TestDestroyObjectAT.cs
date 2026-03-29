using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Services;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class TestDestroyObjectAT : ActionTask {

		public BBParameter<GameObject> gameObjectBBP;

		protected override void OnExecute() {
			if (gameObjectBBP.value != null)
				MonoManager.Destroy(gameObjectBBP.value);
			gameObjectBBP.value = null;
			EndAction(true);
		}
	}
}