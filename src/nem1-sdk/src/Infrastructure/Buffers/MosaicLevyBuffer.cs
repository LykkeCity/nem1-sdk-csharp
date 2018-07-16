// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>


using System;
using io.nem1.sdk.Infrastructure.Imported.FlatBuffers;

namespace io.nem1.sdk.Infrastructure.Buffers
{
    internal struct MosaicLevyBuffer : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  internal static MosaicLevyBuffer GetRootAsMosaicLevyBuffer(ByteBuffer _bb) { return GetRootAsMosaicLevyBuffer(_bb, new MosaicLevyBuffer()); }
  internal static MosaicLevyBuffer GetRootAsMosaicLevyBuffer(ByteBuffer _bb, MosaicLevyBuffer obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  internal MosaicLevyBuffer __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  internal int LengthOfLevyStructure { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal int FeeType { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal int LengthOfRecipientAddress { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal sbyte RecipientAddress(int j) { int o = __p.__offset(10); return o != 0 ? __p.bb.GetSbyte(__p.__vector(o) + j * 1) : (sbyte)0; }
  internal int RecipientAddressLength { get { int o = __p.__offset(10); return o != 0 ? __p.__vector_len(o) : 0; } }
  internal ArraySegment<byte>? GetRecipientAddressBytes() { return __p.__vector_as_arraysegment(10); }
  internal int LengthOfMosaicIdStructure { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal int LengthOfMosaicNamespaceId { get { int o = __p.__offset(14); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal sbyte NamespaceIdString(int j) { int o = __p.__offset(16); return o != 0 ? __p.bb.GetSbyte(__p.__vector(o) + j * 1) : (sbyte)0; }
  internal int NamespaceIdStringLength { get { int o = __p.__offset(16); return o != 0 ? __p.__vector_len(o) : 0; } }
  internal ArraySegment<byte>? GetNamespaceIdStringBytes() { return __p.__vector_as_arraysegment(16); }
  internal int LengthMosaicNameString { get { int o = __p.__offset(18); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  internal sbyte MosaicNameString(int j) { int o = __p.__offset(20); return o != 0 ? __p.bb.GetSbyte(__p.__vector(o) + j * 1) : (sbyte)0; }
  internal int MosaicNameStringLength { get { int o = __p.__offset(20); return o != 0 ? __p.__vector_len(o) : 0; } }
  internal ArraySegment<byte>? GetMosaicNameStringBytes() { return __p.__vector_as_arraysegment(20); }
  internal long FeeQuantity { get { int o = __p.__offset(22); return o != 0 ? __p.bb.GetLong(o + __p.bb_pos) : (long)0; } }

  internal static Offset<MosaicLevyBuffer> CreateMosaicLevyBuffer(FlatBufferBuilder builder,
      int lengthOfLevyStructure = 0,
      int feeType = 0,
      int lengthOfRecipientAddress = 0,
      VectorOffset recipientAddressOffset = default(VectorOffset),
      int lengthOfMosaicIdStructure = 0,
      int lengthOfMosaicNamespaceId = 0,
      VectorOffset namespaceIdStringOffset = default(VectorOffset),
      int lengthMosaicNameString = 0,
      VectorOffset mosaicNameStringOffset = default(VectorOffset),
      ulong feeQuantity = 0) {
    builder.StartObject(10);
    MosaicLevyBuffer.AddFeeQuantity(builder, feeQuantity);
    MosaicLevyBuffer.AddMosaicNameString(builder, mosaicNameStringOffset);
    MosaicLevyBuffer.AddLengthMosaicNameString(builder, lengthMosaicNameString);
    MosaicLevyBuffer.AddNamespaceIdString(builder, namespaceIdStringOffset);
    MosaicLevyBuffer.AddLengthOfMosaicNamespaceId(builder, lengthOfMosaicNamespaceId);
    MosaicLevyBuffer.AddLengthOfMosaicIdStructure(builder, lengthOfMosaicIdStructure);
    MosaicLevyBuffer.AddRecipientAddress(builder, recipientAddressOffset);
    MosaicLevyBuffer.AddLengthOfRecipientAddress(builder, lengthOfRecipientAddress);
    MosaicLevyBuffer.AddFeeType(builder, feeType);
    MosaicLevyBuffer.AddLengthOfLevyStructure(builder, lengthOfLevyStructure);
    return MosaicLevyBuffer.EndMosaicLevyBuffer(builder);
  }

  internal static void StartMosaicLevyBuffer(FlatBufferBuilder builder) { builder.StartObject(10); }
  internal static void AddLengthOfLevyStructure(FlatBufferBuilder builder, int lengthOfLevyStructure) { builder.AddInt(0, lengthOfLevyStructure, 10000000); }
  internal static void AddFeeType(FlatBufferBuilder builder, int feeType) { builder.AddInt(1, feeType, 0); }
  internal static void AddLengthOfRecipientAddress(FlatBufferBuilder builder, int lengthOfRecipientAddress) { builder.AddInt(2, lengthOfRecipientAddress, 0); }
  internal static void AddRecipientAddress(FlatBufferBuilder builder, VectorOffset recipientAddressOffset) { builder.AddOffset(3, recipientAddressOffset.Value, 0); }
  internal static VectorOffset CreateRecipientAddressVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  internal static void StartRecipientAddressVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  internal static void AddLengthOfMosaicIdStructure(FlatBufferBuilder builder, int lengthOfMosaicIdStructure) { builder.AddInt(4, lengthOfMosaicIdStructure, 0); }
  internal static void AddLengthOfMosaicNamespaceId(FlatBufferBuilder builder, int lengthOfMosaicNamespaceId) { builder.AddInt(5, lengthOfMosaicNamespaceId, 0); }
  internal static void AddNamespaceIdString(FlatBufferBuilder builder, VectorOffset namespaceIdStringOffset) { builder.AddOffset(6, namespaceIdStringOffset.Value, 0); }
  internal static VectorOffset CreateNamespaceIdStringVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  internal static void StartNamespaceIdStringVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  internal static void AddLengthMosaicNameString(FlatBufferBuilder builder, int lengthMosaicNameString) { builder.AddInt(7, lengthMosaicNameString, 0); }
  internal static void AddMosaicNameString(FlatBufferBuilder builder, VectorOffset mosaicNameStringOffset) { builder.AddOffset(8, mosaicNameStringOffset.Value, 0); }
  internal static VectorOffset CreateMosaicNameStringVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  internal static void StartMosaicNameStringVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  internal static void AddFeeQuantity(FlatBufferBuilder builder, ulong feeQuantity) { builder.AddUlong(9, feeQuantity, 0); }
  internal static Offset<MosaicLevyBuffer> EndMosaicLevyBuffer(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<MosaicLevyBuffer>(o);
  }
};


}