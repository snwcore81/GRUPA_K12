using GRUPA_K12.Classes.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GRUPA_K12.Classes
{
    public class NetworkData
    {
        public const byte EMPTY = 0;

        public readonly byte[] m_oBuffer;

        public NetworkData(int a_iBufferSize)
        {
            if (a_iBufferSize < 1)
                throw new NetworkDataBufferLessThan1();

            m_oBuffer = new byte[a_iBufferSize];

            Clear();
        }

        public void Clear()
        {
            Array.Fill<byte>(m_oBuffer, EMPTY);
        }

        public int BufferLength => m_oBuffer.Length;

        public int DataLength(bool a_bWithZero = false)
        {
            return m_oBuffer.ToList().FindIndex(x => x == EMPTY) + (a_bWithZero ? 1 : 0);
        }

        public bool HasAnyData => DataLength() > 0;

        public byte[] Buffer
        {
            get => m_oBuffer;
            set
            {
                if (value == null)
                    throw new NetworkDataBufferToSmall("BuforWejściowy", BufferLength - 1, 0);

                if (value.Length > BufferLength - 1)
                    throw new NetworkDataBufferToSmall("BuforSieciowy", BufferLength - 1, value.Length);

                Clear();

                Array.Copy(value, m_oBuffer, value.Length);
            }
        }

        public byte[] BufferWithData => Buffer.Take(DataLength()).ToArray();
    }
}
