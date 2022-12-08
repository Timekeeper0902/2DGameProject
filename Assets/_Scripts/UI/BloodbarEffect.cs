using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Timekeeper
{
    public class BloodbarEffect : MonoBehaviour
    {
        public Image unMaskImage;
        public Image maskedImage;
        public Animator anim;
        
        public void IniBloodBarEffect(float cur,float pre)
        {
            unMaskImage.fillAmount = cur;
            maskedImage.fillAmount = pre;
            anim.SetBool("show",true);
            StartCoroutine(DoMoveEffect());
        }

        IEnumerator DoMoveEffect()
        {
            //下落速度
            float a = 400;
            yield return new WaitForSeconds(0.1f);
            while (true)
            {
                //控制时间
                a -= 20;
                MoveEffect(a);
                yield return new WaitForFixedUpdate();
            }
        }

        private void MoveEffect(float a)
        {
            transform.position += (Vector3.up * a * Time.deltaTime);
        }

        public void Destroy()
        {
            Destroy(this.gameObject);
        }
    }
}
