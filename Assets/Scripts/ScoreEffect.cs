    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ScoreEffect : MonoBehaviour
    {
        private Color currentColor;
        public void Init(Color col)
        {
            currentColor = col;
            StartCoroutine(Effect());
        }
        [SerializeField] private float _animationTime;
        private IEnumerator Effect()
        {
            float timeElapsed = 0f;
            float speed = 1 / _animationTime;

            Vector3 startScale = Vector3.one * 0.64f;
            Vector3 endScale = Vector3.one * 1.28f;
            Vector3 scaleOffset = endScale - startScale;
            Vector3 currentScale = startScale;
            transform.localScale = currentScale;

            Color startColor = currentColor;
            startColor.a = 0.8f;
            Color endColor = currentColor;
            startColor.a = 0.2f;
            Color colorOffset = endColor - startColor;

            Color c = startColor;
            SpriteRenderer SR = GetComponent<SpriteRenderer>();
            SR.color = c;

            while(timeElapsed < 1f)
            {
                timeElapsed += speed * Time.deltaTime;

                currentScale = startScale + timeElapsed * scaleOffset;
                transform.localScale = currentScale;

                c = startColor + timeElapsed * colorOffset;
                SR.color = c;

                yield return null;
            }

            yield return null;
            Destroy(gameObject);
        }
    }
