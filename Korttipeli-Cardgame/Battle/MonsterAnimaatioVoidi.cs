using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO {
    public class MonsterAnimaatioVoidi : MonoBehaviour {

        public int PlayerID;
        Animator anim;

        public GameObject GronttoParticleEffect;

        void Start()
        {
            anim = gameObject.GetComponent<Animator>();
        }

        private void Update()
        {
            if (Settings.peliSäätäjä.all_players[PlayerID].MonsterHealth == 0)
                anim.SetBool("Death", true);

            if (Settings.peliSäätäjä.all_players[PlayerID].TakingDamage == true)
                anim.SetBool("Hurt", true);
    }

        public void DisableAttackAnim()
        {
            anim.SetBool("Attack1", false);
            anim.SetBool("Attack2", false);
            anim.SetBool("Attack3", false);
            anim.SetBool("Attack4", false);
            Settings.peliSäätäjä.EndCurrentPhase();
        }

        public void NotTakingDamage()
        {
            Settings.peliSäätäjä.all_players[PlayerID].TakingDamage = false;
            anim.SetBool("Hurt", false);
        }

        public void GronttoEnableEffect()
        {
            GronttoParticleEffect.SetActive(true);
        }

        public void GronttoDisableEffect()
        {
            GronttoParticleEffect.SetActive(false);
        }
    }
}