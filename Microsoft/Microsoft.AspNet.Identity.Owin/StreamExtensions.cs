// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNet.Identity.Owin.StreamExtensions
// Assembly: Microsoft.AspNet.Identity.Owin, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 84FCB78A-CEFE-4E78-AA1E-6486E623B385
// Assembly location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.dll
// XML documentation location: D:\My Workspaces\TEST DLL\Microsoft.AspNet.Identity.Owin.xml

using System;
using System.IO;
using System.Text;

namespace Microsoft.AspNet.Identity.Owin
{
  internal static class StreamExtensions
  {
    internal static readonly Encoding DefaultEncoding = (Encoding) new UTF8Encoding(false, true);

    public static BinaryReader CreateReader(this Stream stream) => new BinaryReader(stream, StreamExtensions.DefaultEncoding, true);

    public static BinaryWriter CreateWriter(this Stream stream) => new BinaryWriter(stream, StreamExtensions.DefaultEncoding, true);

    public static DateTimeOffset ReadDateTimeOffset(this BinaryReader reader) => new DateTimeOffset(reader.ReadInt64(), TimeSpan.Zero);

    public static void Write(this BinaryWriter writer, DateTimeOffset value) => writer.Write(value.UtcTicks);
  }
}
