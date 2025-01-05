using Connected.Entities;

namespace Connected.Common.Types.MeasureUnits;

/// <summary>
/// The measure unit entity contract.
/// </summary>
public interface IMeasureUnit : IEntity<int>
{
	/// <value>
	/// The name of the measure unit. 
	/// </value>
	string Name { get; init; }
	/// <value>
	/// The code of the measure unit. 
	/// </value>
	string Code { get; init; }
	/// <value>
	/// The decimal precision of the measure unit.
	/// Measure units can have different calculation
	/// and presentation precision.
	/// </value>
	byte Precision { get; init; }
	/// <value>
	/// The status of the measure unit. Disabled measure
	/// units should not be available to new records.
	/// </value>
	Status Status { get; init; }
}
