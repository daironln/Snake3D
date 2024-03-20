using UnityEngine;

namespace Game
{
    public class PickUp : MonoBehaviour
    {
        #region VARIABLES
        public string tagp = "Player";
        [Header("Configuraciones")]
        [SerializeField] private float rotateSpeed = 2.5f;
        float angle = 0;
        [SerializeField, Tooltip("altura maxima")] private float alt_Max = 5f;
        [SerializeField] private float move_Speed = 2.5f;
        [SerializeField] private float time = 0f;
        [SerializeField] private RamdomArea ra;
        #endregion

        #region METHODS
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(tagp))
            {
                Snake snake = other.GetComponentInParent<Snake>();

                if (snake != null)
                {
                    snake.Score.Value += 1;
                    GenerateNew();
                }
            }
        }

        public void GenerateNew()
        {
            Vector2 range = Random.insideUnitSphere * ra.Radius;
            var pos = new Vector3(ra.transform.position.x + range.x, 0f, ra.transform.position.z + range.y);
            this.gameObject.SetActive(false);
            transform.position = pos;
            this.gameObject.SetActive(true);
        }

        public void RotatePickUp() {
        
            var r = Quaternion.AngleAxis(angle, Vector3.up);
            transform.rotation = r;
            angle += rotateSpeed * Time.deltaTime;

            if(angle >= 360)
            {
                angle = angle - 360;
            }
        }

        public void Mover()
        {
            time += Time.deltaTime * move_Speed  / 2;
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, 0.5f, transform.position.z), new Vector3(transform.position.x, alt_Max, transform.position.z), Mathf.PingPong(time, 1.0f));
        }

        private void Update()
        {
            RotatePickUp();
            Mover();
        }
        #endregion
    }
}