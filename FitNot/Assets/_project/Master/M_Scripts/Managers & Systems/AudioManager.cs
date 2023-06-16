using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AyaOmar;
using System;

namespace Youssef
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private SoundScript[] musicSound, sfxSound;
        [SerializeField] public AudioSource musicSource, sfxSource;
        private void Awake()
        {
            base.RegisterSingleton();
        }
        private void Start()
        {
            PlayMusic("Background");
        }
        public void PlayMusic(string name)
        {
            SoundScript s = Array.Find(musicSound, x => x.Name == name);
            if (s == null)
            {
                Debug.LogError("sound not found");
            }
            else
            {
                musicSource.clip = s.AudioClip;
                musicSource.volume = .5f;
                musicSource.Play();
            }
        }

        public void PlaySpatialSfx(string name, Vector3 sfxPlayLocation)
        {
            sfxSource.spatialBlend = 1f;
            SoundScript s = Array.Find(sfxSound, x => x.Name == name);
            if (s == null)
            {
                Debug.LogError("sound not found");
            }
            else
            {
                sfxSource.clip = s.AudioClip;
                sfxSource.pitch = 1f;
                AudioSource.PlayClipAtPoint(sfxSource.clip, sfxPlayLocation);
            }
        }
        public void Play2DSfx(string name, float volume = 0.5f)
        {
            sfxSource.spatialBlend = 0f;
            SoundScript s = Array.Find(sfxSound, x => x.Name == name);
            if (s == null)
            {
                Debug.LogError("sound not found");
            }
            else
            {
                sfxSource.clip = s.AudioClip;
                sfxSource.pitch = 1f;
                sfxSource.PlayOneShot(sfxSource.clip, volume);
            }
        }
        public void PlaySpatialPingPongSfx(string name, Vector3 sfxPlayLocation)
        {
            sfxSource.spatialBlend = 1f;
            SoundScript s = Array.Find(sfxSound, x => x.Name == name);
            if (s == null)
            {
                Debug.LogError("sound not found");
            }
            else
            {
                sfxSource.clip = s.AudioClip;
                sfxSource.pitch = UnityEngine.Random.Range(0.5f, 6f);

                AudioSource.PlayClipAtPoint(sfxSource.clip, sfxPlayLocation);
            }
        }
        public void Play2DPingPongSfx(string name, float volume = 0.5f)
        {
            sfxSource.spatialBlend = 1f;
            SoundScript s = Array.Find(sfxSound, x => x.Name == name);
            if (s == null)
            {
                Debug.LogError("sound not found");
            }
            else
            {
                sfxSource.clip = s.AudioClip;
                sfxSource.pitch = UnityEngine.Random.Range(0.5f, 2f);
                sfxSource.PlayOneShot(sfxSource.clip, volume);
            }
        }
    }
}
