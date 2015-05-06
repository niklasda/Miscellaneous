using System;
using System.Runtime.Serialization;

namespace Dahlex.Logic.Settings
{
	[DataContract]
	public class GameSettings
	{
		[DataMember]
		public string PlayerName;

		[DataMember]
		public bool LessSound;

		[DataMember]
		public bool BombToHeap;

	    [DataMember] 
        public bool UseSwipesToMove;

        /// <summary>
        /// Number of squares on the board
        /// </summary>
        [IgnoreDataMember]
        public readonly IntSize BoardSize = new IntSize(16, 18); // w, h

        /// <summary>
        /// The size of the squares on the board, TODO with or without margin ??? 
        /// </summary>
        [IgnoreDataMember]
        public readonly IntSize SquareSize = new IntSize(28, 28); // image size 25x25

        /// <summary>
        /// The offset to apply to get the images inside the squares 
        /// </summary>
        [IgnoreDataMember]
        public readonly IntPoint ImageOffset = new IntPoint(11, 13); // w, h

        /// <summary>
        /// The distance between squares 
        /// </summary>
        [IgnoreDataMember]
        public readonly IntPoint LineWidth = new IntPoint(1, 1);
    }
}