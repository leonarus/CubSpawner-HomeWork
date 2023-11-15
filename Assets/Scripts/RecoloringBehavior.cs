
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecoloringBehavior : MonoBehaviour
{
   [SerializeField] private float _recoloringDuration;
   [SerializeField] private float _delayAfterColorChange = 0f;
   
   private Color _startColor;
   private Color _nextColor;
   private Renderer _renderer;
   
   private float _recoloringTime;


   private void Awake()
   {
      _renderer = GetComponent<Renderer>();
      GenerateNextColor();
   }

   private void GenerateNextColor()
   {
      _startColor = _renderer.material.color;
      _nextColor = Random.ColorHSV(0f, 1f, 0.8f,1f, 1f, 1f);
   }

   private void Update()
   {
      _recoloringTime += Time.deltaTime;
      
      
      var progress = _recoloringTime / _recoloringDuration;
      var currentColor = Color.Lerp(_startColor, _nextColor, progress);
      _renderer.material.color = currentColor;

      if (_recoloringTime >= _delayAfterColorChange)
      {
         _recoloringTime = 0f;
         GenerateNextColor();
      }
   }
}
