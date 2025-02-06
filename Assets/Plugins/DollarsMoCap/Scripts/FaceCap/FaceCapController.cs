using System.Collections.Generic;
using UnityEngine;

namespace Dollars
{
    public class FaceCapController : MonoBehaviour
    {
        public GameObject src;
        [SerializeField]
        SkinnedMeshRenderer[] m_SkinnedMeshRenderers = { };
        [SerializeField]
        BlendShapeMappings[] m_Mappings = { };

        Dictionary<int, BlendShapeMappingIndex> mappingindex = new Dictionary<int, BlendShapeMappingIndex>();
        float[] blendShapesScaled;
        FaceCapResult fcr;

        void Start()
        {
            fcr = src.GetComponent<FaceCapResult>();
            int blendShapesCount = LiveLinkTrackingData.Names.Length;
            blendShapesScaled = new float[blendShapesCount];
            UpdateBlendShapeIndices();
        }

        void Update()
        {
            InterpolateBlendShapes();
            for (var i = 0; i < m_SkinnedMeshRenderers.Length; i++)
            {
                var mi = mappingindex[i];
                for (var j = 0; j < LiveLinkTrackingData.Names.Length; j++)
                {
                    if (mi.morphs[LiveLinkTrackingData.Names[j]] != -1)
                    {
                        m_SkinnedMeshRenderers[i].SetBlendShapeWeight(mi.morphs[LiveLinkTrackingData.Names[j]], blendShapesScaled[j]);
                    }
                }
            }
        }

        void UpdateBlendShapeIndices()
        {
            int index = 0;
            for (var i = 0; i < m_SkinnedMeshRenderers.Length; i++)

            //foreach (var meshRenderer in m_SkinnedMeshRenderers)
            {
                var mesh = m_SkinnedMeshRenderers[i].sharedMesh;
                BlendShapeMappingIndex indices = new BlendShapeMappingIndex();
                foreach (var mapping in m_Mappings[index].mappings)
                {
                    indices.morphs.Add(mapping.from, mesh.GetBlendShapeIndex(mapping.to));
                }
                mappingindex.Add(i, indices);
                index++;
            }
        }

        void InterpolateBlendShapes(bool force = false)
        {
            for (var i = 0; i < LiveLinkTrackingData.Names.Length; i++)
            {
                blendShapesScaled[i] = fcr.values[LiveLinkTrackingData.Names[i]] * 100;
            }
        }

        void OnValidate()
        {
            if (m_SkinnedMeshRenderers.Length != m_Mappings.Length)
                return;
        }
    }
}
