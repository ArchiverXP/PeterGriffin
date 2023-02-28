using PeterGriffin.NightUtils;
using System;
using UnityEngine;


namespace PeterGriffin.Peters
{
    public class LoisGriffin : MonoBehaviour
    {
        public Sprite spite;
        public Texture2D wario;
        public GameObject peta;
        public RectTransform griffin;
        Player player;

        public void OnEnable()
        {

            peta = new GameObject("peter griffin");

            var peter_griffin = GameObject.Find("Player/Pivot");

            var super_mario = GameObject.Find("MaeRig");

            //WORKAROUND:
            super_mario.transform.SetPositionX(999);
            super_mario.transform.SetPositionY(999);

            peta.transform.parent = peter_griffin.transform;

            var brian_griffin = peta.AddComponent<SpriteRenderer>();

            //var lois_griffin = GameObject.Find("SpriteAnimator");

            wario = ResourceLoader.Irios("PeterGriffin.sprites.peter.png");
            RectTransform retweet = peta.GetComponent<RectTransform>();
            var griffin2 = peta.AddComponent<RectTransform>();
            griffin2.anchoredPosition = Vector2.zero;
            griffin2.sizeDelta = new Vector3(wario.width, wario.height);
            spite = Sprite.Create(wario, new Rect(0.0f, 0.0f, wario.width, wario.height), new Vector2(0.5f, 0.2f), 100.0f);

            brian_griffin.sprite = spite;

            brian_griffin.sortingLayerID = 0;

            Destroy(peta, 0.2f); //hack

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                brian_griffin.flipX = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                brian_griffin.flipX = false;
            }


            
            
        }
        public void OnDestroy()
        {

        }
    }
}
