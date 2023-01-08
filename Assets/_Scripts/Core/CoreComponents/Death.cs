using UnityEngine;

namespace Timekeeper.CoreSystem
{
    public class Death : CoreComponent
    {
        [SerializeField] private GameObject[] deathParticles;


        private ParticleManager ParticleManager =>
            particleManager ? particleManager : core.GetCoreComponent(ref particleManager);
    
        private ParticleManager particleManager;

        private Stats Stats => _stats ? _stats : core.GetCoreComponent(ref _stats);
        private Stats _stats;
    
        //死亡逻辑
        public void Die()
        {
            //死亡特效
            foreach (var particle in deathParticles)
            {
                ParticleManager.StartParticles(particle);
            }
            //隐藏死亡单位
            core.transform.parent.gameObject.SetActive(false);

            //玩家重生
            if (core.transform.parent.tag == "Player")
            {
                GameManager.Instance.isDeath = true;
                GameManager.Instance.DeathUI.SetBool("death",GameManager.Instance.isDeath);
                GameManager.Instance.Respawn();
            }
        }

        private void OnEnable()
        {
            Stats.OnHealthZero += Die;
        }

        private void OnDisable()
        {
            Stats.OnHealthZero -= Die;
        }
    }
}