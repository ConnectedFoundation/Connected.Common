﻿using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;
using Connected.Services;

namespace Connected.Common.Types.EnvironmentLocations;

internal sealed record EnvironmentLocation : ConsistentEntity<int>, IEnvironmentLocation
{
	[Ordinal(0), Length(Dto.DefaultNameLength)]
	public required string Name { get; init; }

	[Ordinal(1), Length(Dto.DefaultCodeLength)]
	public required string Code { get; init; }

	[Ordinal(2)]
	public int Head { get; init; }

	[Ordinal(4)]
	public Status Status { get; init; }

	[Ordinal(5), Length(Dto.DefaultTagsLength)]
	public string? Tags { get; init; }
}
