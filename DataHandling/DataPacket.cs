/// <summary>
/// Defines the class "DataPacket" which represents the data packet sent
/// from server to client or the other way.
/// </summary>

using System.Text.Json.Serialization;

namespace ScreenShare.DataHandling
{
    /// <summary>
    /// Represents the data packet sent from server to client or the other way.
    /// </summary>
    public class DataPacket
    {
        /// <summary>
        /// Creates an instance of the DataPacket with empty string values for all the fields.
        /// </summary>
        public DataPacket()
        {
            Id = "";
            Name = "";
            Header = "";

        }

        /// <summary>
        // create instance with given values
        /// </param>
        [JsonConstructor]
        public DataPacket(string id, string name, string header, bool isChange, bool isFull, bool isStarted,
                          ref List<PixelDifference> changedPixels, ref byte[] image)
        {
            Id = id;
            Name = name;
            Header = header;
            IsChange = isChange;
            IsFull = isFull;
            IsStarted = isStarted;
            ChangedPixels = changedPixels;
            Image = image;

        }

        /// <summary>
        /// Gets the id field of the packet.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the name field of the packet.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the header field of the packet.
        /// Possible headers from the server: Send, Stop
        /// Possible headers from the client: Register, Deregister, Image, Confirmation
        /// </summary>
        public string Header { get; private set; }

        /// <summary>
        /// Gets the data field of the packet.
        /// Data corresponding to various headers:
        /// Server:
        ///     - Send: Serialized tuple representing the resolution of the image to send
        ///     - Stop: Empty
        /// Client:
        ///     - Register    : Empty
        ///     - Deregister  : Empty
        ///     - Image       : Serialized "Frame" representing the image
        ///     - Confirmation: Empty
        /// </summary>

        public bool IsChange { get; set; }

        /// <summary>
        /// 1 bit value to check sending full image or only changed pixels
        /// </summary>
        public bool IsFull { get; set; }

        /// <summary>
        /// 1 bit value to notfify others when screen share started by someone
        /// </summary>
        public bool IsStarted { get; set; }

        /// <summary>
        /// List of changes pixels(empty when we send full images)
        /// </summary>
        public List<PixelDifference> ChangedPixels { get; set; }

        /// <summary>
        /// image as byte array
        /// </summary>
        public byte[] Image { get; set; }
    }

    public class PixelDifference
    {
        /// <summary>
        /// X coordinate of pixel
        /// </summary>
        public ushort X { get; }

        /// <summary>
        /// Y coordinate of pixel
        /// </summary>
        public ushort Y { get; }

        /// <summary>
        /// ARGB values of fixel
        /// </summary>
        public byte Alpha { get; }
        public byte Red { get; }
        public byte Green { get; }
        public byte Blue { get; }


        /// <summary>
        /// constructor to set valuses
        /// </summary>
        public PixelDifference(ushort x, ushort y, byte alpha, byte red, byte green, byte blue)
        {
            X = x;
            Y = y;
            Red = red;
            Blue = blue;
            Green = green;
            Alpha = alpha;
        }
    }
}