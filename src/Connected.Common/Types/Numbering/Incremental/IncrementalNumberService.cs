using Connected.Common.Types.Numbering.Incremental.Dtos;
using Connected.Common.Types.Numbering.Incremental.Ops;
using Connected.Services;

namespace Connected.Common.Types.Numbering.Incremental;
internal sealed class IncrementalNumberService(IServiceProvider services)
		: Service(services), IIncrementalNumberService
{
	public async Task Delete(IIncrementalNumberDto dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Next(IIncrementalNumberDto dto)
	{
		return await Invoke(GetOperation<Next>(), dto);
	}

	public async Task<IIncrementalNumber?> Select(IIncrementalNumberDto dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}
}
