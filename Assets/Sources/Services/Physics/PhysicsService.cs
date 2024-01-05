using UnityEngine;

namespace LamaGamma.Services
{
    public class PhysicsService
    {
        private readonly Camera _camera;

        public PhysicsService(Camera camera)
        {
            _camera = camera;
        }

        public bool RaycastFromCamera(float distance, int layerMask, out RaycastHit hit)
        {
            var ray = new Ray(_camera.transform.position, _camera.transform.forward);
            bool raycast = Physics.Raycast(ray, out hit, distance, layerMask);

            Debug.DrawLine(_camera.transform.position, hit.point, Color.blue);
            
            return raycast;
        }

        public bool RaycastFromCamera(RaycastSettings raycastSettings, out RaycastHit hit)
        {
            return RaycastFromCamera(raycastSettings.Distance, raycastSettings.LayerMask, out hit);
        }
    }
}
