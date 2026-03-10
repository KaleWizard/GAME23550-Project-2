using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions 
{
	public class ColourChangeAT : ActionTask 
	{
		public BBParameter<Renderer> rendererBBP;
		public Color color = Color.white;

		protected override void OnExecute() 
		{
			rendererBBP.value.material.color = color;
			EndAction(true);
		}
	}
}