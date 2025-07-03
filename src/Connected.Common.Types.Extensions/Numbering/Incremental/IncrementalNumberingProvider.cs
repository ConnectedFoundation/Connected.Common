using Connected.Common.Types.Extensions.Numbering.Incremental.Dtos;

namespace Connected.Common.Types.Extensions.Numbering.Incremental;
public abstract class IncrementalNumberingProvider : Middleware, IIncrementalNumberingProvider
{
	protected IIncrementalNumberingProviderDto Dto { get; private set; } = default!;
	public Task<string?> Invoke(IIncrementalNumberingProviderDto dto)
	{
		Dto = dto;

		return OnInvoke();
	}

	protected virtual async Task<string?> OnInvoke()
	{
		return await Task.FromResult<string?>(null);
	}
}
