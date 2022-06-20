﻿using Envelope.Infrastructure;

namespace Envelope.Metrics.PostgreSql;

public class DbEventCounterData : Serializer.IDictionaryObject
{
	public Guid IdEventCounter { get; set; }
	public DateTime CreatedUtc { get; set; }
	public Guid RuntimeUniqueKey { get; set; }
	public double? Increment { get; set; }
	public double? Mean { get; set; }
	public int? Count { get; set; }
	public double? Min { get; set; }
	public double? Max { get; set; }

	public DbEventCounterData(Guid idEventCounter)
	{
		IdEventCounter = idEventCounter;
		CreatedUtc = DateTime.UtcNow;
		RuntimeUniqueKey = EnvironmentInfo.RUNTIME_UNIQUE_KEY;
	}

	public DbEventCounterData(EventCounterData? data)
		: this (data.HasValue ? data.Value.IdEventCounter : Guid.Empty)
	{
		if (!data.HasValue)
			throw new ArgumentNullException(nameof(data));

		if (data.Value.Increment.HasValue)
			Increment = data.Value.Increment;

		if (data.Value.Mean.HasValue)
			Mean = data.Value.Mean;

		if (data.Value.Count.HasValue)
			Count = data.Value.Count;

		if (data.Value.Min.HasValue)
			Min = data.Value.Min;

		if (data.Value.Max.HasValue)
			Max = data.Value.Max;
	}

	public IDictionary<string, object?> ToDictionary(Serializer.ISerializer? serializer = null)
	{
		var dict = new Dictionary<string, object?>
		{
			{ nameof(IdEventCounter), IdEventCounter },
			{ nameof(RuntimeUniqueKey), RuntimeUniqueKey },
			{ nameof(CreatedUtc), CreatedUtc },
		};

		if (Increment.HasValue)
			dict.Add(nameof(Increment), Increment);

		if (Mean.HasValue)
			dict.Add(nameof(Mean), Mean);

		if (Count.HasValue)
			dict.Add(nameof(Count), Count);

		if (Min.HasValue)
			dict.Add(nameof(Min), Min);

		if (Max.HasValue)
			dict.Add(nameof(Max), Max);

		return dict;
	}
}
