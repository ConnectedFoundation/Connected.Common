using Connected.Annotations;
using Connected.Common.Types.MeasureUnits.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Common.Types.MeasureUnits;
/// <summary>
/// The entity service for the measure units. 
/// </summary>
[Service, ServiceUrl(CommonUrls.MeasureUnits)]
public interface IMeasureUnitService
{
	/// <summary>
	/// Queries all measure units with an optional pagind and sorting
	/// criteria. 
	/// </summary>
	/// <returns>
	/// The list of measure units that passed the optional criteria or
	/// the entire list of measure units if dto had not been specified. 
	/// </returns>
	/// <param name="dto">The optional query criteria for sorting and paging.</param>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<IImmutableList<IMeasureUnit>> Query(IQueryDto? dto);
	/// <summary>
	/// Performs lookup for the specified list of measure unit ids. 
	/// </summary>
	/// <returns>
	/// The list of measure units that matches the input list of ids.
	/// </returns>
	/// <param name="dto">The list of ids for which the query will be performed.</param>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	[ServiceUrl(ServiceOperations.Lookup)]
	Task<IImmutableList<IMeasureUnit>> Query(IPrimaryKeyListDto<int> dto);
	/// <summary>
	/// Selects measure unit for the specified id. 
	/// </summary>
	/// <returns>
	/// The measure unit for the specified id or <c>null</c> if it's not found.
	/// </returns>
	/// <param name="dto">The id for which the measure unit will be returned.</param>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<IMeasureUnit?> Select(IPrimaryKeyDto<int> dto);
	/// <summary>
	/// Selects measure unit for the specified code. 
	/// </summary>
	/// <returns>
	/// The measure unit for the specified code or <c>null</c> if it's not found.
	/// </returns>
	/// <param name="dto">The code for which the query will be performed.</param>
	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	[ServiceUrl(ServiceOperations.SelectByCode)]
	Task<IMeasureUnit?> Select(ISelectMeasureUnitDto dto);
	/// <summary>
	/// Deletes the measure unit from the system. 
	/// </summary>
	/// <param name="dto">The id of the measure unit to delete.</param>
	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);
	/// <summary>
	/// Inserts a new measure unit. 
	/// </summary>
	/// <param name="dto">The dto containing properties about measure unit.</param>
	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertMeasureUnitDto dto);
	/// <summary>
	/// Updates existing measure unit. 
	/// </summary>
	/// <param name="dto">The dto containing properties of the measure unit that need to be updated.</param>
	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Put | ServiceOperationVerbs.Patch)]
	Task Update(IUpdateMeasureUnitDto dto);
}
