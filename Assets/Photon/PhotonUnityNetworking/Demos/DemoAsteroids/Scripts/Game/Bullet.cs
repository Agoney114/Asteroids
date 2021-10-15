using Photon.Realtime;
using UnityEngine;
using Photon.Pun.UtilityScripts;

namespace Photon.Pun.Demo.Asteroids
{
    public class Bullet : MonoBehaviour
    {
        public Player Owner { get; private set; }
      
        public void Start()
        {
            Destroy(gameObject, 3.0f);
        }

        public void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }

        public void InitializeBullet(Player owner, Vector3 originalDirection, float lag)
        {
            Owner = owner;

            transform.forward = originalDirection;

            Rigidbody rigidbody = GetComponent<Rigidbody>();
            Renderer renderer = GetComponent<Renderer>();
            rigidbody.velocity = originalDirection * 200.0f;
            rigidbody.position += rigidbody.velocity * lag;
            renderer.material.color = AsteroidsGame.GetColor(Owner.GetPlayerNumber());  //Las balas de cada nave salen del mismo color de la nave
        }
    }
}