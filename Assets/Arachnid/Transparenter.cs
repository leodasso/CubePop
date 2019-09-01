using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Arachnid
{

    /// <summary>
    /// and sets the alpha of the shader.
    /// </summary>
    public class Transparenter : SerializedMonoBehaviour
    {
        public float lifetime = 5;
        float _timer;

        [Range(0, 1), OnValueChanged("SetAlpha")]
        public float alpha;
        [Range(0, 1)]
        public float minAlpha;
        public float transitionSpeed;

        static Shader _stippleShader;
        static Shader GetStippleShader()
        {
            if (_stippleShader) return _stippleShader;
            _stippleShader = Resources.Load("stipple shader") as Shader;
            return _stippleShader;
        }

        /// <summary>
        /// The renderer, and the created material instance. 
        /// </summary>
        public Dictionary<Renderer, List<Material>> renders = new Dictionary<Renderer, List<Material>>();

        // Use this for initialization
        void Start ()
        {
            alpha = 1;
            CreateRendersDictionary();
        }

        /// <summary>
        /// Creates a dictionary of all the renderers in this object and their shared materials.
        /// </summary>
        [Button]
        void CreateRendersDictionary()
        {
            renders.Clear();

            foreach (var r in GetComponentsInChildren<Renderer>())
            {
                renders.Add(r, r.materials.ToList());
            }

            foreach (var r in GetComponentsInParent<Renderer>())
            {
                if (renders.ContainsKey(r)) continue;
                renders.Add(r, r.materials.ToList());
            }

            foreach (var matList in renders.Values)
            {
                foreach (var mat in matList)
                    mat.shader = GetStippleShader();
            }
        }


        Material rememberedMaterial;
        Color _color;

        /// <summary>
        /// Sets the alpha of all the renderers.
        /// </summary>
        void SetAlpha(float newAlpha)
        {
            foreach (var matList in renders.Values)
            {
                foreach (var mat in matList)
                {
                    _color = mat.GetColor("_Color");
                    _color = new Color(_color.r, _color.g, _color.b, alpha);
                    mat.SetColor("_Color", _color);
                }
            }
        }


        /// <summary>
        /// Adopt the stats from the given visibility helper
        /// </summary>
        public void TakeStats(VisibillityHelper caster)
        {
            lifetime = caster.transparencyLifetime;
            minAlpha = caster.minAlpha;
            transitionSpeed = caster.transitionSpeed;
        }


        public void Refresh()
        {
            _timer = 0;
        }

        // Update is called once per frame
        void Update ()
        {
            _timer += Time.deltaTime;

            float finalAlpha = minAlpha;
            if (_timer >= lifetime) finalAlpha = 1;

            if (Mathf.Abs(alpha - finalAlpha) <= Mathf.Epsilon) return;

            alpha = Mathf.Lerp(alpha, finalAlpha, Time.deltaTime * transitionSpeed);
            SetAlpha(alpha);
        }
    }
}