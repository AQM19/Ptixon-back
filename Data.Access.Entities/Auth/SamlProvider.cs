﻿using System;
using System.Collections.Generic;

namespace Data.Access.Entities.Auth;

/// <summary>
/// Auth: Manages SAML Identity Provider connections.
/// </summary>
public partial class SamlProvider
{
    public Guid Id { get; set; }

    public Guid SsoProviderId { get; set; }

    public string EntityId { get; set; } = null!;

    public string MetadataXml { get; set; } = null!;

    public string? MetadataUrl { get; set; }

    public string? AttributeMapping { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? NameIdFormat { get; set; }

    public virtual SsoProvider SsoProvider { get; set; } = null!;
}
