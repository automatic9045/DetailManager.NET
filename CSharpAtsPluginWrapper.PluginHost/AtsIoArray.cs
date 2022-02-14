using System;

namespace Automatic9045.CSharpAtsPluginWrapper.PluginHost
{
    /// <summary>
    /// Unmanaged array operations for Panel / Sound.
    /// </summary>
    public class AtsIoArray
    {
        /// <summary>
        /// Address of unmanaged array.
        /// </summary>
        private IntPtr Address { get; set; } = IntPtr.Zero;

        /// <summary>
        /// Array length of unmanaged array.
        /// </summary>
        public int Length { get; private set; } = -1;

        /// <summary>
        /// Gets an element from unmanaged array by index.
        /// </summary>
        /// <param name="index">The array index that indicates position of element in unmanaged array.</param>
        /// <returns>Element of unmanaged array.</returns>
        public unsafe int this[int index]
        {
            get
            {
                if ((index >= Length) || (index < 0))
                {
                    throw new IndexOutOfRangeException("Unmanaged array index is out of range: " + AppDomain.CurrentDomain.BaseDirectory);
                }

                var pointer = (int*)Address.ToPointer();
                return pointer[index];      // Get an element.
            }
            set
            {
                if ((index >= Length) || (index < 0))
                {
                    throw new IndexOutOfRangeException("Unmanaged array index is out of range: " + AppDomain.CurrentDomain.BaseDirectory);
                }

                var pointer = (int*)Address.ToPointer();
                pointer[index] = value;     // Set an element.
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public AtsIoArray()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="source">Pointer of unmanaged array.</param>
        /// <param name="length">Array length of unmanaged array.</param>
        public AtsIoArray(IntPtr source, int length = 256)
        {
            SetSource(source, length);
        }

        /// <summary>
        /// Sets an unmanaged array.
        /// </summary>
        /// <param name="source">Pointer of unmanaged array.</param>
        /// <param name="length">Array length of unmanaged array.</param>
        public void SetSource(IntPtr source, int length = 256)
        {
            Address = source;
            Length = length;
        }
    }
}