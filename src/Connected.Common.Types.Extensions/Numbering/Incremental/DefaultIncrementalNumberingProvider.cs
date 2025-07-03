namespace Connected.Common.Types.Extensions.Numbering.Incremental;
internal sealed class DefaultIncrementalNumberingProvider : IncrementalNumberingProvider
{
	protected override async Task<string?> OnInvoke()
	{
		if (Dto.Entity.Value is null)
			return await Task.FromResult(1.ToString());

		if (!int.TryParse(Dto.Entity.Value, out var value))
			return await Task.FromResult(1.ToString());

		return value++.ToString();
	}
}
