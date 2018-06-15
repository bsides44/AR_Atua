namespace Mapbox.Examples
{
	using UnityEngine;
	using UnityARInterface;

	public class UpdateMapPosByARPlaneY : MonoBehaviour
	{
		[SerializeField]
		Transform _mapRoot;

		void Start()
		{
			ARInterface.planeAdded += UpdateMapPosOnY;
			ARInterface.planeUpdated += UpdateMapPosOnY;
		}

		void UpdateMapPosOnY(BoundedPlane plane)
		{
			var pos = _mapRoot.position;
			// _mapRoot.position = new Vector3(pos.x, pos.y, pos.z);
			_mapRoot.position = new Vector3(pos.x, plane.min.y, pos.z);
		}
	}
}
