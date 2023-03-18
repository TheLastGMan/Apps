using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EDSdkWrapper.Enums
{
	[StructLayout(LayoutKind.Explicit)]
	public struct ImageQuality
	{
		[FieldOffset(0)]
		private uint RAW;
		[FieldOffset(0)]
		private byte Byte1;
		[FieldOffset(1)]
		private byte Byte2;
		[FieldOffset(2)]
		private byte Byte3;
		[FieldOffset(3)]
		private byte Byte4;

		//initilizer
		public ImageQuality(uint Raw)
		{
			Byte1 = 0;
			Byte2 = 0;
			Byte3 = 0;
			Byte4 = 0;
			RAW = Raw;
		}
		public uint Raw { get { return RAW; } }

		//Classy way
		public ImageQualityKnownFormat KnownFormat
		{
			get { return (ImageQualityKnownFormat)RAW; }
			set { RAW = (uint)value; }
		}
		
		//Byte 1
		public CompressQuality Second_CompressionQuality
		{
			get { return (CompressQuality)(Byte1 & 0x0F); }
			set { Byte1 = (byte)((Byte1 & 0xF0) + (byte)value); }
		}

		public ImageFormat Second_ImageFormat
		{
			get { return (ImageFormat)((Byte1 & 0xF0) >> 4); }
			set { Byte1 = (byte)((Byte1 & 0x0F) + ((byte)value << 4)); }
		}

		//Byte 2
		public ImageSize Second_ImageSize
		{
			get { return (ImageSize)(Byte2 & 0xF0); }
			set { Byte2 = (byte)((Byte2 & 0xF0) + (byte)value); }
		}

		//Byte 3
		public CompressQuality CompressionQuality
		{
			get { return (CompressQuality)(Byte3 & 0x0F); }
			set { Byte1 = (byte)((Byte3 & 0xF0) + (byte)value); }
		}

		public ImageFormat ImageFormat
		{
			get { return (ImageFormat)((Byte3 & 0xF0) >> 4); }
			set { Byte1 = (byte)((Byte3 & 0x0F) + ((byte)value << 4)); }
		}

		//Byte 4
		public ImageSize ImageSize
		{
			get { return (ImageSize)Byte4; }
			set { Byte2 = (byte)value; }
		}
	}

	public enum ImageQualityKnownFormat : uint
	{
		Unknown = uint.MaxValue,

		/* Jpeg Only */
		JPEG_L = 0x0010ff0f,	/* Jpeg Large */
		JPEG_M1 = 0x0510ff0f,	/* Jpeg Middle1 */
		JPEG_M2 = 0x0610ff0f,	/* Jpeg Middle2 */
		JPEG_S = 0x0210ff0f,	/* Jpeg Small */
		JPEG_LF = 0x0013ff0f,	/* Jpeg Large Fine */
		JPEN_LN = 0x0012ff0f,	/* Jpeg Large Normal */
		JPEN_MF = 0x0113ff0f,	/* Jpeg Middle Fine */
		JPEN_MN = 0x0112ff0f,	/* Jpeg Middle Normal */
		JPEN_SF = 0x0213ff0f,	/* Jpeg Small Fine */
		JPEN_SN = 0x0212ff0f,	/* Jpeg Small Normal */
		JPEN_S1F = 0x0E13ff0f,	/* Jpeg Small1 Fine */
		JPEN_S1N = 0x0E12ff0f,	/* Jpeg Small1 Normal */
		JPEN_S2F = 0x0F13ff0f,	/* Jpeg Small2 */
		JPEN_S3F = 0x1013ff0f,	/* Jpeg Small3 */

		/* RAW + Jpeg */
		LR = 0x0064ff0f,	/* RAW */
		LRLJF = 0x00640013,	/* RAW + Jpeg Large Fine */
		LRLJN = 0x00640012,	/* RAW + Jpeg Large Normal */
		LRMJF = 0x00640113,	/* RAW + Jpeg Middle Fine */
		LRMJN = 0x00640112,	/* RAW + Jpeg Middle Normal */
		LRSJF = 0x00640213,	/* RAW + Jpeg Small Fine */
		LRSJN = 0x00640212,	/* RAW + Jpeg Small Normal */
		LRS1JF = 0x00640E13,	/* RAW + Jpeg Small1 Fine */
		LRS1JN = 0x00640E12,	/* RAW + Jpeg Small1 Normal */
		LRS2JF = 0x00640F13,	/* RAW + Jpeg Small2 */
		LRS3JF = 0x00641013,	/* RAW + Jpeg Small3 */

		LRLJ = 0x00640010,	/* RAW + Jpeg Large */
		LRM1J = 0x00640510,	/* RAW + Jpeg Middle1 */
		LRM2J = 0x00640610,	/* RAW + Jpeg Middle2 */
		LRSJ = 0x00640210,	/* RAW + Jpeg Small */

		/* MRAW(SRAW1) + Jpeg */
		MR = 0x0164ff0f,	/* MRAW(SRAW1) */
		MRLJF = 0x01640013,	/* MRAW(SRAW1) + Jpeg Large Fine */
		MRLJN = 0x01640012,	/* MRAW(SRAW1) + Jpeg Large Normal */
		MRMJF = 0x01640113,	/* MRAW(SRAW1) + Jpeg Middle Fine */
		MRMJN = 0x01640112,	/* MRAW(SRAW1) + Jpeg Middle Normal */
		MRSJF = 0x01640213,	/* MRAW(SRAW1) + Jpeg Small Fine */
		MRSJN = 0x01640212,	/* MRAW(SRAW1) + Jpeg Small Normal */
		MRS1JF = 0x01640E13,	/* MRAW(SRAW1) + Jpeg Small1 Fine */
		MRS1JN = 0x01640E12,	/* MRAW(SRAW1) + Jpeg Small1 Normal */
		MRS2JF = 0x01640F13,	/* MRAW(SRAW1) + Jpeg Small2 */
		MRS3JF = 0x01641013,	/* MRAW(SRAW1) + Jpeg Small3 */

		MRLJ = 0x01640010,	/* MRAW(SRAW1) + Jpeg Large */
		MRM1J = 0x01640510,	/* MRAW(SRAW1) + Jpeg Middle1 */
		MRM2J = 0x01640610,	/* MRAW(SRAW1) + Jpeg Middle2 */
		MRSJ = 0x01640210,	/* MRAW(SRAW1) + Jpeg Small */

		/* SRAW(SRAW2) + Jpeg */
		SR = 0x0264ff0f,	/* SRAW(SRAW2) */
		SRLJF = 0x02640013,	/* SRAW(SRAW2) + Jpeg Large Fine */
		SRLJN = 0x02640012,	/* SRAW(SRAW2) + Jpeg Large Normal */
		SRMJF = 0x02640113,	/* SRAW(SRAW2) + Jpeg Middle Fine */
		SRMJN = 0x02640112,	/* SRAW(SRAW2) + Jpeg Middle Normal */
		SRSJF = 0x02640213,	/* SRAW(SRAW2) + Jpeg Small Fine */
		SRSJN = 0x02640212,	/* SRAW(SRAW2) + Jpeg Small Normal */
		SRS1JF = 0x02640E13,	/* SRAW(SRAW2) + Jpeg Small1 Fine */
		SRS1JN = 0x02640E12,	/* SRAW(SRAW2) + Jpeg Small1 Normal */
		SRS2JF = 0x02640F13,	/* SRAW(SRAW2) + Jpeg Small2 */
		SRS3JF = 0x02641013,	/* SRAW(SRAW2) + Jpeg Small3 */

		SRLJ = 0x02640010,	/* SRAW(SRAW2) + Jpeg Large */
		SRM1J = 0x02640510,	/* SRAW(SRAW2) + Jpeg Middle1 */
		SRM2J = 0x02640610,	/* SRAW(SRAW2) + Jpeg Middle2 */
		SRSJ = 0x02640210,	/* SRAW(SRAW2) + Jpeg Small */

		// LEGACY
		Legacy_LJ = 0x001f000f,	/* Jpeg Large */
		Legacy_M1J = 0x051f000f,	/* Jpeg Middle1 */
		Legacy_M2J = 0x061f000f,	/* Jpeg Middle2 */
		Legacy_SJ = 0x021f000f,	/* Jpeg Small */
		Legacy_LJF = 0x00130000,	/* Jpeg Large Fine */
		Legacy_LJN = 0x00120000,	/* Jpeg Large Normal */
		Legacy_MJF = 0x01130000,	/* Jpeg Middle Fine */
		Legacy_MJN = 0x01120000,	/* Jpeg Middle Normal */
		Legacy_SJF = 0x02130000,	/* Jpeg Small Fine */
		Legacy_SJN = 0x02120000,	/* Jpeg Small Normal */

		Legacy_LR = 0x00240000,	/* RAW */
		Legacy_LRLJF = 0x00240013,	/* RAW + Jpeg Large Fine */
		Legacy_LRLJN = 0x00240012,	/* RAW + Jpeg Large Normal */
		Legacy_LRMJF = 0x00240113,	/* RAW + Jpeg Middle Fine */
		Legacy_LRMJN = 0x00240112,	/* RAW + Jpeg Middle Normal */
		Legacy_LRSJF = 0x00240213,	/* RAW + Jpeg Small Fine */
		Legacy_LRSJN = 0x00240212,	/* RAW + Jpeg Small Normal */

		Legacy_LR2 = 0x002f000f,	/* RAW */
		Legacy_LR2LJ = 0x002f001f,	/* RAW + Jpeg Large */
		Legacy_LR2M1J = 0x002f051f,	/* RAW + Jpeg Middle1 */
		Legacy_LR2M2J = 0x002f061f,	/* RAW + Jpeg Middle2 */
		Legacy_LR2SJ = 0x002f021f	/* RAW + Jpeg Small */
	}
}
