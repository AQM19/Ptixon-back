﻿using System;
using System.Collections.Generic;

namespace Data.Access.Entities.Storage;

public partial class S3MultipartUploadPart
{
    public Guid Id { get; set; }

    public string UploadId { get; set; } = null!;

    public long Size { get; set; }

    public int PartNumber { get; set; }

    public string BucketId { get; set; } = null!;

    public string Key { get; set; } = null!;

    public string Etag { get; set; } = null!;

    public string? OwnerId { get; set; }

    public string Version { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Bucket Bucket { get; set; } = null!;

    public virtual S3MultipartUpload Upload { get; set; } = null!;
}
