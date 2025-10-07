using Connected.Common.Types.Numbering.Incremental.Dtos;
using Connected.Entities;
using Connected.Services;

namespace Connected.Common.Types.Numbering.Incremental.Ops;
internal class Select(IIncrementalNumberCache cache)
	: ServiceFunction<IIncrementalNumberDto, IIncrementalNumber?>
{
	protected override async Task<IIncrementalNumber?> OnInvoke()
	{
		return await cache.AsEntity(f => string.Equals(f.Key, Dto.Key, StringComparison.OrdinalIgnoreCase));
	}
}
