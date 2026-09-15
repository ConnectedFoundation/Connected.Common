using Connected.Common.Types.Numbering.Incremental.Dtos;
using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Common.Types.Numbering.Incremental.Ops;

internal class Select(IStorageProvider storage)
    : ServiceFunction<IIncrementalNumberDto, IIncrementalNumber?>
{
    protected override async Task<IIncrementalNumber?> OnInvoke()
    {
        var key = Dto.Key;

        return await storage.Open<IncrementalNumber>().AsEntity(f => f.Key == key);
    }
}
