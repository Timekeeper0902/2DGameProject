using Timekeeper._Panel.UpGrate;
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

            if (core.transform.parent.tag == "Enemy")
            {
                UpgradeAndItems.Instance.AddExperience(10);
            }

            //玩家重生
            if (core.transform.parent.tag == "Player")
            {
                ReSpawnManager.Instance.isDeath = true;
                ReSpawnManager.Instance.DeathUI.SetBool("death",ReSpawnManager.Instance.isDeath);
                ReSpawnManager.Instance.Respawn();
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