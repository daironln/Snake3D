using System;
using System.Collections.Generic;
using MyUtils.Observer;
using UnityEngine;

namespace Game
{
    public class Snake : MonoBehaviour
    {
        #region VARIABLES
        
        [Header("Configurations")]
        public float speed = 5f;
        public float turnSpeed = 180;
        private const float BodySpeed = 5;
        [SerializeField] private int Gap = 10;
        public GameObject body;
        [Space, Header("Game Logic Variables")]
        public List<GameObject> bodyParts = new List<GameObject>();
        public List<Vector3> hPos = new List<Vector3>();

        public Observer<int> Score = new Observer<int>(0);
        #endregion
        
        
        #region MOTHODS

        private void Start()
        {
            Score.Invoke();
        }

        private void Update()
        {
            if (GameManager.Instance.gameState == GameState.InGame)
            {
                SnakeLogic();
            }
        }

        private void SnakeLogic()
        {
            transform.position += transform.forward * (speed * Time.deltaTime);

            var steerDir = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * (steerDir * turnSpeed * Time.deltaTime));

            hPos.Insert(0, transform.position);
            var index = 0;
            foreach(var body in bodyParts){
                var point = hPos[Mathf.Min(index * Gap, hPos.Count - 1)];
                var position = body.transform.position;
                var movd = point - position;
                position += movd * (BodySpeed * Time.deltaTime);
                body.transform.position = position;
                body.transform.LookAt(point);
                index ++;
            }
        }
        public void GrowSnake(){
            var bodyInstance = Instantiate(this.body, bodyParts[^1].transform.position, Quaternion.identity);
            bodyParts.Add(bodyInstance);
        }
        #endregion
    }
}
