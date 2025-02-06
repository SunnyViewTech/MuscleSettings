using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dollars
{
    [Serializable]
    [CreateAssetMenu(fileName = "BlendShapeMappings", menuName = "Dollars/Face Capture Mappings")]
    public class BlendShapeMappings : ScriptableObject
    {
        [SerializeField]
        Mapping[] m_Mappings = { };

        public Mapping[] mappings { get { return m_Mappings; } }

        BlendShapeMappings()
        {
            m_Mappings = new Mapping[LiveLinkTrackingData.Names.Length];

            for (int i = 0; i < LiveLinkTrackingData.Names.Length; i++)
            {
                m_Mappings[i].from = LiveLinkTrackingData.Names[i];
                m_Mappings[i].to = LiveLinkTrackingData.Names[i];
            }
        }
    }
}
