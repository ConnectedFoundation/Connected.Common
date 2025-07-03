using Connected.Entities;

namespace Connected.Common.Types.Numbering.Incremental;
public interface IIncrementalNumber : IEntity<int>
{
	string Key { get; init; }
	string? Value { get; init; }
	DateTimeOffset? TimeStamp { get; init; }
}
