using Connected.Common.Mock;
using Connected.Common.Mock.Dtos;
using Connected.Common.Types;
using Connected.Core.Mock;
using Connected.Core.Services.Mock;
using Connected.Entities;

namespace Connected.Common.Tests;

[TestClass]
public sealed class CostCenters()
	: RestTest(CommonTypesUrls.CostCenters)
{
	[TestMethod]
	public async Task Invoke()
	{
		var id = await Insert<InsertCostCenterDtoMock, int>(new()
		{
			Name = ValueGenerator.Generate(10),
			Code = ValueGenerator.Generate(5),
			Status = Status.Enabled
		});

		Assert.IsTrue(id > 0);

		var entities = await Query<DtoMock, CostCenterMock>(null);

		Assert.IsNotNull(entities);
		Assert.IsTrue(entities.Count > 0);

		var updateDto = new UpdateCostCenterDtoMock
		{
			Id = id,
			Name = ValueGenerator.Generate(10),
			Code = ValueGenerator.Generate(5),
			Status = Status.Disabled,
		};

		await Update(updateDto);

		var entity = await Select<PrimaryKeyDtoMock<int>, CostCenterMock>(id);

		Assert.IsNotNull(entity);
		Assert.AreEqual(entity.Name, updateDto.Name);
		Assert.AreEqual(entity.Code, updateDto.Code);
		Assert.AreEqual(entity.Status, updateDto.Status);

		await Delete<PrimaryKeyDtoMock<int>>(id);

		entity = await Select<PrimaryKeyDtoMock<int>, CostCenterMock>(id);

		Assert.IsNull(entity);
	}
}
