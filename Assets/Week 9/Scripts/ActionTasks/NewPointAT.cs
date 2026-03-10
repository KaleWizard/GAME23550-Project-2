using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class NewPointAT : ActionTask {

		public BBParameter<List<Transform>> pointListBBP;
		public BBParameter<int> indexBBP;

		public BBParameter<Transform> targetBBP;

		protected override void OnExecute() {
			indexBBP.value++;
			if (indexBBP.value >= pointListBBP.value.Count)
			{
				indexBBP.value = 0;
			}

			targetBBP.value = pointListBBP.value[indexBBP.value];

			EndAction(true);
		}
	}
}