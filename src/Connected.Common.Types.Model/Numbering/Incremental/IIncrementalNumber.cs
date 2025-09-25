using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Common.Types.Numbering.Incremental;

[EntityKey(CommonTypesMetaData.IncrementalNumberKey)]
public interface IIncrementalNumber : IEntity<int>
{
	string Key { get; init; }
	int? Value { get; init; }
	DateTimeOffset? TimeStamp { get; init; }
}
